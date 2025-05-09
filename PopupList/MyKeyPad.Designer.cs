namespace PopupList
{
    partial class MyKeyPad
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_0 = new MetroFramework.Controls.MetroButton();
            this.button_enter = new MetroFramework.Controls.MetroButton();
            this.button_back = new MetroFramework.Controls.MetroButton();
            this.button_2 = new MetroFramework.Controls.MetroButton();
            this.button_5 = new MetroFramework.Controls.MetroButton();
            this.button_3 = new MetroFramework.Controls.MetroButton();
            this.button_6 = new MetroFramework.Controls.MetroButton();
            this.button_8 = new MetroFramework.Controls.MetroButton();
            this.button_1 = new MetroFramework.Controls.MetroButton();
            this.button_9 = new MetroFramework.Controls.MetroButton();
            this.button_4 = new MetroFramework.Controls.MetroButton();
            this.button_7 = new MetroFramework.Controls.MetroButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label_goal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_0);
            this.groupBox1.Controls.Add(this.button_enter);
            this.groupBox1.Controls.Add(this.button_back);
            this.groupBox1.Controls.Add(this.button_2);
            this.groupBox1.Controls.Add(this.button_5);
            this.groupBox1.Controls.Add(this.button_3);
            this.groupBox1.Controls.Add(this.button_6);
            this.groupBox1.Controls.Add(this.button_8);
            this.groupBox1.Controls.Add(this.button_1);
            this.groupBox1.Controls.Add(this.button_9);
            this.groupBox1.Controls.Add(this.button_4);
            this.groupBox1.Controls.Add(this.button_7);
            this.groupBox1.Location = new System.Drawing.Point(17, 163);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(421, 422);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button_0
            // 
            this.button_0.Location = new System.Drawing.Point(149, 320);
            this.button_0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(130, 90);
            this.button_0.TabIndex = 0;
            this.button_0.Text = "0";
            this.button_0.UseSelectable = true;
            this.button_0.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_enter
            // 
            this.button_enter.Location = new System.Drawing.Point(285, 320);
            this.button_enter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_enter.Name = "button_enter";
            this.button_enter.Size = new System.Drawing.Size(130, 90);
            this.button_enter.TabIndex = 0;
            this.button_enter.Text = "ENTER";
            this.button_enter.UseSelectable = true;
            this.button_enter.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(13, 320);
            this.button_back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(130, 90);
            this.button_back.TabIndex = 0;
            this.button_back.Text = "<-";
            this.button_back.UseSelectable = true;
            this.button_back.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_2
            // 
            this.button_2.Location = new System.Drawing.Point(149, 222);
            this.button_2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(130, 90);
            this.button_2.TabIndex = 0;
            this.button_2.Text = "2";
            this.button_2.UseSelectable = true;
            this.button_2.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_5
            // 
            this.button_5.Location = new System.Drawing.Point(149, 124);
            this.button_5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(130, 90);
            this.button_5.TabIndex = 0;
            this.button_5.Text = "5";
            this.button_5.UseSelectable = true;
            this.button_5.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_3
            // 
            this.button_3.Location = new System.Drawing.Point(285, 222);
            this.button_3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(130, 90);
            this.button_3.TabIndex = 0;
            this.button_3.Text = "3";
            this.button_3.UseSelectable = true;
            this.button_3.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_6
            // 
            this.button_6.Location = new System.Drawing.Point(285, 124);
            this.button_6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(130, 90);
            this.button_6.TabIndex = 0;
            this.button_6.Text = "6";
            this.button_6.UseSelectable = true;
            this.button_6.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_8
            // 
            this.button_8.Location = new System.Drawing.Point(149, 26);
            this.button_8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(130, 90);
            this.button_8.TabIndex = 0;
            this.button_8.Text = "8";
            this.button_8.UseSelectable = true;
            this.button_8.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_1
            // 
            this.button_1.Location = new System.Drawing.Point(13, 222);
            this.button_1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(130, 90);
            this.button_1.TabIndex = 0;
            this.button_1.Text = "1";
            this.button_1.UseSelectable = true;
            this.button_1.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_9
            // 
            this.button_9.Location = new System.Drawing.Point(285, 26);
            this.button_9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(130, 90);
            this.button_9.TabIndex = 0;
            this.button_9.Text = "9";
            this.button_9.UseSelectable = true;
            this.button_9.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_4
            // 
            this.button_4.Location = new System.Drawing.Point(13, 124);
            this.button_4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(130, 90);
            this.button_4.TabIndex = 0;
            this.button_4.Text = "4";
            this.button_4.UseSelectable = true;
            this.button_4.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // button_7
            // 
            this.button_7.Location = new System.Drawing.Point(13, 26);
            this.button_7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(130, 90);
            this.button_7.TabIndex = 0;
            this.button_7.Text = "7";
            this.button_7.UseSelectable = true;
            this.button_7.Click += new System.EventHandler(this.CommonButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 23F);
            this.label1.Location = new System.Drawing.Point(57, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "작업수량 : ";
            // 
            // label_goal
            // 
            this.label_goal.AutoSize = true;
            this.label_goal.Font = new System.Drawing.Font("맑은 고딕", 23F);
            this.label_goal.Location = new System.Drawing.Point(293, 75);
            this.label_goal.Name = "label_goal";
            this.label_goal.Size = new System.Drawing.Size(43, 52);
            this.label_goal.TabIndex = 4;
            this.label_goal.Text = "0";
            // 
            // MyKeyPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 596);
            this.Controls.Add(this.label_goal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MyKeyPad";
            this.Padding = new System.Windows.Forms.Padding(23, 75, 23, 25);
            this.Text = "KeyPad";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton button_0;
        private MetroFramework.Controls.MetroButton button_enter;
        private MetroFramework.Controls.MetroButton button_back;
        private MetroFramework.Controls.MetroButton button_2;
        private MetroFramework.Controls.MetroButton button_5;
        private MetroFramework.Controls.MetroButton button_3;
        private MetroFramework.Controls.MetroButton button_6;
        private MetroFramework.Controls.MetroButton button_8;
        private MetroFramework.Controls.MetroButton button_1;
        private MetroFramework.Controls.MetroButton button_9;
        private MetroFramework.Controls.MetroButton button_4;
        private MetroFramework.Controls.MetroButton button_7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_goal;
    }
}