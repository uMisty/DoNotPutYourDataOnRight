using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonPutYourDataOnRight.Application.Helper
{
    internal class ExcelFile
    {
        public Guid Id { get; set;  }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public List<Worksheet> SheetList { get; set; }

        public SharedStringTable SharedStringTable {  get; set; } 
    }
    internal class ExcelService
    {
        public List<ExcelFile> Files { get; set; } = new List<ExcelFile>();

        public List<ExcelFile> AddExcel(string[] files)
        {
            var tmpResult = new List<ExcelFile>();
            try
            {
                foreach (var file in files)
                {
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(file, false))
                    {
                        WorkbookPart workbookPart = doc.WorkbookPart;
                        List<Worksheet> sheets = new List<Worksheet>();
                        foreach (var item in workbookPart.WorksheetParts)
                        {
                            sheets.Add(item.Worksheet);
                        }

                        var table = workbookPart.SharedStringTablePart?.SharedStringTable;

                        tmpResult.Add(new ExcelFile()
                        {
                            Id = Guid.NewGuid(),
                            FileName = System.IO.Path.GetFileName(file),
                            FilePath = file,
                            SheetList = sheets,
                            SharedStringTable = table
                        });
                    }
                }
                Files.AddRange(tmpResult);
                return tmpResult;
            }
            catch (Exception)
            {
                throw new Exception("Load excel file error, Please use the correct file");
            }
        }

        public void DeleteExcel(Guid id)
        {
            Files.Remove(Files.FirstOrDefault(o => o.Id.Equals(id)));
        }
    }
}
