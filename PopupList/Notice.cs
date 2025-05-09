using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopupList
{
    public partial class Notice : MetroFramework.Forms.MetroForm
    {
        public Notice()
        {
            InitializeComponent();
        }
        SqlConnection sCon = new SqlConnection(Commons.DbPath);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sCon.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sCon;
                sqlCommand.Transaction = sCon.BeginTransaction();

                string Sql = string.Empty;

                Sql = "update flag Set alarm = 0; ";


                sqlCommand.CommandText = Sql;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Transaction.Commit();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();

            }
            this.Visible=false;
            this.Tag = true;
            Commons.refresh = true;
        }
    }
}
