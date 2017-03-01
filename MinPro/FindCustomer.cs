using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyTree;
using Table;
namespace MinPro
{
    public partial class FindCustomer : Form
    {

        public FindCustomer()
        {
            InitializeComponent();

        }

        private void orderbutton_Click(object sender, EventArgs e)
        {
            this.Close();
             MainForm.order.ShowDialog();

        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            MainForm.isedit = true;
            this.Enabled = false;
            MainForm.addnewcustomer.ShowDialog();
            this.Enabled = true;
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            MainForm.isadd = true;
            this.Enabled = false;
            MainForm.addnewcustomer.ShowDialog();
            this.Enabled = true;
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            MainForm.confirmexit.ShowDialog();
            if (MainForm.Confirmexit) { this.Close(); MainForm.Confirmexit = false; }
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            try
            {
                BSTree.Node node = MainForm.table.getDataNode(int.Parse(IDBox.Text));
                if (MainForm.table.contains(int.Parse(IDBox.Text)))
                {
                    orderbutton.Enabled = true;
                    editbutton.Enabled = true;
                    NameBox.Text = node.name;
                    label2.Text = node.Address;
                    label3.Text = node.Details;
                    MainForm.data_using = MainForm.table.getDataNode(int.Parse(IDBox.Text));
                   
                }
            }
            catch
            {
                MessageBox.Show(" Inputting is incorrect!");
                NameBox.Clear();
            }
           
        }

        private void FindCustomer_Load(object sender, EventArgs e)
        {
            NameBox.Clear();
            IDBox.Clear();
            addbutton.Enabled = false;
            editbutton.Enabled = false;
            orderbutton.Enabled = false;
            label2.Text = "";
            label3.Text = "";
        }

    }
}
