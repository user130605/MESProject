using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace PopupList
{
    public partial class Row_Select_1 : PopupList.BaseRowSelect
    {

        public string data = string.Empty;
        DataTable dTable = new DataTable();
        public static SqlConnection sCon = new SqlConnection(Commons.DbPath);   // 데이터 베이스 접속 


        public Row_Select_1(int mode,string string_data)
        {
            InitializeComponent();
            if(mode == 1)
            {
                label1.Text = "공장 선택";
                dTable.Clear();
                string sSqlSelect = "select distinct m_fac from machine";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dTable);
                metroComboBox1.Items.Clear();
                foreach (DataRow dr in dTable.Rows)
                {
                    metroComboBox1.Items.Add(dr["m_fac"].ToString());
                }
            }
            else if(mode == 2)
            {
                label1.Text = "작업장 선택";
                dTable.Clear();
                string sSqlSelect = "select distinct m_workP from machine";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dTable);
                metroComboBox1.Items.Clear();
                foreach (DataRow dr in dTable.Rows)
                {
                    metroComboBox1.Items.Add(dr["m_workP"].ToString());
                }
            }
            else if (mode == 3)
            {
                label1.Text = "설비 선택";
                dTable.Clear();
                string sSqlSelect = "select distinct m_name from machine";
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dTable);
                metroComboBox1.Items.Clear();
                foreach (DataRow dr in dTable.Rows)
                {
                    metroComboBox1.Items.Add(dr["m_name"].ToString());
                }
            }
            else if (mode == 4)
            {
                label1.Text = "작업분류 선택";
                metroComboBox1.DataSource = new string[] { "produce", "preserve", "repair" };
            }
            else if (mode == 5)
            {
                label1.Text = "생산물품 선택";
                metroComboBox1.DataSource = new string[] { "A부품", "B부품", "C부품" };
            }
            else if (mode == 6)
            {
                label1.Text = "목표생산량 선택";
                metroComboBox1.DataSource = new string[] { "100", "200", "300" };
            }
           // metroComboBox1.Text = string_data;
        }
        public override void btnOK_Click(object sender, EventArgs e)
        {
            data = metroComboBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
