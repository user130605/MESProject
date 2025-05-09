namespace PopupList
{
    partial class BaseRowSelect
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
            this.btn_OK = new MetroFramework.Controls.MetroButton();
            this.btn_Cancel = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.btn_Delete = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_OK.Location = new System.Drawing.Point(146, 229);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(111, 54);
            this.btn_OK.Style = MetroFramework.MetroColorStyle.Black;
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "확인";
            this.btn_OK.UseCustomBackColor = true;
            this.btn_OK.UseCustomForeColor = true;
            this.btn_OK.UseSelectable = true;
            this.btn_OK.UseStyleColors = true;
            this.btn_OK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_Cancel.Location = new System.Drawing.Point(307, 229);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(111, 54);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "취소";
            this.btn_Cancel.UseCustomBackColor = true;
            this.btn_Cancel.UseCustomForeColor = true;
            this.btn_Cancel.UseSelectable = true;
            this.btn_Cancel.UseStyleColors = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(149, 96);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(268, 29);
            this.metroComboBox1.TabIndex = 6;
            this.metroComboBox1.UseSelectable = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.btn_Delete.Location = new System.Drawing.Point(486, 247);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(67, 36);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "행 삭제";
            this.btn_Delete.UseCustomBackColor = true;
            this.btn_Delete.UseCustomForeColor = true;
            this.btn_Delete.UseSelectable = true;
            this.btn_Delete.UseStyleColors = true;
            this.btn_Delete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // BaseRowSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 306);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_OK);
            this.Name = "BaseRowSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected MetroFramework.Controls.MetroButton btn_OK;
        protected MetroFramework.Controls.MetroButton btn_Cancel;
        protected System.Windows.Forms.Label label1;
        protected MetroFramework.Controls.MetroComboBox metroComboBox1;
        protected MetroFramework.Controls.MetroButton btn_Delete;
    }
}