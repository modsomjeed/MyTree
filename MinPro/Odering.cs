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
using System.IO;
using Order;
namespace MinPro
{
    public partial class Odering : Form
    {
        ListViewItem listAll, ListSelectgoods;

        float totalPrice;
        public Odering()
        {
            InitializeComponent();
        }
        private void AddFoodinListView()
        {
            listView1.Items.Clear();
            for (int i = MainForm.Food.size() - 1; i > -1; i--)
            {

                listAll = new ListViewItem(MainForm.ListCode[i].ToString());
                listAll.SubItems.Add(MainForm.ListNameFood[i].ToString());
                listAll.SubItems.Add(MainForm.ListPriceFood[i].ToString());
                listView1.Items.Add(listAll);
            }
        }
        private void Odering_Load(object sender, EventArgs e)
        {
            OK.Enabled = false;
            listView2.Items.Clear();
            customername.Text = MainForm.data_using.name; customername.Enabled = false;
            idbox.Text = MainForm.data_using.PhoneID.ToString(); idbox.Enabled = false;

            AddFoodinListView();
            totalPrice = 0;
            TotalPrice.Text = totalPrice.ToString();
        }

        private void OK_Click(object sender, EventArgs e)
        {

            object  bill = "";
            object price = "Baht\n";
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                bill += "   " + listView2.Items[i].SubItems[1].Text + " \n";
                price += listView2.Items[i].SubItems[2].Text + "\n";
            }

            price = "" + price + TotalPrice.Text;
            MainForm.Listorder[MainForm.Size_order].CustomerId = MainForm.data_using.PhoneID;
            MainForm.Listorder[MainForm.Size_order].List = bill;
            MainForm.Listorder[MainForm.Size_order].time = DateTime.Now.TimeOfDay.ToString();
            MainForm.Listorder[MainForm.Size_order].Prices = price;
            MainForm.Listorder[MainForm.Size_order].status = "Ready";
            MainForm.Listorder[MainForm.Size_order].Name = MainForm.data_using.name;
            MainForm.Listorder[MainForm.Size_order].Address = MainForm.data_using.Address;
            MainForm.Listorder[MainForm.Size_order++].PriceAll = float.Parse(TotalPrice.Text);

                        this.Close();

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            AddFoodinListView();
            for (int i = listView1.Items.Count - 1; -1 < i; --i)
            {
                if (listView1.Items[i].SubItems[1].Text.Contains(searchbox.Text) == false
                      && listView1.Items[i].SubItems[1].Text.ToLower().Contains(searchbox.Text.ToLower()) == false)
                {
                    listView1.Items[i].Remove();
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {

            try
            {
                ListSelectgoods = new ListViewItem(listView1.SelectedItems[0].SubItems[0].Text);
                ListSelectgoods.SubItems.Add(listView1.SelectedItems[0].SubItems[1].Text);
                ListSelectgoods.SubItems.Add(listView1.SelectedItems[0].SubItems[2].Text);
                //object s = listView1.SelectedItems[0].SubItems[1].Text;
                //  float price = float.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                listView2.Items.Add(ListSelectgoods);

                totalPrice += float.Parse(listView1.SelectedItems[0].SubItems[2].Text);

                TotalPrice.Text = totalPrice.ToString();
                OK.Enabled = true;
            }
            catch { MessageBox.Show("Please select Food"); }
        }


        private void remove_Click(object sender, EventArgs e)
        {
            try
            {

                totalPrice -= float.Parse(listView2.SelectedItems[0].SubItems[2].Text);
                listView2.SelectedItems[0].Remove();
            }
            catch { }
            if (listView2.Items.Count == 0) OK.Enabled = false;
            TotalPrice.Text = totalPrice.ToString();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            OK.Enabled = false;
            listView2.Items.Clear();
            totalPrice = 0;
            TotalPrice.Text = totalPrice.ToString();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            totalPrice = 0;
            TotalPrice.Text = totalPrice.ToString();
            this.Close();
        }

        private void codebox_TextChanged(object sender, EventArgs e)
        {
            AddFoodinListView();
            for (int i = listView1.Items.Count - 1; -1 < i; --i)
            {
                if (listView1.Items[i].SubItems[0].Text.Contains(codebox.Text) == false)
                {
                    listView1.Items[i].Remove();
                }
            }
        }


    }
}
