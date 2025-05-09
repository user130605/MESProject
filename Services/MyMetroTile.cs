using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject;

namespace Services
{
    public class MyMetroTile : MetroTile
    {
       public MyMetroTile(int hour)
        {
            this.ActiveControl = null;
            this.Location = new System.Drawing.Point(0, 0);
            this.Size = new System.Drawing.Size(347, hour*14);
            this.UseSelectable = true;
            this.borderWidth = 1;
            this.borderColor = Color.White;

        }

        private Color borderColor = Color.Red;
        private int borderWidth = 2; // 원하는 굵기로 변경 가능

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 테두리 그리기 전에 원본 크기의 사각형 그리기
            using (Pen borderPen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(borderPen, ClientRectangle);
            }

            // 테두리 내부로 들어와서 크기가 BorderWidth만큼 작은 사각형 그리기
            Rectangle innerRectangle = new Rectangle(ClientRectangle.X + borderWidth, ClientRectangle.Y + borderWidth, ClientRectangle.Width - 2 * borderWidth, ClientRectangle.Height - 2 * borderWidth);
            using (Pen borderPen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(borderPen, innerRectangle);
            }
        }

    }
    
}
