using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public partial class BaseChildForm : Form
    {
        public BaseChildForm()
        {
            InitializeComponent();
        }
        public virtual void DoInquire()
        {

        }

        //상속을 받은 클래스에서 구현을 선택할수 있게하는 추상화 기능.
        public virtual void DoSave()
        {

        }

        public virtual void DoDelete()
        {

        }

        public virtual void DoNew()
        {
        }


    }
}
