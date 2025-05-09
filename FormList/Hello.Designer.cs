namespace FormList
{
    partial class Hello
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.roundPanel1 = new TestProject.RoundPanel();
            this.txtmName = new System.Windows.Forms.Label();
            this.roundPanel5 = new TestProject.RoundPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVol = new System.Windows.Forms.Label();
            this.txtVib = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtTemp = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.roundPanel4 = new TestProject.RoundPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selectedDate = new MetroFramework.Controls.MetroDateTime();
            this.roundPanel6 = new TestProject.RoundPanel();
            this.roundPanel3 = new TestProject.RoundPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtWarning4 = new System.Windows.Forms.RichTextBox();
            this.txtWarning5 = new System.Windows.Forms.RichTextBox();
            this.txtWarning7 = new System.Windows.Forms.RichTextBox();
            this.txtWarning2 = new System.Windows.Forms.RichTextBox();
            this.txtWarning6 = new System.Windows.Forms.RichTextBox();
            this.txtWarning3 = new System.Windows.Forms.RichTextBox();
            this.txtWarning1 = new System.Windows.Forms.RichTextBox();
            this.Bar_possible = new CircularProgressBar.CircularProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.roundPanel2 = new TestProject.RoundPanel();
            this.roundPanel1.SuspendLayout();
            this.roundPanel5.SuspendLayout();
            this.roundPanel4.SuspendLayout();
            this.roundPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            // 
            // roundPanel1
            // 
            this.roundPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.roundPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(222)))));
            this.roundPanel1.BorderRadius = 10;
            this.roundPanel1.BorderThickness = 3F;
            this.roundPanel1.Controls.Add(this.txtmName);
            this.roundPanel1.Location = new System.Drawing.Point(23, 11);
            this.roundPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPanel1.Name = "roundPanel1";
            this.roundPanel1.Size = new System.Drawing.Size(729, 38);
            this.roundPanel1.TabIndex = 79;
            // 
            // txtmName
            // 
            this.txtmName.AutoSize = true;
            this.txtmName.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.txtmName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.txtmName.Location = new System.Drawing.Point(13, 6);
            this.txtmName.Name = "txtmName";
            this.txtmName.Size = new System.Drawing.Size(166, 28);
            this.txtmName.TabIndex = 41;
            this.txtmName.Text = "공장 작업장 이름";
            this.txtmName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundPanel5
            // 
            this.roundPanel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(222)))));
            this.roundPanel5.BorderRadius = 10;
            this.roundPanel5.BorderThickness = 3F;
            this.roundPanel5.Controls.Add(this.label4);
            this.roundPanel5.Controls.Add(this.label6);
            this.roundPanel5.Controls.Add(this.panel3);
            this.roundPanel5.Controls.Add(this.panel2);
            this.roundPanel5.Controls.Add(this.panel11);
            this.roundPanel5.Controls.Add(this.label3);
            this.roundPanel5.Controls.Add(this.txtHum);
            this.roundPanel5.Controls.Add(this.label1);
            this.roundPanel5.Controls.Add(this.txtVol);
            this.roundPanel5.Controls.Add(this.txtVib);
            this.roundPanel5.Controls.Add(this.panel9);
            this.roundPanel5.Controls.Add(this.panel10);
            this.roundPanel5.Controls.Add(this.txtTemp);
            this.roundPanel5.Controls.Add(this.panel8);
            this.roundPanel5.Location = new System.Drawing.Point(23, 11);
            this.roundPanel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPanel5.Name = "roundPanel5";
            this.roundPanel5.Size = new System.Drawing.Size(729, 304);
            this.roundPanel5.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(491, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 36);
            this.label4.TabIndex = 18;
            this.label4.Text = "Volume";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(143, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 36);
            this.label6.TabIndex = 17;
            this.label6.Text = "Temperature";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(222)))));
            this.panel3.Location = new System.Drawing.Point(354, 45);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 250);
            this.panel3.TabIndex = 80;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(222)))));
            this.panel2.Location = new System.Drawing.Point(18, 169);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 2);
            this.panel2.TabIndex = 25;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.BackgroundImage = global::FormList.Properties.Resources.온도;
            this.panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel11.Location = new System.Drawing.Point(66, 78);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(61, 56);
            this.panel11.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(158, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 36);
            this.label3.TabIndex = 19;
            this.label3.Text = "Humidity";
            // 
            // txtHum
            // 
            this.txtHum.AutoSize = true;
            this.txtHum.BackColor = System.Drawing.Color.White;
            this.txtHum.Font = new System.Drawing.Font("맑은 고딕", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtHum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.txtHum.Location = new System.Drawing.Point(149, 221);
            this.txtHum.Name = "txtHum";
            this.txtHum.Size = new System.Drawing.Size(108, 62);
            this.txtHum.TabIndex = 7;
            this.txtHum.Text = "000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(493, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 36);
            this.label1.TabIndex = 20;
            this.label1.Text = "Vibration";
            // 
            // txtVol
            // 
            this.txtVol.AutoSize = true;
            this.txtVol.BackColor = System.Drawing.Color.White;
            this.txtVol.Font = new System.Drawing.Font("맑은 고딕", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.txtVol.Location = new System.Drawing.Point(485, 92);
            this.txtVol.Name = "txtVol";
            this.txtVol.Size = new System.Drawing.Size(108, 62);
            this.txtVol.TabIndex = 6;
            this.txtVol.Text = "000";
            // 
            // txtVib
            // 
            this.txtVib.AutoSize = true;
            this.txtVib.BackColor = System.Drawing.Color.White;
            this.txtVib.Font = new System.Drawing.Font("맑은 고딕", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtVib.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.txtVib.Location = new System.Drawing.Point(488, 221);
            this.txtVib.Name = "txtVib";
            this.txtVib.Size = new System.Drawing.Size(108, 62);
            this.txtVib.TabIndex = 8;
            this.txtVib.Text = "000";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BackgroundImage = global::FormList.Properties.Resources.습도;
            this.panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel9.Location = new System.Drawing.Point(66, 206);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(61, 56);
            this.panel9.TabIndex = 23;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.BackgroundImage = global::FormList.Properties.Resources.소리;
            this.panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel10.Location = new System.Drawing.Point(401, 78);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(61, 56);
            this.panel10.TabIndex = 22;
            // 
            // txtTemp
            // 
            this.txtTemp.AutoSize = true;
            this.txtTemp.BackColor = System.Drawing.Color.White;
            this.txtTemp.Font = new System.Drawing.Font("맑은 고딕", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTemp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.txtTemp.Location = new System.Drawing.Point(149, 92);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(108, 62);
            this.txtTemp.TabIndex = 4;
            this.txtTemp.Text = "000";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BackgroundImage = global::FormList.Properties.Resources.진동;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel8.Location = new System.Drawing.Point(402, 206);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(61, 56);
            this.panel8.TabIndex = 24;
            // 
            // roundPanel4
            // 
            this.roundPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            this.roundPanel4.BorderColor = System.Drawing.Color.White;
            this.roundPanel4.BorderRadius = 20;
            this.roundPanel4.BorderThickness = 5F;
            this.roundPanel4.Controls.Add(this.label12);
            this.roundPanel4.Controls.Add(this.label11);
            this.roundPanel4.Controls.Add(this.label10);
            this.roundPanel4.Controls.Add(this.label9);
            this.roundPanel4.Controls.Add(this.label7);
            this.roundPanel4.Controls.Add(this.selectedDate);
            this.roundPanel4.Controls.Add(this.roundPanel6);
            this.roundPanel4.Location = new System.Drawing.Point(808, 11);
            this.roundPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.roundPanel4.Name = "roundPanel4";
            this.roundPanel4.Size = new System.Drawing.Size(485, 709);
            this.roundPanel4.TabIndex = 33;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(51, 558);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "18시-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(51, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "06시-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(51, 411);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "12시-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(51, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "00시-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "장비일정";
            // 
            // selectedDate
            // 
            this.selectedDate.Location = new System.Drawing.Point(223, 26);
            this.selectedDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.selectedDate.MinimumSize = new System.Drawing.Size(0, 30);
            this.selectedDate.Name = "selectedDate";
            this.selectedDate.Size = new System.Drawing.Size(228, 30);
            this.selectedDate.TabIndex = 1;
            this.selectedDate.ValueChanged += new System.EventHandler(this.selectedDate_ValueChanged);
            // 
            // roundPanel6
            // 
            this.roundPanel6.BorderColor = System.Drawing.Color.White;
            this.roundPanel6.BorderRadius = 20;
            this.roundPanel6.BorderThickness = 5F;
            this.roundPanel6.Location = new System.Drawing.Point(96, 110);
            this.roundPanel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPanel6.Name = "roundPanel6";
            this.roundPanel6.Size = new System.Drawing.Size(355, 595);
            this.roundPanel6.TabIndex = 0;
            // 
            // roundPanel3
            // 
            this.roundPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.roundPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.roundPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(197)))), ((int)(((byte)(222)))));
            this.roundPanel3.BorderRadius = 10;
            this.roundPanel3.BorderThickness = 3F;
            this.roundPanel3.Controls.Add(this.panel1);
            this.roundPanel3.Controls.Add(this.label5);
            this.roundPanel3.Controls.Add(this.tableLayoutPanel1);
            this.roundPanel3.Location = new System.Drawing.Point(1339, 11);
            this.roundPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPanel3.Name = "roundPanel3";
            this.roundPanel3.Size = new System.Drawing.Size(392, 709);
            this.roundPanel3.TabIndex = 32;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::FormList.Properties.Resources.경고_removebg_preview;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(-229, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 38);
            this.panel1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(254)))));
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.label5.Location = new System.Drawing.Point(37, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "Push Alarm List";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtWarning4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtWarning5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtWarning7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtWarning2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtWarning6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtWarning3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtWarning1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(42, 65);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(313, 610);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // txtWarning4
            // 
            this.txtWarning4.BackColor = System.Drawing.Color.White;
            this.txtWarning4.Location = new System.Drawing.Point(3, 526);
            this.txtWarning4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning4.Name = "txtWarning4";
            this.txtWarning4.ReadOnly = true;
            this.txtWarning4.Size = new System.Drawing.Size(306, 80);
            this.txtWarning4.TabIndex = 18;
            this.txtWarning4.Text = "";
            // 
            // txtWarning5
            // 
            this.txtWarning5.BackColor = System.Drawing.Color.White;
            this.txtWarning5.Location = new System.Drawing.Point(3, 265);
            this.txtWarning5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning5.Name = "txtWarning5";
            this.txtWarning5.ReadOnly = true;
            this.txtWarning5.Size = new System.Drawing.Size(306, 78);
            this.txtWarning5.TabIndex = 15;
            this.txtWarning5.Text = "";
            // 
            // txtWarning7
            // 
            this.txtWarning7.BackColor = System.Drawing.Color.White;
            this.txtWarning7.Location = new System.Drawing.Point(3, 439);
            this.txtWarning7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning7.Name = "txtWarning7";
            this.txtWarning7.ReadOnly = true;
            this.txtWarning7.Size = new System.Drawing.Size(306, 78);
            this.txtWarning7.TabIndex = 16;
            this.txtWarning7.Text = "";
            // 
            // txtWarning2
            // 
            this.txtWarning2.BackColor = System.Drawing.Color.White;
            this.txtWarning2.Location = new System.Drawing.Point(3, 91);
            this.txtWarning2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning2.Name = "txtWarning2";
            this.txtWarning2.ReadOnly = true;
            this.txtWarning2.Size = new System.Drawing.Size(306, 78);
            this.txtWarning2.TabIndex = 20;
            this.txtWarning2.Text = "";
            // 
            // txtWarning6
            // 
            this.txtWarning6.BackColor = System.Drawing.Color.White;
            this.txtWarning6.Location = new System.Drawing.Point(3, 352);
            this.txtWarning6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning6.Name = "txtWarning6";
            this.txtWarning6.ReadOnly = true;
            this.txtWarning6.Size = new System.Drawing.Size(306, 78);
            this.txtWarning6.TabIndex = 17;
            this.txtWarning6.Text = "";
            // 
            // txtWarning3
            // 
            this.txtWarning3.BackColor = System.Drawing.Color.White;
            this.txtWarning3.Location = new System.Drawing.Point(3, 178);
            this.txtWarning3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning3.Name = "txtWarning3";
            this.txtWarning3.ReadOnly = true;
            this.txtWarning3.Size = new System.Drawing.Size(306, 78);
            this.txtWarning3.TabIndex = 19;
            this.txtWarning3.Text = "";
            // 
            // txtWarning1
            // 
            this.txtWarning1.BackColor = System.Drawing.Color.White;
            this.txtWarning1.Location = new System.Drawing.Point(3, 4);
            this.txtWarning1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWarning1.Name = "txtWarning1";
            this.txtWarning1.Size = new System.Drawing.Size(306, 78);
            this.txtWarning1.TabIndex = 6;
            this.txtWarning1.Text = "";
            // 
            // Bar_possible
            // 
            this.Bar_possible.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.Bar_possible.AnimationSpeed = 500;
            this.Bar_possible.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.Bar_possible.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Bar_possible.ForeColor = System.Drawing.Color.White;
            this.Bar_possible.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.Bar_possible.InnerMargin = 2;
            this.Bar_possible.InnerWidth = -1;
            this.Bar_possible.Location = new System.Drawing.Point(351, 48);
            this.Bar_possible.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bar_possible.MarqueeAnimationSpeed = 2000;
            this.Bar_possible.Name = "Bar_possible";
            this.Bar_possible.OuterColor = System.Drawing.Color.Salmon;
            this.Bar_possible.OuterMargin = -25;
            this.Bar_possible.OuterWidth = 26;
            this.Bar_possible.ProgressColor = System.Drawing.Color.Chartreuse;
            this.Bar_possible.ProgressWidth = 25;
            this.Bar_possible.SecondaryFont = new System.Drawing.Font("굴림", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Bar_possible.Size = new System.Drawing.Size(300, 287);
            this.Bar_possible.StartAngle = 270;
            this.Bar_possible.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.Bar_possible.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.Bar_possible.SubscriptText = "";
            this.Bar_possible.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.Bar_possible.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.Bar_possible.SuperscriptText = "%";
            this.Bar_possible.TabIndex = 26;
            this.Bar_possible.Text = "75";
            this.Bar_possible.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.Bar_possible.Value = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 40);
            this.label2.TabIndex = 27;
            this.label2.Text = "Probability of operation";
            // 
            // roundPanel2
            // 
            this.roundPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.roundPanel2.BorderColor = System.Drawing.Color.White;
            this.roundPanel2.BorderRadius = 20;
            this.roundPanel2.BorderThickness = 5F;
            this.roundPanel2.Controls.Add(this.label2);
            this.roundPanel2.Controls.Add(this.Bar_possible);
            this.roundPanel2.Location = new System.Drawing.Point(26, 338);
            this.roundPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.roundPanel2.Name = "roundPanel2";
            this.roundPanel2.Size = new System.Drawing.Size(726, 382);
            this.roundPanel2.TabIndex = 31;
            // 
            // Hello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1757, 761);
            this.Controls.Add(this.roundPanel1);
            this.Controls.Add(this.roundPanel5);
            this.Controls.Add(this.roundPanel4);
            this.Controls.Add(this.roundPanel3);
            this.Controls.Add(this.roundPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Hello";
            this.Padding = new System.Windows.Forms.Padding(23, 25, 23, 25);
            this.Text = "환영합니다";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Hello_Load);
            this.roundPanel1.ResumeLayout(false);
            this.roundPanel1.PerformLayout();
            this.roundPanel5.ResumeLayout(false);
            this.roundPanel5.PerformLayout();
            this.roundPanel4.ResumeLayout(false);
            this.roundPanel4.PerformLayout();
            this.roundPanel3.ResumeLayout(false);
            this.roundPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundPanel2.ResumeLayout(false);
            this.roundPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtWarning2;
        private System.Windows.Forms.RichTextBox txtWarning3;
        private System.Windows.Forms.RichTextBox txtWarning4;
        private System.Windows.Forms.RichTextBox txtWarning6;
        private System.Windows.Forms.RichTextBox txtWarning7;
        private System.Windows.Forms.RichTextBox txtWarning5;
        private System.Windows.Forms.RichTextBox txtWarning1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel2;
        private TestProject.RoundPanel roundPanel3;
        private TestProject.RoundPanel roundPanel4;
        private TestProject.RoundPanel roundPanel5;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtHum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtVol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtVib;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label txtTemp;
        private System.Windows.Forms.Panel panel8;
        private TestProject.RoundPanel roundPanel1;
        private System.Windows.Forms.Label txtmName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private MetroFramework.Controls.MetroDateTime selectedDate;
        private TestProject.RoundPanel roundPanel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private CircularProgressBar.CircularProgressBar Bar_possible;
        private System.Windows.Forms.Label label2;
        private TestProject.RoundPanel roundPanel2;
    }
}