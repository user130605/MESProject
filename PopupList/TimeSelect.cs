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
    public partial class TimeSelect : MetroForm
    {
        public DateTime SelectedDateTime { get; private set; }

        public TimeSelect(DateTime dateTemp)
        {
            InitializeComponent();

            //기존에 입력되어있는 시각이 없으면(추가)
            if (dateTemp == DateTime.MinValue)
            {
                numYear.Value = DateTime.Now.Year;
                numMonth.Value = DateTime.Now.Month;
                numDay.Value = DateTime.Now.Day;
                numHour.Value = DateTime.Now.Hour;
                numMinute.Value = DateTime.Now.Minute;
                numSecond.Value = DateTime.Now.Second;
            }
            //기존에 입력되어있는 시각이 있으면(수정)
            else
            {
                DateTime mydateTime = Convert.ToDateTime(dateTemp);

                numYear.Value = mydateTime.Year;
                numMonth.Value = mydateTime.Month;
                numDay.Value = mydateTime.Day;
                numHour.Value = mydateTime.Hour;
                numMinute.Value = mydateTime.Minute;
                numSecond.Value = mydateTime.Second;

            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedDateTime = new DateTime((int)numYear.Value, (int)numMonth.Value, (int)numDay.Value, (int)numHour.Value, (int)numMinute.Value, (int)numSecond.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
