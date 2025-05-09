using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopupList
{
    public partial class MyKeyPad : MetroForm
    {
        public MyKeyPad()
        {
            InitializeComponent();
        }

        string string1 = string.Empty;
        int returnI = 0;

        private void CommonButtonClick(object sender, EventArgs e)
        {
            // 공통 버튼 클릭 이벤트 핸들러입니다.

            Button clickedButton = (Button)sender;
            if (clickedButton == null)
            {
                return;
            }
            else if(clickedButton.Name == "button_back")
            {
                if (string1.Length == 0) { return; }
                string1 = string1.Substring(0, string1.Length - 1);
            }
            else if(clickedButton.Name == "button_enter")
            {
                if (int.TryParse(string1, out int result))
                {
                    returnI = result;
                }
                else
                {
                    string1 = string.Empty;
                    label_goal.Text = "0";
                    MessageBox.Show("유효하지 않은 숫자입니다");
                    return;
                }

                this.Tag = returnI;
                this.Close();
                return;
            }
            else
            {
                if (string1.Length == 0)
                {
                    if (clickedButton.Text == "0")
                        return;
                }
                string1 += clickedButton.Text;
            }

            if (string1.Length == 0) { label_goal.Text = "0"; }
            else { label_goal.Text = string1; }
        }
    }
}
