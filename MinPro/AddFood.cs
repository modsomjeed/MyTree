using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FoodsAndDrink;
using System.IO;
namespace MinPro
{
    public partial class AddFood : Form
    {
        public AddFood()
        {
            InitializeComponent();
        }

        private void AddFood_Load(object sender, EventArgs e)
        {

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
           try
                {
                    MainForm.Food.add(FoodNameBox.Text, float.Parse(PriceBox.Text), ++MainForm.codeFood,0);
                    StreamWriter wr = new StreamWriter("ListFood.txt", true);
                    wr.WriteLine(FoodNameBox.Text);
                    wr.WriteLine(PriceBox.Text);
                    wr.WriteLine(MainForm.codeFood);
                    wr.WriteLine("0");
                    wr.Close();
                    MainForm.ListNameFood = MainForm.Food.toArray(Foods.Traversal.Preorder, 1);
                    MainForm.ListPriceFood = MainForm.Food.toArray(Foods.Traversal.Preorder, 2);
                    MainForm.ListCode = MainForm.Food.toArray(Foods.Traversal.Preorder, 3);
                    MainForm.ListFreq = MainForm.Food.toArray(Foods.Traversal.Postorder, 4);
                    this.Close();
                }
                catch { MessageBox.Show("Please input data again"); FoodNameBox.Clear(); PriceBox.Clear(); }
           
        }


    }
}
