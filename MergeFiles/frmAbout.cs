using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MergeFiles
{
    public partial class frmAbout : Form
    {
        #region Основные настройки
        private string _title = "О " + Application.ProductName;
        private string _productname = Application.ProductName;
        private string _version = "Версия " + Application.ProductVersion;
        private string _description = Application.ProductName + " - Программа для объединения нескольких текстовых файлов в один большой.";
        private string _license = Application.CompanyName + " ©  2014. Все права защищены.";
        private string _other = "Операционная система " + GetOSName() + " " + Environment.OSVersion.ServicePack + Environment.NewLine + "Компьютер " + Environment.MachineName + Environment.NewLine + "Пользователь " + Environment.UserName;
        #endregion 

        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Text = _title;
            lblProgName.Text = _productname;
            lblVersion.Text = _version;
            lblDescription.Text = _description;
            lblLicense.Text = _license;
            lblOS.Text = _other;
        }

        /// <summary>
        /// Получить версию операционки
        /// </summary>
        /// <returns></returns>
        private static string GetOSName()
        {
            OperatingSystem osInfo = Environment.OSVersion;
            string osName = "UNKNOWN";

            switch (osInfo.Platform)
            {
                case PlatformID.Win32Windows:
                    {
                        switch (osInfo.Version.Minor)
                        {
                            case 0:
                                {
                                    osName = "Windows 95";
                                    break;
                                }

                            case 10:
                                {
                                    if (osInfo.Version.Revision.ToString() == "2222A")
                                    {
                                        osName = "Windows 98 Second Edition";
                                    }
                                    else
                                    {
                                        osName = "Windows 98";
                                    }
                                    break;
                                }

                            case 90:
                                {
                                    osName = "Windows Me";
                                    break;
                                }
                        }
                        break;
                    }

                case PlatformID.Win32NT:
                    {
                        switch (osInfo.Version.Major)
                        {
                            case 3:
                                {
                                    osName = "Windows NT 3.51";
                                    break;
                                }

                            case 4:
                                {
                                    osName = "Windows NT 4.0";
                                    break;
                                }

                            case 5:
                                {
                                    if (osInfo.Version.Minor == 0)
                                    {
                                        osName = "Windows 2000";
                                    }
                                    else if (osInfo.Version.Minor == 1)
                                    {
                                        osName = "Windows XP";
                                    }
                                    else if (osInfo.Version.Minor == 2)
                                    {
                                        osName = "Windows Server 2003";
                                    }
                                    break;
                                }

                            case 6:
                                {
                                    osName = "Windows Vista";
                                    break;
                                }
                        }
                        break;
                    }
            }
            return osName;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Нажатие на ссылку "Сайт разработчиков"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://lineltd.net");         
        }

        /// <summary>
        /// Открытие окна "история версий"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmHistory frm = new frmHistory();
            frm.ShowDialog();
        }
    }
}
