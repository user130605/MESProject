using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TestProject
{
    /// <summary>
    /// 둥근 패널
    /// </summary>
    public class RoundPanel : Panel
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 테두리 반경
        /// </summary>
        private int borderRadius = 20;

        /// <summary>
        /// 테두리 두께
        /// </summary>
        private float borderThickness = 5;

        /// <summary>
        /// 테두리 색상
        /// </summary>
        private Color borderColor = Color.White;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 테두리 펜
        /// </summary>
        private Pen borderPen;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Property
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 테두리 반경 - BorderRadius

        /// <summary>
        /// 테두리 반경
        /// </summary>
        public int BorderRadius
        {
            get
            {
                return this.borderRadius;
            }
            set
            {
                this.borderRadius = value;

                Invalidate();
            }
        }

        #endregion
        #region 테두리 두께 - BorderThickness

        /// <summary>
        /// 테두리 두께
        /// </summary>
        public float BorderThickness
        {
            get
            {
                return this.borderThickness;
            }
            set
            {
                this.borderThickness = value;

                this.borderPen = new Pen(this.borderColor, BorderThickness);

                Invalidate();
            }
        }

        #endregion
        #region 테두리 색상 - BorderColor

        /// <summary>
        /// 테두리 색상
        /// </summary>
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;

                this.borderPen = new Pen(this.borderColor,BorderThickness);

                Invalidate();
            }
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - RoundPanel()

        /// <summary>
        /// 생성자
        /// </summary>
        public RoundPanel() : base()
        {
            this.borderPen = new Pen(BorderColor,BorderThickness);

            DoubleBuffered = true;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Protected

        #region 페인트시 처리하기 - OnPaint(e)

        /// <summary>
        /// 페인트시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            SetRegion(e);

            DrawBorder(e.Graphics);
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region 좌상단 사각형 구하기 - GetLeftUpperRectangle(size)

        /// <summary>
        /// 좌상단 사각형 구하기
        /// </summary>
        /// <param name="size">크기</param>
        /// <returns>좌상단 사각형</returns>
        private Rectangle GetLeftUpperRectangle(int size)
        {
            return new Rectangle(0, 0, size, size);
        }

        #endregion
        #region 우상단 사각형 구하기 - GetRightUpperRectangle(size)

        /// <summary>
        /// 우상단 사각형 구하기
        /// </summary>
        /// <param name="size">크기</param>
        /// <returns>우상단 사각형</returns>
        private Rectangle GetRightUpperRectangle(int size)
        {
            return new Rectangle(Width - size, 0, size, size);
        }

        #endregion
        #region 좌하단 사각형 구하기 - GetLeftLowerRectangle(size)

        /// <summary>
        /// 좌하단 사각형 구하기
        /// </summary>
        /// <param name="size">크기</param>
        /// <returns>좌하단 사각형</returns>
        private Rectangle GetLeftLowerRectangle(int size)
        {
            return new Rectangle(0, Height - size, size, size);
        }

        #endregion
        #region 우하단 사각형 구하기 - GetRightLowerRectangle(size)

        /// <summary>
        /// 우하단 사각형 구하기
        /// </summary>
        /// <param name="size">크기</param>
        /// <returns>우하단 사각형</returns>
        private Rectangle GetRightLowerRectangle(int size)
        {
            return new Rectangle(Width - size, Height - size, size, size);
        }

        #endregion

        #region 영역 설정하기 - SetRegion(e)

        /// <summary>
        /// 영역 설정하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        private void SetRegion(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddArc(GetLeftUpperRectangle(BorderRadius), 180, 90);

            path.AddLine(BorderRadius, 0, Width - BorderRadius, 0);

            path.AddArc(GetRightUpperRectangle(BorderRadius), 270, 90);

            path.AddLine(Width, BorderRadius, Width, Height - BorderRadius);

            path.AddArc(GetRightLowerRectangle(BorderRadius), 0, 90);

            path.AddLine(Width - BorderRadius, Height, BorderRadius, Height);

            path.AddArc(GetLeftLowerRectangle(BorderRadius), 90, 90);

            path.AddLine(0, Height - BorderRadius, 0, BorderRadius);

            path.CloseFigure();

            Region = new Region(path);
        }

        #endregion
        #region 테두리 그리기 - DrawBorder(graphics)

        /// <summary>
        /// 테두리 그리기
        /// </summary>
        /// <param name="graphics">그래픽스</param>
        private void DrawBorder(Graphics graphics)
        {
            graphics.DrawArc(this.borderPen, new Rectangle(0, 0, BorderRadius,BorderRadius), 180, 90);

            graphics.DrawArc(this.borderPen, new Rectangle(Width - BorderRadius - 1, -1, BorderRadius, BorderRadius), 270, 90);

            graphics.DrawArc(this.borderPen, new Rectangle(Width - BorderRadius - 1, Height - BorderRadius - 1, BorderRadius, BorderRadius), 0, 90);

            graphics.DrawArc(this.borderPen, new Rectangle(0, Height - BorderRadius - 1, BorderRadius, BorderRadius), 90, 90);

            graphics.DrawRectangle(this.borderPen, 0.0f, 0.0f, (float)Width - 1.0f, (float)Height - 1.0f);
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}