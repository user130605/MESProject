namespace PopupList
{
    partial class Row_Select_1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(147, 60);
            this.label1.Size = new System.Drawing.Size(73, 30);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_Delete.UseCustomBackColor = true;
            this.btn_Delete.UseCustomForeColor = true;
            this.btn_Delete.UseStyleColors = true;
            // 
            // Row_Select_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(576, 306);
            this.Name = "Row_Select_1";
            this.Text = "";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
