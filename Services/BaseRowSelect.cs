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
    public partial class BaseRowSelect : MetroForm
    {
        //  public DateTime SelectedDateTime { get; private set; }
        public bool wantDelete = false;

        public BaseRowSelect()
        {
            InitializeComponent();

        }
        public virtual void btnOK_Click(object sender, EventArgs e)
        {
           // SelectedDateTime = new DateTime((int)numYear.Value, (int)numMonth.Value, (int)numDay.Value, (int)numHour.Value, (int)numMinute.Value, (int)numSecond.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("해당 행을 삭제하시겠습니까?","경고",MessageBoxButtons.OKCancel);
            if(DialogResult == DialogResult.OK)
            {

            wantDelete = true;
            }
            Close();
        }
    }
}
