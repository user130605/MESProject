namespace MainForms
{
    partial class M03_MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.endureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WorkSend = new System.Windows.Forms.ToolStripMenuItem();
            this.PlanManage = new System.Windows.Forms.ToolStripMenuItem();
            this.RealTimeMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.FacilityWarning = new System.Windows.Forms.ToolStripMenuItem();
            this.FacilityManage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stsFormName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsNowDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.timNowDate = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.tabMyTab = new Services.MyTabControl();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(216)))), ((int)(((byte)(238)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endureToolStripMenuItem,
            this.WorkSend,
            this.PlanManage,
            this.RealTimeMonitor,
            this.FacilityWarning,
            this.FacilityManage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(19, 20, 5, 3);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(235, 776);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // endureToolStripMenuItem
            // 
            this.endureToolStripMenuItem.Font = new System.Drawing.Font("맑은 고딕", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.endureToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.endureToolStripMenuItem.Name = "endureToolStripMenuItem";
            this.endureToolStripMenuItem.Size = new System.Drawing.Size(210, 51);
            this.endureToolStripMenuItem.Text = "ENDURE";
            this.endureToolStripMenuItem.Click += new System.EventHandler(this.endureToolStripMenuItem_Click);
            // 
            // WorkSend
            // 
            this.WorkSend.AutoSize = false;
            this.WorkSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.WorkSend.BackgroundImage = global::MainForms.Properties.Resources.baseline_task_white_24dp;
            this.WorkSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.WorkSend.Checked = true;
            this.WorkSend.CheckOnClick = true;
            this.WorkSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WorkSend.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WorkSend.ForeColor = System.Drawing.Color.White;
            this.WorkSend.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.WorkSend.Margin = new System.Windows.Forms.Padding(0, 40, 0, 20);
            this.WorkSend.Name = "WorkSend";
            this.WorkSend.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.WorkSend.Size = new System.Drawing.Size(170, 80);
            this.WorkSend.Text = "작업 지시";
            this.WorkSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.WorkSend.Click += new System.EventHandler(this.WorkSend_Click);
            // 
            // PlanManage
            // 
            this.PlanManage.AutoSize = false;
            this.PlanManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.PlanManage.BackgroundImage = global::MainForms.Properties.Resources.baseline_event_available_white_24dp;
            this.PlanManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PlanManage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PlanManage.ForeColor = System.Drawing.Color.White;
            this.PlanManage.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.PlanManage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.PlanManage.Name = "PlanManage";
            this.PlanManage.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.PlanManage.Size = new System.Drawing.Size(170, 80);
            this.PlanManage.Text = "정비스케쥴 관리";
            this.PlanManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PlanManage.Click += new System.EventHandler(this.PlanManage_Click);
            // 
            // RealTimeMonitor
            // 
            this.RealTimeMonitor.AutoSize = false;
            this.RealTimeMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.RealTimeMonitor.BackgroundImage = global::MainForms.Properties.Resources.outline_monitor_heart_white_24dp;
            this.RealTimeMonitor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RealTimeMonitor.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RealTimeMonitor.ForeColor = System.Drawing.Color.White;
            this.RealTimeMonitor.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.RealTimeMonitor.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.RealTimeMonitor.Name = "RealTimeMonitor";
            this.RealTimeMonitor.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.RealTimeMonitor.Size = new System.Drawing.Size(170, 80);
            this.RealTimeMonitor.Text = "설비보전 모니터링";
            this.RealTimeMonitor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RealTimeMonitor.Click += new System.EventHandler(this.RealTimeMonitor_Click);
            // 
            // FacilityWarning
            // 
            this.FacilityWarning.AutoSize = false;
            this.FacilityWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.FacilityWarning.BackgroundImage = global::MainForms.Properties.Resources.outline_warning_amber_white_24dp;
            this.FacilityWarning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FacilityWarning.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FacilityWarning.ForeColor = System.Drawing.Color.White;
            this.FacilityWarning.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.FacilityWarning.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.FacilityWarning.Name = "FacilityWarning";
            this.FacilityWarning.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.FacilityWarning.Size = new System.Drawing.Size(170, 80);
            this.FacilityWarning.Text = "설비 이상치 탐지";
            this.FacilityWarning.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FacilityWarning.Click += new System.EventHandler(this.FacilityWarning_Click);
            // 
            // FacilityManage
            // 
            this.FacilityManage.AutoSize = false;
            this.FacilityManage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(139)))), ((int)(((byte)(196)))));
            this.FacilityManage.BackgroundImage = global::MainForms.Properties.Resources.outline_precision_manufacturing_white_24dp;
            this.FacilityManage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FacilityManage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FacilityManage.ForeColor = System.Drawing.Color.White;
            this.FacilityManage.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.FacilityManage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.FacilityManage.Name = "FacilityManage";
            this.FacilityManage.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.FacilityManage.Size = new System.Drawing.Size(170, 80);
            this.FacilityManage.Text = "설비자산 관리";
            this.FacilityManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FacilityManage.Click += new System.EventHandler(this.FacilityManage_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(109)))), ((int)(((byte)(149)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearch,
            this.btnAdd,
            this.btnSave,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnClose,
            this.btnExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1028, 91);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = global::MainForms.Properties.Resources.검색;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Margin = new System.Windows.Forms.Padding(30, 1, 20, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 88);
            this.btnSearch.Tag = "SEARCH";
            this.btnSearch.Text = "조회";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSearch.Click += new System.EventHandler(this.entire);
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::MainForms.Properties.Resources.추가;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Margin = new System.Windows.Forms.Padding(20, 1, 20, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 88);
            this.btnAdd.Tag = "NEW";
            this.btnAdd.Text = "추가";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.entire);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::MainForms.Properties.Resources.저장;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Margin = new System.Windows.Forms.Padding(20, 1, 20, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 88);
            this.btnSave.Tag = "SAVE";
            this.btnSave.Text = "저장";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.entire);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::MainForms.Properties.Resources.삭제;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(20, 1, 30, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(52, 88);
            this.btnDelete.Tag = "DELETE";
            this.btnDelete.Text = "삭제";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.entire);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 91);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::MainForms.Properties.Resources.닫기;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Margin = new System.Windows.Forms.Padding(30, 1, 20, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 88);
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExit
            // 
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = global::MainForms.Properties.Resources.종료;
            this.btnExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Margin = new System.Windows.Forms.Padding(30, 1, 0, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 88);
            this.btnExit.Text = "종료";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsFormName,
            this.toolStripStatusLabel2,
            this.stsUserName,
            this.stsNowDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1028, 28);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stsFormName
            // 
            this.stsFormName.AutoSize = false;
            this.stsFormName.Name = "stsFormName";
            this.stsFormName.Size = new System.Drawing.Size(200, 23);
            this.stsFormName.Text = "시작페이지";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(457, 23);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // stsUserName
            // 
            this.stsUserName.AutoSize = false;
            this.stsUserName.Name = "stsUserName";
            this.stsUserName.Size = new System.Drawing.Size(150, 23);
            this.stsUserName.Text = "UserName";
            // 
            // stsNowDate
            // 
            this.stsNowDate.AutoSize = false;
            this.stsNowDate.Name = "stsNowDate";
            this.stsNowDate.Size = new System.Drawing.Size(200, 23);
            this.stsNowDate.Text = "Datetime";
            // 
            // timNowDate
            // 
            this.timNowDate.Interval = 1000;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 700;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(190)))), ((int)(((byte)(207)))));
            this.metroPanel1.Controls.Add(this.toolStrip1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(235, 60);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1028, 91);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 9;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.tabMyTab);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 8;
            this.metroPanel2.Location = new System.Drawing.Point(235, 151);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(1028, 685);
            this.metroPanel2.TabIndex = 5;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 9;
            // 
            // tabMyTab
            // 
            this.tabMyTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMyTab.Location = new System.Drawing.Point(0, 0);
            this.tabMyTab.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.tabMyTab.Name = "tabMyTab";
            this.tabMyTab.Size = new System.Drawing.Size(1028, 685);
            this.tabMyTab.TabIndex = 3;
            this.tabMyTab.UseSelectable = true;
            this.tabMyTab.Click += new System.EventHandler(this.tabMyTab_Click);
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.statusStrip1);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 9;
            this.metroPanel3.Location = new System.Drawing.Point(235, 808);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(1028, 28);
            this.metroPanel3.TabIndex = 4;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // M03_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 836);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "M03_MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.Text = "MES Solution";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.M03_MainForm_FormClosing);
            this.Load += new System.EventHandler(this.M03_MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stsFormName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel stsUserName;
        private System.Windows.Forms.ToolStripStatusLabel stsNowDate;
        private System.Windows.Forms.Timer timNowDate;
        private System.Windows.Forms.Timer timer1;
        private Services.MyTabControl tabMyTab;
        private System.Windows.Forms.ToolStripMenuItem WorkSend;
        private System.Windows.Forms.ToolStripMenuItem FacilityManage;
        private System.Windows.Forms.ToolStripMenuItem FacilityWarning;
        private System.Windows.Forms.ToolStripMenuItem PlanManage;
        private System.Windows.Forms.ToolStripMenuItem RealTimeMonitor;
        private System.Windows.Forms.ToolStripMenuItem endureToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
    }
}