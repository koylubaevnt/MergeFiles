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


namespace MergeFiles
{
    public partial class frmMain : Form
    {
        enum FileType { WORD, EXCEL }
        
        public frmMain()
        {
            InitializeComponent();

            cbTypeFile.Items.Add(FileType.WORD);
            cbTypeFile.Items.Add(FileType.EXCEL);
            cbTypeFile.SelectedIndex = 0;

            cbSeparator.Items.Add("Нет разрыва");                           //?
            cbSeparator.Items.Add("Разрыв страниц: Страница");              //wdPageBreak
            cbSeparator.Items.Add("Разрыв страниц: Колонка");               //wdColumnBreak
            cbSeparator.Items.Add("Разрыв страниц: Обтекание текстом");     //wdTextWrappingBreak
            cbSeparator.Items.Add("Разрыв раздела: Следующая страница");    //wdSectionBreakNextPage
            cbSeparator.Items.Add("Разрыв раздела: Текущая страница");      //wdSectionBreakContinuous
            cbSeparator.Items.Add("Разрыв раздела: Четная страница");       //wdSectionBreakEvenPage
            cbSeparator.Items.Add("Разрыв раздела: Нечетная страница");     //wdSectionBreakOddPage
            cbSeparator.SelectedIndex = 0;
            /*
            wdLineBreak
            wdLineBreakClearLeft
            wdLineBreakClearRight
            */
            
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

        /// <summary>
        /// Главный процесс, который объединяет все файлы
        /// </summary>
        private void MergeFiles()
        {
            //Работаем только с выделенными файлами!
            //1. проверим, что все файлы имеют одинаковое расширение
            //1.1. если нет - выводим сообщение об ошибке и выходим
            //1.2. если существуют идем дальше
            //2. проверим, что пути и файлы существуют
            //2.1. если нет - выводим сообщение об ошибке и выходим
            //2.2. если существуют идем дальше
            //3. создаем новый документ с нужным типом
            //4. копируем содержимое каждого файла и разделяем его используя выбранный разделитель

            if (tbDestinationDirectory.Text.Length <= 0 || tbDestinationFileName.Text.Length <= 0)
            {
                MessageBox.Show("Вы не выбрали путь или имя файла для сохранения!", "Ошибка");
                return;
            }

            string fileExtension;
            switch (cbTypeFile.SelectedIndex)
            {
                case 0:
                    fileExtension = "*.doc; *.docx";
                    break;
                case 1:
                    fileExtension = "*.xls; *.xlsx";
                    break;
                
                default:
                    fileExtension = "";
                    break;
            }
            
            int count = dgvFiles.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (dgvFiles.Rows[i].Cells[0].Value.ToString().ToLower() == "true")
                {
                    if (!fileExtension.Contains(dgvFiles.Rows[i].Cells[3].Value.ToString()))
                    {
                        MessageBox.Show("Тип файла не соотвествует расширению файла в списке!", "Ошибка");
                        return;
                    }
                }
            }
            //OBJECT OF MISSING "NULL VALUE"
            Object oMissing = System.Reflection.Missing.Value;
            Object oBreak;
            switch (cbSeparator.SelectedIndex)
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

            
                            
            //OBJECTS OF FALSE AND TRUE
            Object oTrue = true;
            Object oFalse = false;

            //CREATING OBJECTS OF WORD AND DOCUMENT
            Word._Application oWord = new Word.Application();
            Word._Document oWordDoc = new Word.Document();

            //MAKING THE APPLICATION NON VISIBLE
            oWord.Visible = false;
            //ADDING A NEW DOCUMENT TO THE APPLICATION
            oWordDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            string fullFileName;
            for (int i = 0; i < count; i++)
            {
                if (dgvFiles.Rows[i].Cells[0].Value.ToString().ToLower() == "true")
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
            
            //MAKING THE APPLICATION NON VISIBLE
            oWord.Visible = true;
            
        }

        /// <summary>
        /// Выбор имени файла и директории для сохранения файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseDestinationFileName_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "WORD 2003 (*.doc)|*.doc|WORD 2007/2010(*.docx)|*.docx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullFileName = saveFileDialog.FileName;
                tbDestinationDirectory.Text = Path.GetDirectoryName(fullFileName);
                tbDestinationFileName.Text = Path.GetFileNameWithoutExtension(fullFileName) + " " + DateTime.Now.ToString("ddMMyyyy") + Path.GetExtension(fullFileName);
            }
            else
            {
                tbDestinationDirectory.Text = "";
                tbDestinationFileName.Text = "";
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

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Word 2003 (*.doc)|*.doc|Word 2007/2010(*.docx)|*.docx";
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
            if (dgvFiles.Rows.Count > 0)
                dgvFiles.Rows.RemoveAt(dgvFiles.CurrentRow.Index);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        
    }
}
