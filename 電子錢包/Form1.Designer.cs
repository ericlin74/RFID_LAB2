namespace 電子錢包
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button2 = new Button();
            button1 = new Button();
            tbPoint = new TextBox();
            label4 = new Label();
            tbDate = new TextBox();
            label3 = new Label();
            tbName = new TextBox();
            label2 = new Label();
            tbID = new TextBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            button3 = new Button();
            tbPoints_DSP = new TextBox();
            label5 = new Label();
            tbDate_DSP = new TextBox();
            label6 = new Label();
            tbName_DSP = new TextBox();
            label7 = new Label();
            tbID_DSP = new TextBox();
            label8 = new Label();
            tabPage3 = new TabPage();
            lblPoints_Remark = new Label();
            button4 = new Button();
            tbPoints_Save = new TextBox();
            label9 = new Label();
            tabPage4 = new TabPage();
            tbTopUp_Value = new TextBox();
            cbAutoTopUp = new CheckBox();
            lblUsed_Remark = new Label();
            button5 = new Button();
            tbUsed_Points = new TextBox();
            label10 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(640, 423);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(tbPoint);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(tbDate);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(tbName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(tbID);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(632, 395);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "發卡";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(329, 127);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "清空卡片";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(329, 66);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "卡片製作";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbPoint
            // 
            tbPoint.ImeMode = ImeMode.Disable;
            tbPoint.Location = new Point(120, 167);
            tbPoint.MaxLength = 10;
            tbPoint.Name = "tbPoint";
            tbPoint.Size = new Size(100, 23);
            tbPoint.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 170);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 6;
            label4.Text = "點數：";
            // 
            // tbDate
            // 
            tbDate.Enabled = false;
            tbDate.Location = new Point(120, 128);
            tbDate.Name = "tbDate";
            tbDate.ReadOnly = true;
            tbDate.Size = new Size(100, 23);
            tbDate.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 131);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 4;
            label3.Text = "申請日期：";
            // 
            // tbName
            // 
            tbName.Location = new Point(120, 90);
            tbName.MaxLength = 16;
            tbName.Name = "tbName";
            tbName.Size = new Size(100, 23);
            tbName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 93);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 2;
            label2.Text = "姓名：";
            // 
            // tbID
            // 
            tbID.ImeMode = ImeMode.Disable;
            tbID.Location = new Point(120, 49);
            tbID.MaxLength = 16;
            tbID.Name = "tbID";
            tbID.Size = new Size(99, 23);
            tbID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 52);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "會員編號：";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(tbPoints_DSP);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(tbDate_DSP);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(tbName_DSP);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(tbID_DSP);
            tabPage2.Controls.Add(label8);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(632, 395);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "查詢";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(288, 73);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "讀取卡片";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tbPoints_DSP
            // 
            tbPoints_DSP.ImeMode = ImeMode.Disable;
            tbPoints_DSP.Location = new Point(110, 159);
            tbPoints_DSP.MaxLength = 16;
            tbPoints_DSP.Name = "tbPoints_DSP";
            tbPoints_DSP.ReadOnly = true;
            tbPoints_DSP.Size = new Size(100, 23);
            tbPoints_DSP.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 162);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 16;
            label5.Text = "點數：";
            // 
            // tbDate_DSP
            // 
            tbDate_DSP.Enabled = false;
            tbDate_DSP.Location = new Point(110, 120);
            tbDate_DSP.Name = "tbDate_DSP";
            tbDate_DSP.ReadOnly = true;
            tbDate_DSP.Size = new Size(100, 23);
            tbDate_DSP.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 123);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 14;
            label6.Text = "申請日期：";
            // 
            // tbName_DSP
            // 
            tbName_DSP.Location = new Point(110, 82);
            tbName_DSP.MaxLength = 16;
            tbName_DSP.Name = "tbName_DSP";
            tbName_DSP.ReadOnly = true;
            tbName_DSP.Size = new Size(100, 23);
            tbName_DSP.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 85);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 12;
            label7.Text = "姓名：";
            // 
            // tbID_DSP
            // 
            tbID_DSP.ImeMode = ImeMode.Disable;
            tbID_DSP.Location = new Point(110, 41);
            tbID_DSP.MaxLength = 16;
            tbID_DSP.Name = "tbID_DSP";
            tbID_DSP.ReadOnly = true;
            tbID_DSP.Size = new Size(99, 23);
            tbID_DSP.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(37, 44);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 10;
            label8.Text = "會員編號：";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(lblPoints_Remark);
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(tbPoints_Save);
            tabPage3.Controls.Add(label9);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(632, 395);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "儲值";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblPoints_Remark
            // 
            lblPoints_Remark.AutoSize = true;
            lblPoints_Remark.ForeColor = Color.Red;
            lblPoints_Remark.Location = new Point(20, 96);
            lblPoints_Remark.Name = "lblPoints_Remark";
            lblPoints_Remark.Size = new Size(0, 15);
            lblPoints_Remark.TabIndex = 11;
            // 
            // button4
            // 
            button4.Location = new Point(242, 53);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 10;
            button4.Text = "加值點數";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tbPoints_Save
            // 
            tbPoints_Save.ImeMode = ImeMode.Disable;
            tbPoints_Save.Location = new Point(93, 53);
            tbPoints_Save.MaxLength = 10;
            tbPoints_Save.Name = "tbPoints_Save";
            tbPoints_Save.Size = new Size(100, 23);
            tbPoints_Save.TabIndex = 9;
            tbPoints_Save.KeyPress += textBox1_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(20, 56);
            label9.Name = "label9";
            label9.Size = new Size(43, 15);
            label9.TabIndex = 8;
            label9.Text = "點數：";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tbTopUp_Value);
            tabPage4.Controls.Add(cbAutoTopUp);
            tabPage4.Controls.Add(lblUsed_Remark);
            tabPage4.Controls.Add(button5);
            tabPage4.Controls.Add(tbUsed_Points);
            tabPage4.Controls.Add(label10);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(632, 395);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "消費";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbTopUp_Value
            // 
            tbTopUp_Value.Location = new Point(411, 43);
            tbTopUp_Value.Name = "tbTopUp_Value";
            tbTopUp_Value.ReadOnly = true;
            tbTopUp_Value.Size = new Size(100, 23);
            tbTopUp_Value.TabIndex = 16;
            tbTopUp_Value.Text = "500";
            tbTopUp_Value.KeyPress += textBox1_KeyPress;
            // 
            // cbAutoTopUp
            // 
            cbAutoTopUp.AutoSize = true;
            cbAutoTopUp.Location = new Point(331, 46);
            cbAutoTopUp.Name = "cbAutoTopUp";
            cbAutoTopUp.Size = new Size(74, 19);
            cbAutoTopUp.TabIndex = 15;
            cbAutoTopUp.Text = "自動儲值";
            cbAutoTopUp.UseVisualStyleBackColor = true;
            cbAutoTopUp.CheckedChanged += cbAutoTopUp_CheckedChanged;
            // 
            // lblUsed_Remark
            // 
            lblUsed_Remark.AutoSize = true;
            lblUsed_Remark.ForeColor = Color.Red;
            lblUsed_Remark.Location = new Point(17, 93);
            lblUsed_Remark.Name = "lblUsed_Remark";
            lblUsed_Remark.Size = new Size(0, 15);
            lblUsed_Remark.TabIndex = 14;
            // 
            // button5
            // 
            button5.Location = new Point(239, 42);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 13;
            button5.Text = "消費點數";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // tbUsed_Points
            // 
            tbUsed_Points.ImeMode = ImeMode.Disable;
            tbUsed_Points.Location = new Point(90, 42);
            tbUsed_Points.MaxLength = 10;
            tbUsed_Points.Name = "tbUsed_Points";
            tbUsed_Points.Size = new Size(100, 23);
            tbUsed_Points.TabIndex = 12;
            tbUsed_Points.KeyPress += textBox1_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 45);
            label10.Name = "label10";
            label10.Size = new Size(43, 15);
            label10.TabIndex = 11;
            label10.Text = "點數：";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 423);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "電子錢包";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button button2;
        private Button button1;
        private TextBox tbPoint;
        private Label label4;
        private TextBox tbDate;
        private Label label3;
        private TextBox tbName;
        private Label label2;
        private TextBox tbID;
        private Label label1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button button3;
        private TextBox tbPoints_DSP;
        private Label label5;
        private TextBox tbDate_DSP;
        private Label label6;
        private TextBox tbName_DSP;
        private Label label7;
        private TextBox tbID_DSP;
        private Label label8;
        private Button button4;
        private TextBox tbPoints_Save;
        private Label label9;
        private Label lblPoints_Remark;
        private Button button5;
        private TextBox tbUsed_Points;
        private Label label10;
        private Label lblUsed_Remark;
        private CheckBox cbAutoTopUp;
        private TextBox tbTopUp_Value;
    }
}