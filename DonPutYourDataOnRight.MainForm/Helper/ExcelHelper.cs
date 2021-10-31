using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace DonPutYourDataOnRight.Application.Helper
{
    internal class ExcelHelper
    {
        public static string GetValue(Cell cell, SharedStringTable stringTablePart)
        {
            if (cell.ChildElements.Count == 0)
                return null;
            string value = cell.InnerText;
            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                value = stringTablePart
                .ChildElements[Int32.Parse(value)]
                .InnerText;
            return value;
        }
  
        public static MemoryStream CreateExcel(DataTable table)
        {
            MemoryStream stream = new MemoryStream();
            using (var workbook = SpreadsheetDocument.Create(stream, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();
                workbook.WorkbookPart.Workbook = new Workbook
                {
                    Sheets = new Sheets()
                };

                uint sheetId = 1;
                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                sheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                if (sheets.Elements<Sheet>().Count() > 0)
                {
                    sheetId =
                        sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() +
                        1;
                }
                string sheetName = "Sheet " + sheetId;


                Sheet sheet = new Sheet()
                {
                    Id = relationshipId,
                    SheetId = sheetId,
                    Name = sheetName
                };
                sheets.Append(sheet);

                Row headerRow = new Row();

                List<String> columns = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.StyleIndex = 11;
                    cell.CellValue = new CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row();
                    foreach (string col in columns)
                    {
                        Cell cell = new Cell
                        {
                            DataType = CellValues.String,
                            StyleIndex = 10,
                            CellValue = new CellValue(dsrow[col].ToString())
                        };
                        newRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(newRow);
                }
                sheetPart.Worksheet.Append(sheetData);

                workbook.Close();
            }
            stream.Position = 0;
            return stream;
        }
    }
}