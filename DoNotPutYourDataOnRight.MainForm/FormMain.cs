using DocumentFormat.OpenXml.Spreadsheet;
using DoNotPutYourDataOnRight.Application.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DoNotPutYourDataOnRight.Application
{
    public partial class FormMain : Form
    {
        private readonly ExcelService _excel = new ExcelService();
        private string[] _initData = ConfigurationManager.AppSettings["defaultHeaders"].Split('|');

        public FormMain()
        {
            InitializeComponent();
            foreach (var item in _initData)
            {
                var index = dgvHeadText.Rows.Add(new DataGridViewRow());
                dgvHeadText.Rows[index].Cells["HeadText"].Value = item;
            }
        }

        /// <summary>
        /// Add Excel File to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Please select an excel file.",
                Filter = "Excel File(*.xls,*.xlsx) | *.xls;*.xlsx",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<ExcelFile> result;
                try
                {
                    result = _excel.AddExcel(dialog.FileNames);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                foreach (var item in result)
                {
                    lvFiles.Items.Add(new ListViewItem()
                    {
                        Text = item.FileName,
                        Tag = item.Id
                    });
                }
            }
            if(lvFiles.Items.Count > 0)
            {
                btnRefresh.Enabled = true;
            }
        }

        /// <summary>
        /// Watching Press "Delete"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                var listView = (ListView)sender;
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    _excel.DeleteExcel((Guid)item.Tag);
                    listView.Items.Remove(item);
                }
                if(lvFiles.Items.Count < 1)
                {
                    btnRefresh.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Rebuild Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvResult.DataSource = null;
            if (lvFiles.Items.Count < 1)
            {
                MessageBox.Show("Please select at least one excel file");
            }
            if (dgvHeadText.Rows.Count < 1)
            {
                MessageBox.Show("Please enter at least one Table Head");
            }
            List<string> properties = new List<string>();
            foreach (DataGridViewRow item in dgvHeadText.Rows)
            {
                if (!item.IsNewRow)
                    properties.Add(item.Cells["HeadText"].Value.ToString());
            }
            List<Dictionary<string, string>> Result = new List<Dictionary<string, string>>();
            foreach (var file in _excel.Files)
            {
                foreach (var sheet in file.SheetList)
                {
                    Dictionary<string, string> values = new Dictionary<string, string>();
                    var rows = sheet.Descendants<Row>();
                    foreach (var row in rows)
                    {
                        string tmpKey = string.Empty;
                        foreach (Cell cell in row)
                        {
                            var cellValue = ExcelHelper.GetValue(cell, file.SharedStringTable);
                            if (!string.IsNullOrEmpty(tmpKey))
                            {
                                values.Add(tmpKey, cellValue);
                                tmpKey = string.Empty;
                            }
                            cellValue = cellValue?.Trim();
                            if (properties.Contains(cellValue))
                            {
                                tmpKey = cellValue;
                            }
                        }
                    }
                    if (values.Count > 0) Result.Add(values);
                }
            }
            if (Result.Count > 0) { RefreshResult(Result, properties); btnExportExcel.Enabled = true; btnExportJson.Enabled = true; }
        }

        /// <summary>
        /// flush Datagrid View
        /// </summary>
        /// <param name="source"></param>
        /// <param name="header"></param>
        private void RefreshResult(List<Dictionary<string,string>> source,List<string> header)
        {
            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();
            foreach (var item in header)
            {
                dgvResult.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = item.Trim(),
                    HeaderText = item
                });
            }
            foreach (var item in source)
            {
                var index = dgvResult.Rows.Add(new DataGridViewRow());
                foreach (var cellKey in item.Keys)
                {
                    dgvResult.Rows[index].Cells[cellKey].Value = item[cellKey];
                }
            }
        }

        private void btnExportJson_Click(object sender, EventArgs e)
        {
            JArray array = new JArray();
            foreach(DataGridViewRow row in dgvResult.Rows)
            {
                if (!row.IsNewRow)
                {
                    JObject obj = new JObject();
                    foreach (DataGridViewColumn column in dgvResult.Columns)
                    {
                        obj.Add(column.Name, row.Cells[column.Name].Value.ToString());
                    }
                    array.Add(obj);
                }
            }
            SaveJsonFile(array.ToString());
        }

        private string SaveJsonFile(string content)
        {
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JSON Data(*.json)|*.json",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName;
                File.WriteAllText(sfd.FileName,content);
            }

            return localFilePath;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel File(*.xls) | *.xls", FilterIndex = 1, RestoreDirectory = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = ExcelHelper.CreateExcel(GetDgvToTable(dgvResult)))
                    {
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate))
                        {
                            using (BinaryWriter w = new BinaryWriter(fs))
                            {
                                w.Write(stream.ToArray());
                            }
                        }
                    }
                }
            }
        }

        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void llAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://umisty.com");
        }
    }
}
 