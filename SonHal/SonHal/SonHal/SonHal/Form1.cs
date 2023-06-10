using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Windows.Forms;
using System.Data;
using System.Security.Policy;
using System.Collections.Generic;
using OpenQA.Selenium.Edge;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using System.Text;
using SeleniumRunner;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Bibliography;

namespace SonHal
{
    public partial class Form1 : Form
    {

        public List<string> basliklar = new List<string>();
        public DataSet dataSet { get; private set; }
        public SeleniumStepsDTO seleniumDTO;
        public List<dynamic> excelRows { get; set; }

        public string filePath;
        public System.Data.DataTable dataTable { get; private set; }

        public string SideFileJsonData;
        SideRunner sideRunner = new SideRunner();
        public string _secilenDriver { get; set; }

        DeserializationSide deserializationSide = new DeserializationSide();


        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _secilenDriver = (string)comboBox1.SelectedItem;
        }


        private void SideFileChoose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Dosya seçin";
                dlg.Filter = "side files (*.side)|*.side";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string dosyaYolu = dlg.FileName;
                    string dosyaUzantisi = Path.GetExtension(dosyaYolu);

                    if (dosyaUzantisi == ".side")
                    {
                        try
                        {
                            SideFileJsonData = File.ReadAllText(dosyaYolu);
                            deserializationSide.GetSideData(SideFileJsonData);
                            seleniumDTO = deserializationSide.GetSideData(SideFileJsonData);
                            dataGridView1.Rows.Clear();


                            foreach (var value in seleniumDTO.Commands)
                            {
                                var getURL = seleniumDTO.Url;
                                var getValue = value.Value;
                                var getCommand = value.Command;
                                var getTarget = value.Target;
                                DataGridViewRow row = new DataGridViewRow();


                                
                                row.CreateCells(dataGridView1);
                                if (getCommand == "open")
                                {
                                    // format deðiþtirilebilir.
                                    row.Cells[0].Value = getCommand + "|" + getURL + getTarget + "|" + getValue;
                                    dataGridView1.Rows.Add(row);

                                }
                                else
                                {
                                    row.Cells[0].Value = getCommand + "|" + getValue + "|" + getTarget;
                                    dataGridView1.Rows.Add(row);
                                }

                            }

                            int rowIndex = 0;

                            foreach (var value2 in seleniumDTO.Commands)
                            {

                                var userValues = value2.Value;
                                if (userValues != "")
                                {

                                    dataGridView1.Rows[rowIndex].Cells["SideValues"].Value = userValues;

                                    rowIndex++;

                                }
                            }
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].ReadOnly = true;
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Visible = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dosya okunurken bir hata oluþtu: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen .side uzantýlý bir dosya seçin.");
                    }
                }

            }

        }
        private void btnSideRunner_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dataTable = (System.Data.DataTable)dataGridView1.DataSource;


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {


                    string sideFile = row.Cells["sideFileValues"].Value != null ? row.Cells["sideFileValues"].Value.ToString() : string.Empty;
                    string sideValues = row.Cells["SideValues"].Value != null ? row.Cells["SideValues"].Value.ToString() : string.Empty;
                    string userValue = row.Cells["userValues"].Value != null ? row.Cells["userValues"].Value.ToString() : string.Empty;
                    string excelHeaders = row.Cells["ExcelHeaders"].Value != null ? row.Cells["ExcelHeaders"].Value.ToString() : string.Empty;
                    bool isExcel = row.Cells["isExcel"].Value != null ? Convert.ToBoolean(row.Cells["isExcel"].Value) : false;
                    bool isRepeat = row.Cells["isRepeat"].Value != null ? Convert.ToBoolean(row.Cells["isRepeat"].Value) : false;


                    MatchedDto matchedDto = new MatchedDto
                    {
                        SideValues = sideValues,
                        UserValues = userValue,
                        ExcelHeaders = excelHeaders,
                        isExcel = isExcel,
                        isRepeat = isRepeat,
                        sideFile = sideFile,
                    };

                    matchedDtos.Add(matchedDto);
                }
                sideRunner.SideRunnerSteps(matchedDtos, _secilenDriver);
            }
            catch
            {
                MessageBox.Show("Side dosyasý seçiniz öncesinde");
            }

        }


        private void ExcelFileChoose_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewColumn excelHeadersColumn = dataGridView1.Columns["ExcelHeaders"];


                if (excelHeadersColumn != null)
                {

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells["ExcelHeaders"].Value = null;
                    }
                }

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    excelRows = ExcelHelper.ReadExcel(filePath);

                    FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    IExcelDataReader excelReader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);

                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    dataSet = excelReader.AsDataSet(conf);
                    this.dataTable = dataSet.Tables[0];



                    for (int i = 0; i < excelReader.FieldCount; i++)
                    {
                        basliklar.Add(dataTable.Columns[i].ColumnName.ToString());
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
                        comboBoxCell.Items.AddRange(basliklar.ToArray());
                        dataGridView1.Rows[i].Cells["ExcelHeaders"] = comboBoxCell;
                        dataGridView1.Rows[i].Cells["ExcelHeaders"].ReadOnly = true;
                    }
                    basliklar.Clear();
                }


            }
            catch
            {
                MessageBox.Show("Lütfen önce side dosyasý seçiniz.");
            }
        }

        List<MatchedDto> matchedDtos = new List<MatchedDto>();

        private void btnExcelDataTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dataTable = (System.Data.DataTable)dataGridView1.DataSource;
                matchedDtos.Clear();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {


                    string sideFile = row.Cells["sideFileValues"].Value != null ? row.Cells["sideFileValues"].Value.ToString() : string.Empty;
                    string sideValues = row.Cells["SideValues"].Value != null ? row.Cells["SideValues"].Value.ToString() : string.Empty;
                    string userValue = row.Cells["userValues"].Value != null ? row.Cells["userValues"].Value.ToString() : string.Empty;
                    string excelHeaders = row.Cells["ExcelHeaders"].Value != null ? row.Cells["ExcelHeaders"].Value.ToString() : string.Empty;
                    bool isExcel = row.Cells["isExcel"].Value != null ? Convert.ToBoolean(row.Cells["isExcel"].Value) : false;
                    bool isRepeat = row.Cells["isRepeat"].Value != null ? Convert.ToBoolean(row.Cells["isRepeat"].Value) : false;


                    MatchedDto matchedDto = new MatchedDto
                    {
                        SideValues = sideValues,
                        UserValues = userValue,
                        ExcelHeaders = excelHeaders,
                        isExcel = isExcel,
                        isRepeat = isRepeat,
                        sideFile = sideFile,
                    };

                    matchedDtos.Add(matchedDto);

                }

                sideRunner.ExportExcel(excelRows, matchedDtos, _secilenDriver);
            }
            catch
            {
                MessageBox.Show("Lütfen önce side dosyasý ve excel baþlýklarýný seçiniz.");
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCheckBoxCell checkBoxCell = dataGridView1.Rows[e.RowIndex].Cells["isExcel"] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && checkBoxCell.Value != null && (bool)checkBoxCell.Value == true)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["ExcelHeaders"].ReadOnly = false;
                    dataGridView1.Rows[e.RowIndex].Cells["userValues"].Value = string.Empty;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["ExcelHeaders"].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells["ExcelHeaders"].Value = null;
                }
            }
        }


    }
}