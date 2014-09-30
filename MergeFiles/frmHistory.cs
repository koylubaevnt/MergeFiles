using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MergeFiles
{
    public partial class frmHistory : Form
    {
        public frmHistory()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            lblHis.Text = "История версий программы " + Application.ProductVersion;
        }
    }
}
