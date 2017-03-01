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
    public partial class UpdateStatus : Form
    {
        bool iscontain;
        int indexnow, indexold;
        object numnew;
        public UpdateStatus()
        {
            InitializeComponent();
        }

        private void UpdateStatus_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            textBox1.Clear();
            button1.Enabled = false;
            indexnow = 0;
            indexold = 0;
            numnew = new object();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (iscontain&&comboBox1.SelectedIndex!=-1)
            {
                MainForm.Listorder[indexnow].status = comboBox1.SelectedItem.ToString();
                MainForm.Listorder[indexnow].time = DateTime.Now.TimeOfDay.ToString();
                iscontain = false;
                this.Close();
            }
            else { MessageBox.Show(" ID นี้ ไม่ได้ สั่งรายการอาหาร"); }
        }
        
        private int IndexOf(object e)
        {            
            
            for (int i = indexold ; i < MainForm.Size_order; i++)
            {
               
                if (int.Parse(e.ToString()).Equals(MainForm.Listorder[i].CustomerId))
                {
                    if (indexold == indexnow && i == 0) { indexold = i + 1; indexnow = i; return i; }
                    else { indexold = i + 1; indexnow = i; return i; }
                } 
            }
            return -1;
        }
       
        private void Findbutton_Click(object sender, EventArgs e)
        {
            if (!numnew.Equals(textBox1.Text)) { numnew = textBox1.Text; indexold = 0; indexnow = 0; }
            int i=IndexOf(textBox1.Text);
            if (i != -1)
            {
                label2.Text = MainForm.Listorder[i].CustomerId + "          "
                    + MainForm.data_using.name + "\n" + MainForm.Listorder[i].List + "Total";
                label3.Text = MainForm.Listorder[i].Prices.ToString();
                label4.Text = MainForm.Listorder[i].time.ToString();
                if (MainForm.Listorder[i].status.Equals("Ready")) comboBox1.SelectedIndex = 0;
                if (MainForm.Listorder[i].status.Equals("Deliveried")) comboBox1.SelectedIndex = 1;
                if (MainForm.Listorder[i].status.Equals("Close")) comboBox1.SelectedIndex = 2;
                iscontain = true;
            }
            else
            {
                MessageBox.Show(" ID นี้ ไม่ได้ สั่งรายการอาหาร หรือ สั่งรายการแค่นี้ ");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                button1.Enabled = true;
            }
            else button1.Enabled = false;
        }

      

      
     
    
     
    }
}
