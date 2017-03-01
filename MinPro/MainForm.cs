using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MyTree;
using Table;
using FoodsAndDrink;
using System.IO;
using Order;
namespace MinPro
{
    public partial class MainForm : Form
    {
        public static AddNewCustomerForm addnewcustomer;
        public static FindCustomer findcustumer;
        public static ListViewItem lvi;
        public static Odering order;
        public static ConfirmExit confirmexit;
        public static AddFood addfood;
        public static UpdateStatus updatestatus;
        public static bool Confirmexit;
        public static bool isedit;
        public static bool isadd;
        public static HashTable table;
        public static BSTree.Node data_using;
        public static Foods Food;
        public static Foods.Node food_using;
        public static int codeFood;
        public static object[] ListNameFood, ListPriceFood, ListCode, ListFreq;
        public static object[] IDCustumer;
        public static Orders[] Listorder;
        public static int Size_order;
        
        public MainForm()
        {
            InitializeComponent();
            Confirmexit = false;
            addnewcustomer = new AddNewCustomerForm();
            table = new HashTable(13);
            addfood = new AddFood();
            findcustumer = new FindCustomer();
            order = new Odering();
            confirmexit = new ConfirmExit();
            updatestatus = new UpdateStatus();
            Food = new Foods();
            Listorder = new Orders[10];
            for (int i = 0; i < Listorder.Length; i++)
                Listorder[i] = new Orders();
            timer1.Start();
           LoadData();
          

        }
        private void Load_Food()
        { int count = 0;
            StreamReader read = new StreamReader("ListFood.txt");
            while (read.ReadLine() != null)
            {
                count++;
            } 
            read.Close();
            StreamReader rd = new StreamReader("ListFood.txt");
            for(int i=0;i<count/4;i++)
            {
                Food.add(rd.ReadLine(), float.Parse(rd.ReadLine()),codeFood=int.Parse(rd.ReadLine()),int.Parse(rd.ReadLine()));
            }
            rd.Close();
            ListCode = Food.toArray(BSTree.Traversal.Preorder, 3);
            ListNameFood = Food.toArray(BSTree.Traversal.Preorder, 1);
            ListPriceFood= Food.toArray(BSTree.Traversal.Preorder, 2);
            ListFreq = Food.toArray(BSTree.Traversal.Preorder, 4);
        }
        private void Load_customer()
       {
            
            for (int i = 0; i < IDCustumer.Length; i++ )
            {
                StreamReader read = new StreamReader(@"ListCustumer\" + IDCustumer[i].ToString() + ".txt");
                int ID = int.Parse(read.ReadLine()); // ID
                string name = read.ReadLine(); //ชื่อ
                string address = read.ReadLine(); // Address
                string detail = read.ReadLine(); // detail
                table.add(ID, name, address, detail);
                if (i + 1 >= IDCustumer.Length) read.Close();
            } 

        }
        private void NewCusbutton_Click(object sender, EventArgs e)
        {
            addnewcustomer.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListOrder();
        }

        private void FindCustButton_Click(object sender, EventArgs e)
        {
            findcustumer.ShowDialog();
        }
        public void ListOrder()
        {
            listView1.Items.Clear();
            for (int i = 0; i < Size_order; ++i)
            {
                lvi = new ListViewItem(Listorder[i].CustomerId.ToString());
                lvi.SubItems.Add(Listorder[i].Name.ToString());
                lvi.SubItems.Add(Listorder[i].List.ToString());
                lvi.SubItems.Add(Listorder[i].PriceAll.ToString());
                lvi.SubItems.Add(Listorder[i].time.ToString());
                lvi.SubItems.Add(Listorder[i].status.ToString());
                listView1.Items.Add(lvi);

            }

        }
        private void Exit_Click(object sender, EventArgs e)
        {

            this.Enabled = false;
            confirmexit.ShowDialog();
            if (Confirmexit) this.Close();
            else this.Enabled = true;
        }

        private void NewFood_Click(object sender, EventArgs e)
        {
            addfood.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updatestatus.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    
        public static void AddCustumer()
        {
            StreamWriter wr = new StreamWriter("Idcustomer.txt", true);
            wr.WriteLine(data_using.PhoneID.ToString());
            wr.Close();
        }
        private void LoadData()
        {
            int count = 0;
            StreamReader read = new StreamReader("Idcustomer.txt");
            while (read.ReadLine() != null)
            {
                count++;
            } 
            read.Close();
            StreamReader readcode = new StreamReader("Idcustomer.txt");
            IDCustumer = new object[count];
            int index = 0;
            string code;
            while ((code = readcode.ReadLine()) != null)
            {
                IDCustumer[index++] = int.Parse(code);
            } 
            readcode.Close();
            Load_customer();
            Load_Food();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Food Feed Delivery " + System.DateTime.Now.Day.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/"
                + System.DateTime.Now.Year.ToString() + "   "+ System.DateTime.Now.Hour.ToString() + " : " + System.DateTime.Now.Month.ToString()
                +" : "+System.DateTime.Now.Minute.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MainForm_Load(null, null);
            ListOrder();
        }
        private int IndexOf(object e)
        {

            for (int i = 0; i < MainForm.Size_order; i++)
            {
                if (int.Parse(e.ToString()).Equals(MainForm.Listorder[i].CustomerId))
                    return i;
            }
            return -1;
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           int d= listView1.SelectedItems[0].Index;
        }
        
    }
}
