using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinPro
{
    public partial class ConfirmExit : Form
    {
        public ConfirmExit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.Confirmexit = true;
            this.Close();
        }

        private void No_Click(object sender, EventArgs e)
        {
            MainForm.Confirmexit = false;
            this.Close();
        }

        private void ConfirmExit_Load(object sender, EventArgs e)
        {

        }
    }
}
