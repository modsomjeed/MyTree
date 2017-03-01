using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace MinPro
{
    public partial class AddNewCustomerForm : Form
    {

        public AddNewCustomerForm()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {

            if (!MainForm.isedit)
            {
                  try
                    {

                        string address = NotextBox.Text + " " + ApartmentBox.Text + " " + VillageBox.Text + " " + Soibox.Text + " " + StreetBox.Text + " " + SubdistBox.Text + " " + DistBox.Text + " " + ProvinceBox.Text;
                        MainForm.table.add(int.Parse(PhonetextBox.Text), Nametexbox.Text, address, DetailBox.Text);
                        MainForm.data_using = MainForm.table.getDataNode(int.Parse(PhonetextBox.Text));

                        MainForm.AddCustumer();

                        StreamWriter writer = new StreamWriter(@"ListCustumer\" + int.Parse(PhonetextBox.Text).ToString() + ".txt");
                        writer.WriteLine(int.Parse(PhonetextBox.Text));
                        writer.WriteLine(Nametexbox.Text);
                        writer.WriteLine(address);
                        writer.WriteLine(DetailBox.Text);
                        writer.Close();
                        this.Close();
                        Resetbutton_Click(null, null);
                        MainForm.order.ShowDialog();
                    }
                    catch { MessageBox.Show("Data is incorrect!"); }
            
            }
            else if (MainForm.isedit)
            {
                try
                {
                    string address = NotextBox.Text + " " + ApartmentBox.Text + " " + VillageBox.Text + " " + Soibox.Text + " " + StreetBox.Text + " " + SubdistBox.Text + " " + DistBox.Text + " " + ProvinceBox.Text;
                    MainForm.data_using.name = Nametexbox.Text;
                    MainForm.data_using.Address = address;
                    MainForm.data_using.Details = DetailBox.Text;
                    Resetbutton.Enabled = false;

                    StreamWriter writer = new StreamWriter(@"ListCustumer\"+int.Parse(PhonetextBox.Text).ToString() + ".txt");
                    writer.WriteLine(int.Parse(PhonetextBox.Text));
                    writer.WriteLine(Nametexbox.Text);
                    writer.WriteLine(address);
                    writer.WriteLine(DetailBox.Text);
                    writer.Close();
                    MainForm.isedit = false;
                    this.Close();
            Resetbutton_Click(null, null);
            MainForm.order.ShowDialog();

                }
                catch { MessageBox.Show("Data is incorrect!"); }
              
                
            }

            
           
        }

        private void Resetbutton_Click(object sender, EventArgs e)
        {
            PhonetextBox.Clear();
            Nametexbox.Clear();
            NotextBox.Clear();
            ApartmentBox.Clear();
            VillageBox.Clear();
            Soibox.Clear();
            StreetBox.Clear();
            SubdistBox.Clear();
            DistBox.Clear();
            ProvinceBox.Clear();
            DetailBox.Clear();

        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Resetbutton_Click(new object(), new EventArgs());
            this.Close();
        }

        private void AddNewCustomerForm_Load(object sender, EventArgs e)
        {
            if (MainForm.isedit || MainForm.isadd)
            {
                PhonetextBox.Text = MainForm.data_using.PhoneID.ToString();
                PhonetextBox.Enabled = false;
                Nametexbox.Text = MainForm.data_using.name;
                Resetbutton.Enabled = false;
            }

        }





    }
}
