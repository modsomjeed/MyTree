namespace MinPro
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.NewCusbutton = new System.Windows.Forms.Button();
            this.Refreshbutton = new System.Windows.Forms.Button();
            this.FindCustButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewFood = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // NewCusbutton
            // 
            this.NewCusbutton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.NewCusbutton.Location = new System.Drawing.Point(30, 12);
            this.NewCusbutton.Name = "NewCusbutton";
            this.NewCusbutton.Size = new System.Drawing.Size(124, 38);
            this.NewCusbutton.TabIndex = 0;
            this.NewCusbutton.Text = "New Customer";
            this.NewCusbutton.UseVisualStyleBackColor = false;
            this.NewCusbutton.Click += new System.EventHandler(this.NewCusbutton_Click);
            // 
            // Refreshbutton
            // 
            this.Refreshbutton.Location = new System.Drawing.Point(354, 359);
            this.Refreshbutton.Name = "Refreshbutton";
            this.Refreshbutton.Size = new System.Drawing.Size(116, 40);
            this.Refreshbutton.TabIndex = 1;
            this.Refreshbutton.Text = "Refresh";
            this.Refreshbutton.UseVisualStyleBackColor = true;
            this.Refreshbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FindCustButton
            // 
            this.FindCustButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.FindCustButton.Location = new System.Drawing.Point(194, 12);
            this.FindCustButton.Name = "FindCustButton";
            this.FindCustButton.Size = new System.Drawing.Size(124, 38);
            this.FindCustButton.TabIndex = 2;
            this.FindCustButton.Text = "Find Customer";
            this.FindCustButton.UseVisualStyleBackColor = false;
            this.FindCustButton.Click += new System.EventHandler(this.FindCustButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNo,
            this.columnCustomer,
            this.columnOrder,
            this.columnPrice,
            this.columnTime,
            this.columnStatus});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(30, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(613, 297);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnNo
            // 
            this.columnNo.Text = "ID";
            this.columnNo.Width = 82;
            // 
            // columnCustomer
            // 
            this.columnCustomer.Text = "Customer";
            this.columnCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCustomer.Width = 123;
            // 
            // columnOrder
            // 
            this.columnOrder.Text = "List Order";
            this.columnOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnOrder.Width = 181;
            // 
            // columnPrice
            // 
            this.columnPrice.Text = "Price";
            this.columnPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnPrice.Width = 66;
            // 
            // columnTime
            // 
            this.columnTime.Text = "Time";
            this.columnTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnTime.Width = 70;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnStatus.Width = 89;
            // 
            // NewFood
            // 
            this.NewFood.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.NewFood.Location = new System.Drawing.Point(355, 12);
            this.NewFood.Name = "NewFood";
            this.NewFood.Size = new System.Drawing.Size(124, 38);
            this.NewFood.TabIndex = 4;
            this.NewFood.Text = "New Food";
            this.NewFood.UseVisualStyleBackColor = false;
            this.NewFood.Click += new System.EventHandler(this.NewFood_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Location = new System.Drawing.Point(519, 361);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 38);
            this.button4.TabIndex = 10;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button6.Location = new System.Drawing.Point(519, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 38);
            this.button6.TabIndex = 8;
            this.button6.Text = "Update And Check Order";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chartreuse;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(674, 433);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.NewFood);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.FindCustButton);
            this.Controls.Add(this.Refreshbutton);
            this.Controls.Add(this.NewCusbutton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewCusbutton;
        private System.Windows.Forms.Button Refreshbutton;
        private System.Windows.Forms.Button FindCustButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button NewFood;
        private System.Windows.Forms.ColumnHeader columnNo;
        private System.Windows.Forms.ColumnHeader columnCustomer;
        private System.Windows.Forms.ColumnHeader columnOrder;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.ColumnHeader columnPrice;
        private System.Windows.Forms.ColumnHeader columnTime;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer1;
    }
}

