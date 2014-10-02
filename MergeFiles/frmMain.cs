using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

using System.Xml;

namespace MergeFiles
{
    public partial class frmMain : Form
    {
        int typeFileIndex;
        int separatorIndex;
        Settings settingsApp;
        string fileExtensionSupportDescribe;
        string fileExtensionSupport;


        public frmMain()
        {
            InitializeComponent();

            /*Инициализируем данные в элементах формы и переменные*/
            cbTypeFile.Items.Add("Microsoft Office Word");
            cbTypeFile.Items.Add("Microsoft Office Excel");

            //Разделитель для офиса
            cbSeparator.Items.Add("Нет разрыва");                           //?
            cbSeparator.Items.Add("Разрыв страниц: Страница");              //wdPageBreak
            cbSeparator.Items.Add("Разрыв страниц: Колонка");               //wdColumnBreak
            cbSeparator.Items.Add("Разрыв страниц: Обтекание текстом");     //wdTextWrappingBreak
            cbSeparator.Items.Add("Разрыв раздела: Следующая страница");    //wdSectionBreakNextPage
            cbSeparator.Items.Add("Разрыв раздела: Текущая страница");      //wdSectionBreakContinuous
            cbSeparator.Items.Add("Разрыв раздела: Четная страница");       //wdSectionBreakEvenPage
            cbSeparator.Items.Add("Разрыв раздела: Нечетная страница");     //wdSectionBreakOddPage
            /*
            wdLineBreak
            wdLineBreakClearLeft
            wdLineBreakClearRight
            */

            cbTypeFile.SelectedIndex = 0;
            cbSeparator.SelectedIndex = 0;
            typeFileIndex = 0;
            separatorIndex = 0;
        }


        /// <summary>
        /// Нажали на кнопку "Объединить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MergeFile_Click(object sender, EventArgs e)
        {
            MergeFiles();
        }

