namespace FormList
{
    partial class FacilityManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Grid_FM = new MetroFramework.Controls.MetroGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_m_id = new MetroFramework.Controls.MetroTextBox();
            this.cbx_m_fac = new MetroFramework.Controls.MetroComboBox();
            this.cbx_m_preSerMth = new MetroFramework.Controls.MetroComboBox();
            this.cbx_m_place = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_m_name = new MetroFramework.Controls.MetroTextBox();
            this.label222 = new System.Windows.Forms.Label();
            this.btn_register_F = new MetroFramework.Controls.MetroButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_FM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.Grid_FM);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1023, 423);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txt_m_name);
            this.groupBox1.Controls.Add(this.label222);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbx_m_place);
            this.groupBox1.Controls.Add(this.cbx_m_preSerMth);
            this.groupBox1.Controls.Add(this.cbx_m_fac);
            this.groupBox1.Controls.Add(this.txt_m_id);
            this.groupBox1.Controls.Add(this.btn_register_F);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 35, 3);
            this.groupBox1.Size = new System.Drawing.Size(1023, 110);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "설비관리화면";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(56, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "장비ID";
            // 
            // Grid_FM
            // 
            this.Grid_FM.AllowUserToResizeRows = false;
            this.Grid_FM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grid_FM.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_FM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_FM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grid_FM.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(133)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_FM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_FM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_FM.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_FM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_FM.EnableHeadersVisualStyles = false;
            this.Grid_FM.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Grid_FM.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Grid_FM.Location = new System.Drawing.Point(3, 16);
            this.Grid_FM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Grid_FM.Name = "Grid_FM";
            this.Grid_FM.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(133)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_FM.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_FM.RowHeadersWidth = 51;
            this.Grid_FM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grid_FM.RowTemplate.Height = 27;
            this.Grid_FM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_FM.Size = new System.Drawing.Size(1017, 405);
            this.Grid_FM.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(699, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "예방정비 방법";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(555, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "설치작업장";
            // 
            // txt_m_id
            // 
            // 
            // 
            // 
            this.txt_m_id.CustomButton.Image = null;
            this.txt_m_id.CustomButton.Location = new System.Drawing.Point(123, 1);
            this.txt_m_id.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_m_id.CustomButton.Name = "";
            this.txt_m_id.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txt_m_id.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_m_id.CustomButton.TabIndex = 1;
            this.txt_m_id.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_m_id.CustomButton.UseSelectable = true;
            this.txt_m_id.CustomButton.Visible = false;
            this.txt_m_id.Lines = new string[0];
            this.txt_m_id.Location = new System.Drawing.Point(15, 65);
            this.txt_m_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_m_id.MaxLength = 32767;
            this.txt_m_id.Name = "txt_m_id";
            this.txt_m_id.PasswordChar = '\0';
            this.txt_m_id.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_m_id.SelectedText = "";
            this.txt_m_id.SelectionLength = 0;
            this.txt_m_id.SelectionStart = 0;
            this.txt_m_id.ShortcutsEnabled = true;
            this.txt_m_id.Size = new System.Drawing.Size(147, 25);
            this.txt_m_id.TabIndex = 37;
            this.txt_m_id.UseSelectable = true;
            this.txt_m_id.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_m_id.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbx_m_fac
            // 
            this.cbx_m_fac.FormattingEnabled = true;
            this.cbx_m_fac.ItemHeight = 23;
            this.cbx_m_fac.Location = new System.Drawing.Point(374, 65);
            this.cbx_m_fac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_m_fac.Name = "cbx_m_fac";
            this.cbx_m_fac.Size = new System.Drawing.Size(129, 29);
            this.cbx_m_fac.TabIndex = 38;
            this.cbx_m_fac.UseSelectable = true;
            // 
            // cbx_m_preSerMth
            // 
            this.cbx_m_preSerMth.FormattingEnabled = true;
            this.cbx_m_preSerMth.ItemHeight = 23;
            this.cbx_m_preSerMth.Location = new System.Drawing.Point(690, 65);
            this.cbx_m_preSerMth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_m_preSerMth.Name = "cbx_m_preSerMth";
            this.cbx_m_preSerMth.Size = new System.Drawing.Size(129, 29);
            this.cbx_m_preSerMth.TabIndex = 38;
            this.cbx_m_preSerMth.UseSelectable = true;
            // 
            // cbx_m_place
            // 
            this.cbx_m_place.FormattingEnabled = true;
            this.cbx_m_place.ItemHeight = 23;
            this.cbx_m_place.Location = new System.Drawing.Point(539, 65);
            this.cbx_m_place.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_m_place.Name = "cbx_m_place";
            this.cbx_m_place.Size = new System.Drawing.Size(129, 29);
            this.cbx_m_place.TabIndex = 38;
            this.cbx_m_place.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(408, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "공장";
            // 
            // txt_m_name
            // 
            // 
            // 
            // 
            this.txt_m_name.CustomButton.Image = null;
            this.txt_m_name.CustomButton.Location = new System.Drawing.Point(123, 1);
            this.txt_m_name.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_m_name.CustomButton.Name = "";
            this.txt_m_name.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txt_m_name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txt_m_name.CustomButton.TabIndex = 1;
            this.txt_m_name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txt_m_name.CustomButton.UseSelectable = true;
            this.txt_m_name.CustomButton.Visible = false;
            this.txt_m_name.Lines = new string[0];
            this.txt_m_name.Location = new System.Drawing.Point(193, 64);
            this.txt_m_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_m_name.MaxLength = 32767;
            this.txt_m_name.Name = "txt_m_name";
            this.txt_m_name.PasswordChar = '\0';
            this.txt_m_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_m_name.SelectedText = "";
            this.txt_m_name.SelectionLength = 0;
            this.txt_m_name.SelectionStart = 0;
            this.txt_m_name.ShortcutsEnabled = true;
            this.txt_m_name.Size = new System.Drawing.Size(147, 25);
            this.txt_m_name.TabIndex = 41;
            this.txt_m_name.UseSelectable = true;
            this.txt_m_name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txt_m_name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label222.ForeColor = System.Drawing.Color.Black;
            this.label222.Location = new System.Drawing.Point(224, 33);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(69, 20);
            this.label222.TabIndex = 40;
            this.label222.Text = "장비이름";
            // 
            // btn_register_F
            // 
            this.btn_register_F.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.btn_register_F.BackgroundImage = global::FormList.Properties.Resources.outline_add_business_white_24dp;
            this.btn_register_F.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_register_F.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_register_F.ForeColor = System.Drawing.Color.White;
            this.btn_register_F.Location = new System.Drawing.Point(857, 17);
            this.btn_register_F.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_register_F.Name = "btn_register_F";
            this.btn_register_F.Size = new System.Drawing.Size(131, 90);
            this.btn_register_F.TabIndex = 36;
            this.btn_register_F.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_register_F.UseSelectable = true;
            this.btn_register_F.Click += new System.EventHandler(this.btn_register_F_Click);
            // 
            // FacilityManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 533);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FacilityManage";
            this.Text = "설비자산관리";
            this.Load += new System.EventHandler(this.FacilityManage_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_FM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroGrid Grid_FM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroComboBox cbx_m_place;
        private MetroFramework.Controls.MetroComboBox cbx_m_preSerMth;
        public MetroFramework.Controls.MetroComboBox cbx_m_fac;
        public MetroFramework.Controls.MetroTextBox txt_m_id;
        public MetroFramework.Controls.MetroButton btn_register_F;
        private System.Windows.Forms.Label label3;
        public MetroFramework.Controls.MetroTextBox txt_m_name;
        private System.Windows.Forms.Label label222;
    }
}