        private bool CheckFiles(string fileExtensionSupport)
        {
            int count = dgvFiles.Rows.Count;
            string errorExtension = string.Empty, errorFileExist = string.Empty;
            string fileName;
            for (int i = 0; i < count; i++)
            {
                if (bool.Parse(dgvFiles.Rows[i].Cells[0].Value.ToString()))
                {
                    fileName = Path.Combine(dgvFiles.Rows[i].Cells[1].Value.ToString(), dgvFiles.Rows[i].Cells[2].Value.ToString() + dgvFiles.Rows[i].Cells[3].Value.ToString());
                    if (!fileExtensionSupport.Contains("*" + dgvFiles.Rows[i].Cells[3].Value.ToString()))
                    {
                        errorExtension += fileName + "\r\n";
                    }

                    if (!File.Exists(fileName))
                    {
                        errorFileExist += fileName + "\r\n";
                    }

                }
            }
            if (!string.IsNullOrEmpty(errorExtension) && !string.IsNullOrEmpty(errorFileExist))
            {
                MessageBox.Show("Исключите их из списка добавлямых файлов следующие файлы:" + "\r\n" +
                        "Не поддерживаемые файлы: " + "\r\n" +
                        errorExtension.Substring(0, errorExtension.Length - 1) +
                        "Список поддерживаемых файлов: (" + fileExtensionSupport + ")." + "\r\n" + "\r\n" +
                        "Не существующие файлы: " + "\r\n" +
                        errorFileExist.Substring(0, errorFileExist.Length - 1), "Ошибка");
                return false;
            }
            else if (!string.IsNullOrEmpty(errorExtension))
            {
                MessageBox.Show("Исключите их из списка добавлямых файлов следующие файлы:" + "\r\n" +
                        "Не поддерживаемые файлы: " + "\r\n" +
                        errorExtension.Substring(0, errorExtension.Length - 1) +
                        "Список поддерживаемых файлов: (" + fileExtensionSupport + ").", "Ошибка");
                return false;
            }
            else if (!string.IsNullOrEmpty(errorFileExist))
            {
                MessageBox.Show("Исключите их из списка добавлямых файлов следующие файлы:" + "\r\n" +
                        "Не существующие файлы: " + "\r\n" +
                        errorFileExist.Substring(0, errorFileExist.Length - 1), "Ошибка");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Главный процесс, который объединяет все файлы
        /// </summary>
        private void MergeFiles()
        {
            string fullSaveFileName = String.Empty;
            if (!(String.IsNullOrEmpty(tbDestinationDirectory.Text) || String.IsNullOrEmpty(tbDestinationFileName.Text)))
            {
                fullSaveFileName = Path.Combine(tbDestinationDirectory.Text,tbDestinationFileName.Text);
            }

            //Объекты для работы с объектами офиса
            Object oMissing = System.Reflection.Missing.Value;
            Object oBreak;
            Object oTrue = true;
            Object oFalse = false;

            switch (separatorIndex)
            {
                case 1:
                    oBreak = Word.WdBreakType.wdPageBreak;
                    break;
                case 2:
                    oBreak = Word.WdBreakType.wdColumnBreak;
                    break;
                case 3:
                    oBreak = Word.WdBreakType.wdTextWrappingBreak;
                    break;
                case 4:
                    oBreak = Word.WdBreakType.wdSectionBreakNextPage;
                    break;
                case 5:
                    oBreak = Word.WdBreakType.wdSectionBreakContinuous;
                    break;
                case 6:
                    oBreak = Word.WdBreakType.wdSectionBreakEvenPage;
                    break;
                case 7:
                    oBreak = Word.WdBreakType.wdSectionBreakOddPage;
                    break;

                default:
                    oBreak = Word.WdBreakType.wdLineBreak;
                    break;
            }
            
            if (typeFileIndex == 0)
            {
                //Microsoft Office Word

                //Проверим а все ли файлы удовлетворяют требованиям по объединению
                if (!CheckFiles(fileExtensionSupport))
                    return;

                //Создаем объекты: приложение Word и документ
                Word._Application oWord = new Word.Application();
                Word._Document oWordDoc = new Word.Document();
                //Установим документ в состояние невидимости
                oWord.Visible = false;
                //Добавим новый документ
                oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                string fullFileName;
                int count = dgvFiles.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    if (bool.Parse(dgvFiles.Rows[i].Cells[0].Value.ToString()))
                    {
                        fullFileName = Path.Combine(dgvFiles.Rows[i].Cells[1].Value.ToString(), dgvFiles.Rows[i].Cells[2].Value.ToString() + dgvFiles.Rows[i].Cells[3].Value.ToString());
                        if(File.Exists(fullFileName) && Directory.Exists(dgvFiles.Rows[i].Cells[1].Value.ToString()))
                        {
                            //Вставим файл в новый документ
                            oWord.Selection.InsertFile(fullFileName, ref oMissing, ref oFalse, ref oFalse, ref oFalse);
                            if ((i != count - 1) && (!oBreak.Equals(Word.WdBreakType.wdLineBreak)))
                            {
                                oWord.Selection.InsertBreak(ref oBreak);
                            }
                        }
                    }
                }

                //Зачистим верхние и нижние колонтитулы
                foreach (Word.Section wordSection in oWordDoc.Sections)
                {
                    wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                    wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Delete();
                }
            
                if (!String.IsNullOrEmpty(fullSaveFileName))
                {
                    Object oFullSaveFileName = (Object)fullSaveFileName;
                    //Сохраним файл
                    oWordDoc.SaveAs(ref oFullSaveFileName, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                    //Закроем файл
                    oWordDoc.Close(ref oFalse, ref oMissing, ref oMissing);
                    //Выйдем из приложения
                    oWord.Quit(ref oMissing, ref oMissing, ref oMissing);
                }
                else
                    //Установим документ в состояние видимости
                    oWord.Visible = true;
            }
            else if (typeFileIndex == 1)
            {
                //Microsoft Office Excel

                //Проверим а все ли файлы удовлетворяют требованиям по объединению
                if (!CheckFiles(fileExtensionSupport))
                    return;
                
                //Создаем объекты: приложение Excel и документ
                Excel.Application oExcel = new Excel.Application();
                Excel.Workbook oExcelWorkbook, oExcelWorkbookSource;
                
                oExcel.Visible = false;
                oExcel.DisplayAlerts = false;
                oExcel.SheetsInNewWorkbook = 1;
                oExcel.Workbooks.Add(oMissing);
                oExcelWorkbook = oExcel.Workbooks[1];

                string fullFileName;
                int count = dgvFiles.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (bool.Parse(dgvFiles.Rows[i].Cells[0].Value.ToString()))
                    {
                        fullFileName = Path.Combine(dgvFiles.Rows[i].Cells[1].Value.ToString(), dgvFiles.Rows[i].Cells[2].Value.ToString() + dgvFiles.Rows[i].Cells[3].Value.ToString());
                        if (File.Exists(fullFileName) && Directory.Exists(dgvFiles.Rows[i].Cells[1].Value.ToString()))
                        {
                            //откроем файл источник
                            oExcelWorkbookSource = oExcel.Workbooks.Open(fullFileName,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                              Type.Missing, Type.Missing);

                            oExcelWorkbookSource.Sheets.Copy(oMissing, oExcelWorkbook.Sheets[oExcelWorkbook.Sheets.Count]);
                            //закроем файл источник
                            oExcelWorkbookSource.Close(oFalse, oMissing, oMissing);
                        }
                    }
                }
                if (oExcelWorkbook.Sheets.Count > 1)
                {
                    ((Excel.Worksheet) oExcelWorkbook.Worksheets[1]).Delete();
                }

                if (!String.IsNullOrEmpty(fullSaveFileName))
                {
                    oExcel.DisplayAlerts = true;
                    Object oFullSaveFileName = (Object)fullSaveFileName;
                    //Сохраним файл
                    oExcelWorkbook.SaveAs(oFullSaveFileName, oMissing, oMissing, oMissing,
                    oMissing, oMissing, Excel.XlSaveAsAccessMode.xlNoChange, oMissing, oMissing,
                    oMissing, oMissing, oMissing);
                    //Закроем файл
                    oExcelWorkbook.Close(oFalse, oMissing, oMissing);
                    //Выйдем из приложения
                    oExcel.Quit();
                }
                else
                {
                    //Установим документ в состояние видимости
                    oExcel.Visible = true;
                    oExcel.DisplayAlerts = true;
                
                }
            }
            else
                //None
                return;
        }

        /// <summary>
        /// Выбор имени файла и директории для сохранения файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseDestinationFileName_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = fileExtensionSupportDescribe + "|" + fileExtensionSupport;
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullFileName = saveFileDialog.FileName;
                tbDestinationDirectory.Text = Path.GetDirectoryName(fullFileName);
                tbDestinationFileName.Text = Path.GetFileNameWithoutExtension(fullFileName) + " " + DateTime.Now.ToString("ddMMyyyy") + Path.GetExtension(fullFileName);
            }
        }

        /// <summary>
        /// Закрытие окна программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseProgram_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Показать окно о программе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        /// <summary>
        /// Добавить файл в список файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            //openFileDialog.Filter = "Microsoft Office Word (*.doc,*.docx)|*.doc;*.docx|Microsoft Office Excel (*.xls, *.xlsx)|*.xls;*.xlsx|All Support Files (*.doc,*.docx, *.xls, *.xlsx)|*.doc;*.docx;*.xls;*.xlsx";
            openFileDialog.Filter = fileExtensionSupportDescribe + "|" + fileExtensionSupport;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    try
                    {
                        string[] rows = { "true", Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file), Path.GetExtension(file) };
                        dgvFiles.Rows.Add(rows);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Удалить файл из списка файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvFiles.SelectedRows)
            {
                dgvFiles.Rows.Remove(dgvr);
            }
        }

        /// <summary>
        /// Перевыбрали данные в элементе ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            switch (comboBox.Name)
            {
                case "cbTypeFile":
                    typeFileIndex = comboBox.SelectedIndex;
                    if (typeFileIndex == 1)
                    {
                        //fileExtensionSupport = "*.xlsx; *.xlsm; *.xltx; *.xltm; *.xls; *.xlt; *.htm; *.html; *.txt; *.xml; *.prn; *.tsv; *.ods; *.csv";
                        fileExtensionSupport = "*.xlsx; *.xlsm; *.xltx; *.xltm; *.xls; *.xlt";//для работы с *.tsv; *.ods; *.csv надо переделывать обработку слияния!
                        fileExtensionSupportDescribe = "Все файлы Excel (" + fileExtensionSupport + ")";
                        cbSeparator.Enabled = false;
                    }
                    else if (typeFileIndex == 0)
                    {
                        fileExtensionSupport = "*.docx; *.docm; *.dotx; *.dotm; *.doc; *.doct; *.htm; *.html; *.rtf; *.mht; *.mhtml; *.xml; *.odt; *.txt";
                        fileExtensionSupportDescribe = "Все файлы Word (" + fileExtensionSupport + ")";
                        cbSeparator.Enabled = true;
                    }
                    else
	                {
                        fileExtensionSupport = "";
                        fileExtensionSupportDescribe = "";
                        
	                }

                    break;
                case "cbSeparator":
                    separatorIndex = comboBox.SelectedIndex;
                    break;
                default:
                    break;
            }
            
        }

        private void buttonChangeOrderFiles_Click(object sender, EventArgs e)
        {
            //Если выделено более 1 строки то выходим
            if (dgvFiles.SelectedRows.Count > 1)
                return;

            Button button = (Button) sender;
            int indexToChange, indexFromChange = dgvFiles.CurrentRow.Index, count = dgvFiles.Rows.Count;
            int indexColumn;
            
            if ((dgvFiles.CurrentRow == null) ||
                ((indexFromChange == count - 1 && button.Name.Equals("btDown")) ||
                    (indexFromChange == 0 && button.Name.Equals("btUp"))))
                return;
            indexColumn = dgvFiles.CurrentCell.ColumnIndex;

            DataGridViewRow tempToChange, tempFromChange;
            
            switch (button.Name)
            {
                case "btUp":
                    indexToChange = indexFromChange - 1;
                    break;
                case "btDown":
                    indexToChange = indexFromChange + 1;
                    break;
                default:
                    indexToChange = indexFromChange;
                    break;
            }
            tempFromChange = dgvFiles.Rows[indexFromChange];
            tempToChange = dgvFiles.Rows[indexToChange];
            
            dgvFiles.Rows.Remove(tempFromChange);
            dgvFiles.Rows.Remove(tempToChange);
            if (indexToChange < indexFromChange)
            {
                dgvFiles.Rows.Insert(indexToChange, tempFromChange);
                dgvFiles.Rows.Insert(indexFromChange, tempToChange);                
            }
            else
            {
                dgvFiles.Rows.Insert(indexFromChange, tempToChange);
                dgvFiles.Rows.Insert(indexToChange, tempFromChange);               
            }

            dgvFiles.FirstDisplayedScrollingRowIndex = indexToChange;
            dgvFiles.CurrentCell = dgvFiles.Rows[indexToChange].Cells[0];
            dgvFiles.Rows[indexToChange].Selected = true;
        }


        public void SaveToXMLDocument(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xml_declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", String.Empty);
            XmlElement element, root = xmlDoc.CreateElement("root");
            XmlNode elementMaster;
            XmlAttribute attribute;

            xmlDoc.AppendChild(root);
            xmlDoc.InsertBefore(xml_declaration, root);

            element = xmlDoc.CreateElement("TYPE_FILE");
            element.InnerText = cbTypeFile.SelectedIndex.ToString();
            root.AppendChild(element);

            element = xmlDoc.CreateElement("SEPARATOR");
            element.InnerText = cbSeparator.SelectedIndex.ToString();
            root.AppendChild(element);

            element = xmlDoc.CreateElement("DEST_FILE_DIRECTORY");
            element.InnerText = tbDestinationDirectory.Text;
            root.AppendChild(element);

            element = xmlDoc.CreateElement("DEST_FILE_NAME");
            element.InnerText = tbDestinationFileName.Text;
            root.AppendChild(element);

            elementMaster = xmlDoc.CreateElement("FILE_LIST");
            root.AppendChild(elementMaster);

            foreach (DataGridViewRow dgvr in dgvFiles.Rows)
            {
                element = xmlDoc.CreateElement("FILE");
                
                attribute = xmlDoc.CreateAttribute("check");
                attribute.Value = dgvr.Cells[0].Value.ToString();
                element.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("fileDirectory");
                attribute.Value = dgvr.Cells[1].Value.ToString();
                element.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("fileName");
                attribute.Value = dgvr.Cells[2].Value.ToString();
                element.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("fileExtension");
                attribute.Value = dgvr.Cells[3].Value.ToString();
                element.Attributes.Append(attribute);
                
                elementMaster.AppendChild(element);
            }

            xmlDoc.Save(fileName);
        }


        public void ReadFromXMLDocument(string fileName)
        {
            Files file = new Files();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);

            settingsApp = new Settings();
            foreach (XmlNode task in xmlDoc.DocumentElement.ChildNodes)
            {
                if (task.Name == "TYPE_FILE")
                    settingsApp.typeFileIndex = int.Parse(task.InnerText);
                else if (task.Name == "SEPARATOR")
                    settingsApp.separatorIndex = int.Parse(task.InnerText);
                else if (task.Name == "DEST_FILE_DIRECTORY")
                    settingsApp.destinationFileDirectory = task.InnerText;
                else if (task.Name == "DEST_FILE_NAME")
                    settingsApp.destinationFileName = task.InnerText;
                else if (task.Name == "FILE_LIST")
                {
                    foreach (XmlNode param in task.ChildNodes)
                    {
                        if (param.Name == "FILE")
                        {
                            file.check = bool.Parse(param.Attributes.GetNamedItem("check").Value);
                            file.fileDirectory = param.Attributes.GetNamedItem("fileDirectory").Value;
                            file.fileName = param.Attributes.GetNamedItem("fileName").Value;
                            file.fileExtension = param.Attributes.GetNamedItem("fileExtension").Value;
                            settingsApp.files.Add(file);
                        }
                    }
                }
            }
        }

        public struct Files
        {
            public bool check;
            public string fileDirectory;
            public string fileName;
            public string fileExtension;
        }

        public class Settings
        {
            public int typeFileIndex;
            public int separatorIndex;
            public string destinationFileDirectory;
            public string destinationFileName;
            public List<Files> files;

            public Settings()
            {
                this.destinationFileDirectory = "";
                this.destinationFileName = "";
                this.files = new List<Files>();
                this.separatorIndex = 0;
                this.typeFileIndex = 0;
            }
        }

        private void tsmiSettingsSave_Click(object sender, EventArgs e)
        {
            if (dgvFiles.Rows.Count == 0)
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "settings.xml";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Filter = "XML Settings (*.xml)|*.xml";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToXMLDocument(saveFileDialog.FileName);
            }
            
        }

        private void tsmiSettingsLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "settings.xml";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "XML Settings (*.xml)|*.xml";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ReadFromXMLDocument(openFileDialog.FileName);
                
                dgvFiles.Rows.Clear();
                cbTypeFile.SelectedIndex = settingsApp.typeFileIndex;
                cbSeparator.SelectedIndex = settingsApp.separatorIndex;
                tbDestinationDirectory.Text = settingsApp.destinationFileDirectory;
                tbDestinationFileName.Text = settingsApp.destinationFileName;

                foreach (Files f in settingsApp.files)
                {
                    dgvFiles.Rows.Add(f.check, f.fileDirectory, f.fileName, f.fileExtension);
                }
            }
            
        }

        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFiles.RowCount == 0)
                return;
            dgvFiles.Rows[e.RowIndex].Cells[0].Value = (object) !bool.Parse(dgvFiles.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dgvFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgvFiles.RowCount == 0)
                return;
            
            if (Keys.Space == e.KeyData)
            {
                foreach(DataGridViewRow dgvr in dgvFiles.SelectedRows)
                {
                    dgvr.Cells[0].Value = (object)!bool.Parse(dgvr.Cells[0].Value.ToString());
                }
                e.Handled = true;
            }
        }

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFiles.RowCount == 0)
                return;

            if (e.ColumnIndex == 0)
                dgvFiles.Rows[e.RowIndex].Cells[0].Value = (object)!bool.Parse(dgvFiles.Rows[e.RowIndex].Cells[0].Value.ToString());   
        }

        private void tsmiMarkAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvFiles.Rows)
                dgvr.Cells[0].Value = true;
        }

        private void tsmiUnmarkAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dgvFiles.Rows)
                dgvr.Cells[0].Value = false;
        }
    }
}
