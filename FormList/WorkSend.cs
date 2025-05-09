using PopupList;
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
using static System.Windows.Forms.AxHost;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using MetroFramework.Controls;
using MetroFramework;
using Calendar.NET;

namespace FormList
{
    public partial class WorkSend : BaseChildForm
    {
        #region ▶ 변수 선언 ◀
        private bool isCellEditing = false; // 셀 편집 중인지 여부를 확인하기 위한 변수
        private int editingRowIndex;
        private int editingColumnIndex;
        SqlConnection sCon = new SqlConnection(Commons.DbPath);
        DataTable dtTemp = new DataTable();


        SqlConnection sqlConnection = new SqlConnection(Commons.DbPath); //DB경로
        string sqlStatement;//sql문 작성용 string변수
        DataTable machineTable = new DataTable(); //장비정보 저장테이블
        int number_of_machine = 0; //장비 총 개수

        DataTable machine_schedule_change = new DataTable(); //어떤장비 스케쥴이 변경되었는지?
        #endregion

        #region ▶ 생성자 함수 ◀
        public WorkSend()
        {
            InitializeComponent();
        }
        #endregion

        private void WorkSend_Load(object sender, EventArgs e)
        {
            #region ▶ DataTable 설정 ◀
            dtTemp.Columns.Add("w_num", typeof(string));
            dtTemp.Columns.Add("m_fac", typeof(string));
            dtTemp.Columns.Add("m_workP", typeof(string));
            dtTemp.Columns.Add("m_name", typeof(string));
            dtTemp.Columns.Add("w_classify", typeof(string));
            dtTemp.Columns.Add("w_obj", typeof(string));
            dtTemp.Columns.Add("w_gAmount", typeof(string));
            dtTemp.Columns.Add("w_rAmount", typeof(string));
            dtTemp.Columns.Add("w_startD", typeof(DateTime));
            dtTemp.Columns.Add("w_finishD", typeof(DateTime));
            dtTemp.Columns.Add("w_state", typeof(string));
            dtTemp.Columns.Add("w_maker", typeof(string));
            #endregion

            #region ▶ Grid 설정 ◀

            metroGrid1.DataSource = dtTemp;

            metroGrid1.Columns["w_num"].HeaderText = "작업지시번호";
            metroGrid1.Columns["m_fac"].HeaderText = "공장";
            metroGrid1.Columns["m_workP"].HeaderText = "작업장";
            metroGrid1.Columns["m_name"].HeaderText = "설비이름";
            metroGrid1.Columns["w_classify"].HeaderText = "작업분류";
            metroGrid1.Columns["w_obj"].HeaderText = "작업대상";
            metroGrid1.Columns["w_gAmount"].HeaderText = "목표작업량";
            metroGrid1.Columns["w_rAmount"].HeaderText = "실제작업량";
            metroGrid1.Columns["w_startD"].HeaderText = "시작시각";
            metroGrid1.Columns["w_finishD"].HeaderText = "종료시각";
            metroGrid1.Columns["w_state"].HeaderText = "작업상태";
            metroGrid1.Columns["w_maker"].HeaderText = "작업지시자";

            metroGrid1.Columns["w_startD"].Width = 200;
            metroGrid1.Columns["w_finishD"].Width = 200;

            metroGrid1.Columns["w_rAmount"].ReadOnly = true;
            metroGrid1.Columns["w_num"].ReadOnly = true;
            metroGrid1.Columns["w_state"].ReadOnly = true;
            metroGrid1.Columns["w_maker"].ReadOnly = true;
            #endregion

            #region ▶ ComboBox 설정 ◀
            //콤보박스
            cboWorkP.Enabled = false;
            cboMachine.Enabled = false;

            //콤보박스에 넣을 공장정보 가져오기
            sCon.Open();
            string sql = "SELECT DISTINCT m_fac FROM machine";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sCon);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sCon.Close();

            cboFac.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cboFac.Items.Add(dr["m_fac"].ToString());
            }
            #endregion

            #region ▶ DateTimePicker 설정 ◀
            
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFinish.Value = new DateTime(DateTime.Now.Year, 12, 31);
            #endregion

            GetMachineInfo();
        }

        #region ▶ 기능들 <재정의 함수> ◀
        public override void DoInquire() //조회
        {
            string sFac = string.Empty;
            string sWorkP = string.Empty;
            string sMachineName = string.Empty;
            string sMachineID = string.Empty;
            bool sCheckMachineID = false;

            try
            {
                sCon.Open();
                //그리드 데이터 초기화
                dtTemp.Clear();

                //조회조건의 데이터를 변수에 담기
                DateTime dStart = dtpStart.Value;
                DateTime dFinish = dtpFinish.Value;
                if (cboFac.Text != null)
                    sFac = cboFac.Text;
                if (cboWorkP.Text != null)
                    sWorkP = cboWorkP.Text;
                if (cboMachine.Text != null)
                    sMachineName = cboMachine.Text;
                sMachineID = txtMachineID.Text;
                sCheckMachineID = chkMachineID.Checked;

                string sSqlSelect = string.Empty;

                //ID로 검색이면
                if (sCheckMachineID)
                {
                    sSqlSelect = $"SELECT work.w_num, " +
                    $"machine.m_fac," +
                    $"machine.m_workP, " +
                    $"machine.m_name, " +
                    $"work.w_classify, " +
                    $"work.w_obj, " +
                    $"work.w_gAmount, " +
                    $"work.w_rAmount, " +
                    $"work.w_startD, " +
                    $"work.w_finishD, " +
                    $"work.w_state, " +
                    $"work.w_maker " +
                    $"FROM work " +
                    $"INNER JOIN machine " +
                    $"ON work.m_id = machine.m_id " +
                    $"WHERE work.w_startD >= '{dStart.ToShortDateString()}' " +
                    $"AND   work.w_finishD <= '{(dFinish.AddDays(1)).ToShortDateString()}' " +
                    $"AND machine.m_id = '{sMachineID}' ";
                }
                //ID검색 X 이면
                else
                {
                    //조회 해올 데이터 베이스에 전달할 명령 문 작성
                    sSqlSelect = $"SELECT work.w_num, " +
                        $"machine.m_fac," +
                        $"machine.m_workP, " +
                        $"machine.m_name, " +
                        $"work.w_classify, " +
                        $"work.w_obj, " +
                        $"work.w_gAmount, " +
                        $"work.w_rAmount, " +
                        $"work.w_startD, " +
                        $"work.w_finishD, " +
                        $"work.w_state, " +
                        $"work.w_maker " +
                        $"FROM work " +
                        $"INNER JOIN machine " +
                        $"ON work.m_id = machine.m_id " +
                        $"WHERE work.w_startD >= '{dStart.ToShortDateString()}' " +
                        $"AND   work.w_finishD <= '{(dFinish.AddDays(1)).ToShortDateString()}' " +
                        $"AND machine.m_fac LIKE '%' +'{sFac}' +'%' " +
                        $"AND machine.m_workP LIKE '{sWorkP}' +'%' " +
                        $"AND machine.m_name LIKE '%' +'{sMachineName}' +'%' ";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dtTemp);
                //데이터베이스에서 받아온 결과를 그리드에 표현
                metroGrid1.DataSource = dtTemp;


            }
            catch (Exception ex)
            {

            }
            finally { sCon.Close(); }
        }

        public override void DoNew()     //추가
        {
            dtTemp.Rows.Add();
            metroGrid1.CurrentCell = metroGrid1.Rows[dtTemp.Rows.Count - 1].Cells[1];
            //WorkSend_register M01 = new WorkSend_register();
            //M01.ShowDialog();
        }

        public override void DoDelete()  //삭제
        {
            {
                if (metroGrid1.Rows.Count == 0) return;
                if (metroGrid1.CurrentRow == null)
                {
                    MessageBox.Show("선택하세요");
                    return;
                }

                string sWorkNumber = metroGrid1.CurrentRow.Cells["w_num"].Value.ToString();

                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    if (dtTemp.Rows[i].RowState != DataRowState.Deleted && dtTemp.Rows[i]["w_num"].ToString() == sWorkNumber)
                    {
                        dtTemp.Rows[i].Delete();
                        break;
                    }
                }
            }
        }

        public override void DoSave()    //저장
        {//일괄저장

            
            string sMfac = string.Empty;
            string sMworkP = string.Empty;
            string sMname = string.Empty;
            string sWclassify = string.Empty;
            string sWobj = string.Empty;
            string sWgAmount = string.Empty;
            //string s_rAmount = string.Empty;
            DateTime sWstartD = DateTime.MinValue;
            DateTime sWfinishD = DateTime.MaxValue;
            //string s_state   = string.Empty;
            //string s_maker   = string.Empty;
            string sMID = string.Empty;
            string sWnum = string.Empty;




            //품목의 정보가 갱신된 데이터를 추출.
            DataTable dtChange = dtTemp.GetChanges();

            if (dtChange == null) { return; }
            if (dtChange.Rows.Count == 0) return;

            for (int q = 0; q < machineTable.Rows.Count; q++)
            {
                machineTable.Rows[q]["isChanged"] = false;
            }

            // m_fac / m_workP / m_name으로 m_id 가져올 수 있는지 체크
            sCon.Open();
            try
            {
                for (int q = 0; q < dtChange.Rows.Count; q++)
                {
                    string Sql2 = $"SELECT m_id FROM machine " +
                        $"WHERE m_fac = '{dtChange.Rows[q]["m_fac"]}' " +
                        $"AND m_workP = '{dtChange.Rows[q]["m_workP"]}' " +
                        $"AND m_name = '{dtChange.Rows[q]["m_name"]}' ";

                    SqlCommand sqlCommand1 = new SqlCommand(Sql2, sCon);
                    sqlCommand1.CommandText = Sql2;
                    SqlDataReader sqlDataReader = sqlCommand1.ExecuteReader();
                    if (sqlDataReader.Read() == false)
                    {
                        MessageBox.Show($"해당하는 설비가 존재하지 않습니다.");
                        sqlDataReader.Close();

                     //   sqlCommand1.Transaction.Rollback();
                        return;
                    }
                    for (int i = 0; i < machineTable.Rows.Count; i++)
                    {
                        if (sqlDataReader["m_id"].ToString() == machineTable.Rows[i]["m_id"].ToString())
                        {
                            machineTable.Rows[i]["isChanged"] = true;
                        }
                    }
                    sqlDataReader.Close();

                }
            }
            catch(Exception ex) { }
            finally { sCon.Close(); }







            if (MessageBox.Show("변경된 내역을 등록하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            sCon.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sCon;



            //트랜잭션 설정.(일괄승인, 일괄복원)
            sqlCommand.Transaction = sCon.BeginTransaction();

            // 트랜잭션 Transaction
            // 데이터 갱신 내역을 승인 or 복구하는 기능
            // - > 데이터의 일관성때문 ( 하나의 데이터라도 오류가 발생한 경우 전체 데이터를 복원하여
            // 일부데이터만 격차가 발생되는 현상을 막기위해서)




            

            try
            {
                string Sql = string.Empty;


                //Datatabe의 행을 담는 클래스 DataRow
                foreach (DataRow dr in dtChange.Rows)
                {
                    string sMessage = string.Empty;
                    //변경된 행을 하나씩 추출하여 데이터베이스에 처리.
                    switch (dr.RowState)
                    {


                        case DataRowState.Deleted:
                            dr.RejectChanges();
                            Sql = $"DELETE work WHERE w_num = '{dr["w_num"]}' ";
                            break;

                        case DataRowState.Added:

                            // 품목 코드, 출시 일자 정보 누락 시 체크 밸리데이션;
                            if (dr["m_fac"].ToString() == "") sMessage += " 공장";
                            if (dr["m_workP"].ToString() == "") sMessage += " 작업장";
                            if (dr["m_name"].ToString() == "") sMessage += " 설비이름";
                            if (dr["w_classify"].ToString() == "") sMessage += " 작업분류";
                            if (dr["w_startD"] == null || dr["w_startD"] is System.DBNull) sMessage += " 시작시각";
                            if (dr["w_finishD"] == null || dr["w_finishD"] is System.DBNull) sMessage += " 종료시각";

                            if (sMessage != "")
                            {
                                MessageBox.Show($"{sMessage} 를 입력하지 않았습니다.");
                                sqlCommand.Transaction.Rollback();
                                return;
                            }

                            // 작업분류 가 'produce' / 'repair' / 'fix' / 'prevent' / 'predict' 가 아닐시 체크벨리데이션
                            if(dr["w_classify"].ToString() != "produce"
                                && dr["w_classify"].ToString() != "repair"
                                && dr["w_classify"].ToString() != "preserve")
                            {
                                MessageBox.Show($"작업분류를 알맞게 입력하지 않았습니다.\n(produce / repair /  preserve )");
                                sqlCommand.Transaction.Rollback();
                                return;
                            }


                            sMfac = dr["m_fac"].ToString();
                            sMworkP = dr["m_workP"].ToString();
                            sMname = dr["m_name"].ToString();
                            sWclassify = dr["w_classify"].ToString();
                            sWobj = dr["w_obj"].ToString();
                            sWgAmount = dr["w_gAmount"].ToString();
                            sWstartD = (DateTime)dr["w_startD"];
                            sWfinishD = (DateTime)dr["w_finishD"];

                            // 시작시각이 종료시각보다 작은지 체크
                            if(sWstartD >= sWfinishD)
                            {
                                MessageBox.Show($"종료시각이 시작시각보다 빠릅니다.");

                                sqlCommand.Transaction.Rollback();
                                return;
                            }

                            // m_fac / m_workP / m_name으로 m_id 가져올 수 있는지 체크

                            Sql = $"SELECT m_id FROM machine " +
                                $"WHERE m_fac = '{sMfac}' " +
                                $"AND m_workP = '{sMworkP}' " +
                                $"AND m_name = '{sMname}' ";
                            sqlCommand.CommandText = Sql;
                            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                            if (sqlDataReader.Read() == false)
                            {
                                MessageBox.Show($"해당하는 설비가 존재하지 않습니다.");
                                sqlDataReader.Close();
                                sqlCommand.Transaction.Rollback();
                                return;
                            }
                            sMID = sqlDataReader["m_id"].ToString();
                            sqlDataReader.Close();

                            // 시작시각이 바로전 작업지시의 종료시각보다 이전이라면 거른다.


                            Sql = $"SELECT TOP 1 * FROM work " +
                                $"WHERE m_id = '{sMID}' " +
                                $"ORDER BY w_startD DESC";
                            sqlCommand.CommandText = Sql;
                            SqlDataReader sqlDataReader8 = sqlCommand.ExecuteReader();

                            //만약 처음작업이라면
                            if (sqlDataReader8.Read() == false)
                            {
                                
                            }

                            else if (Convert.ToDateTime(sqlDataReader8["w_finishD"]) > sWstartD)
                            {
                                MessageBox.Show($"작업시작시각이 이전 작업지시와 겹칩니다.");
                                sqlDataReader8.Close();
                                sqlCommand.Transaction.Rollback();
                                return;
                            }

                            sqlDataReader8.Close();


                            //마지막 작업지시번호 가져오기
                            Sql = "select top 1 w_num from work order by w_num DESC";
                            sqlCommand.CommandText = Sql;
                            SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
                            if (sqlDataReader2.Read() == false)
                            {
                                sWnum = "1000";
                            }
                            else
                                sWnum = (Convert.ToInt32(sqlDataReader2["w_num"]) + 1).ToString();
                            sqlDataReader2.Close();


                            // 데이터가 없는경우 INSERT
                            Sql = $"INSERT INTO work(w_num, m_id, w_obj, w_classify, w_startD, w_finishD, w_gAmount, w_state, w_maker) " +
                                $"VALUES ('{sWnum}','{sMID}','{sWobj}','{sWclassify}','{sWstartD.ToString("yyyy-MM-dd HH:mm:ss")}','{sWfinishD.ToString("yyyy-MM-dd HH:mm:ss")}','{sWgAmount}','ready','관리자')";


                            break;

                        case DataRowState.Modified:
                            // 품목 코드, 출시 일자 정보 누락 시 체크 밸리데이션;
                            if (dr["m_fac"].ToString() == "") sMessage += " 공장";
                            if (dr["m_workP"].ToString() == "") sMessage += " 작업장";
                            if (dr["m_name"].ToString() == "") sMessage += " 설비이름";
                            if (dr["w_classify"].ToString() == "") sMessage += " 작업분류";
                            if (dr["w_startD"] == null || dr["w_startD"] is System.DBNull) sMessage += " 시작시각";
                            if (dr["w_finishD"] == null || dr["w_finishD"] is System.DBNull) sMessage += " 종료시각";

                            if (sMessage != "")
                            {
                                MessageBox.Show($"{sMessage} 를 입력하지 않았습니다.");
                                sqlCommand.Transaction.Rollback();
                                return;
                            }

                            sMfac = dr["m_fac"].ToString();
                            sMworkP = dr["m_workP"].ToString();
                            sMname = dr["m_name"].ToString();
                            sWclassify = dr["w_classify"].ToString();
                            sWobj = dr["w_obj"].ToString();
                            sWgAmount = dr["w_gAmount"].ToString();
                            sWstartD = (DateTime)dr["w_startD"];
                            sWfinishD = (DateTime)dr["w_finishD"];
                            sWnum = dr["w_num"].ToString();

                            // 시작시각이 종료시각보다 작은지 체크
                            if (sWstartD >= sWfinishD)
                            {
                                MessageBox.Show($"종료시각이 시작시각보다 빠릅니다.");

                                sqlCommand.Transaction.Rollback();
                                return;
                            }

                            // m_fac / m_workP / m_name으로 m_id 가져올 수 있는지 체크

                            Sql = $"SELECT m_id FROM machine " +
                                $"WHERE m_fac = '{sMfac}' " +
                                $"AND m_workP = '{sMworkP}' " +
                                $"AND m_name = '{sMname}' ";
                            sqlCommand.CommandText = Sql;
                            SqlDataReader sqlDataReader4 = sqlCommand.ExecuteReader();
                            if (sqlDataReader4.Read() == false)
                            {
                                MessageBox.Show($"해당하는 설비가 존재하지 않습니다.");
                                sqlDataReader4.Close();
                                sqlCommand.Transaction.Rollback();
                                return;
                            }
                            sMID = sqlDataReader4["m_id"].ToString();
                            sqlDataReader4.Close();

                            // 시작시각이 바로전 작업지시의 종료시각보다 이전이라면 거른다.


                            Sql = $"SELECT TOP 1 * FROM work " +
                                $"WHERE m_id = '{sMID}' " +
                                $"AND w_num <> {sWnum}" +
                                $"ORDER BY w_startD DESC";
                            sqlCommand.CommandText = Sql;
                            SqlDataReader sqlDataReader9 = sqlCommand.ExecuteReader();

                            //만약 처음작업이라면
                            if (sqlDataReader9.Read() == false)
                            {

                            }

                            else if (Convert.ToDateTime(sqlDataReader9["w_finishD"]) > sWstartD)
                            {
                                MessageBox.Show($"작업시작시각이 이전 작업지시와 겹칩니다.");
                                sqlDataReader9.Close();
                                sqlCommand.Transaction.Rollback();
                                return;
                            }

                            sqlDataReader9.Close();


                            Sql = "UPDATE work                             " +
                                      $"    SET m_id  = '{sMID}',            " +
                                      $"        w_obj  = '{sWobj}',            " +
                                      $"        w_classify = '{sWclassify}',           " +
                                      $"        w_startD   = '{sWstartD.ToString("yyyy-MM-dd HH:mm:ss")}',             " +
                                      $"        w_finishD  = '{sWfinishD.ToString("yyyy-MM-dd HH:mm:ss")}',            " +
                                      $"        w_gAmount    = '{sWgAmount}'  " +
                                      $"  WHERE w_num  = '{sWnum}'             ";

                            break;

                    }
                    
                    sqlCommand.CommandText = Sql;
                    sqlCommand.ExecuteNonQuery();
                }
                
                sqlCommand.Transaction.Commit();
                MessageBox.Show("정상처리되었습니다");

                //작업지시가 추가/수정/삭제가 정상적으로 됐음에 따라 정비작업지시 자동으로 잡아주는 코드
                CreatePreventiveMaintenance();
            }
            catch (Exception ex)
            {
                sqlCommand.Transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally { sCon.Close(); }
        }
        #endregion

        

        #region ▶ 각종 메서드 ◀
        //선택한 공장에 있는 작업장 데이터 가져와서 콤보박스에 보여주기
        private void cboFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFac.SelectedIndex != -1)
            {
                cboWorkP.Enabled = true;
            }
            sCon.Open();
            string sql = $"SELECT DISTINCT m_workP FROM machine where m_fac = '{((MetroComboBox)sender).Text}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sCon);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sCon.Close();

            cboWorkP.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cboWorkP.Items.Add(dr["m_workP"].ToString());
            }
        }

        //선택한 작업장에 있는 장비데이터에 가져와서 콤보박스에 보여주기
        private void cboWorkP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWorkP.SelectedIndex != -1)
            {
                cboMachine.Enabled = true;
            }
            sCon.Open();
            string sql = $"SELECT DISTINCT m_name FROM machine " +
                $"where m_fac = '{cboFac.Text}' " +
                $"and m_workP = '{((MetroComboBox)sender).Text}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sCon);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sCon.Close();

            cboMachine.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cboMachine.Items.Add(dr["m_name"].ToString());
            }
        }





        private void Grid_CellClick_Time_NEW(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int selectedRow = e.RowIndex;
            int selectedColumn = e.ColumnIndex;
            if (selectedColumn == 0) selectedColumn = 1;
            // 팝업 폼을 띄우고 선택한 값 전달
            for (int i = 1; i < 5; i++)
            {
                string stemp = string.Empty;
                stemp = dtTemp.Rows[selectedRow][i].ToString();
                using (Row_Select_1 rowSelect = new Row_Select_1(i,stemp))
                {
                    DialogResult result = rowSelect.ShowDialog();
                    if (rowSelect.wantDelete)
                    {
                        dtTemp.Rows[selectedRow].Delete();
                        return;
                    }
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (result == DialogResult.OK)
                    {
                        dtTemp.Rows[selectedRow][i] = rowSelect.data;
                    }

                    
                }
            }
            if(dtTemp.Rows[selectedRow][4].ToString() == "produce")
            {
                for (int i = 5; i <= 6; i++)
                {
                    string stemp = string.Empty;
                    stemp = dtTemp.Rows[selectedRow][i].ToString();
                    using (Row_Select_1 rowSelect = new Row_Select_1(i, stemp))
                    {
                        DialogResult result = rowSelect.ShowDialog();
                        if (rowSelect.wantDelete)
                        {
                            dtTemp.Rows[selectedRow].Delete();
                            return;
                        }
                        if (result == DialogResult.Cancel)
                        {
                            return;
                        }
                        if (result == DialogResult.OK)
                        {
                            dtTemp.Rows[selectedRow][i] = rowSelect.data;
                        }


                    }
                }

            }
            
            //추가할때 시각 기본값을 위해서....... 코드짜는중이엿음

            sCon.Open();
            string sql = $"select * from work " +
                $"where m_id = " +
                $"(select m_id from machine " +
                $"where m_name = '{dtTemp.Rows[selectedRow]["m_name"].ToString()}' " +
                $"and m_fac = '{dtTemp.Rows[selectedRow]["m_fac"].ToString()}' " +
                $"and m_workP = '{dtTemp.Rows[selectedRow]["m_workP"].ToString()}')" +
                $" order by w_startD desc";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sCon);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sCon.Close();

            // 팝업 폼을 띄우고 선택한 값 전달
            DateTime dateTemp = DateTime.MinValue;
            
            //행 수정이면
            if (dtTemp.Rows[selectedRow][8].ToString() != string.Empty)
            {
                dateTemp = Convert.ToDateTime(dtTemp.Rows[selectedRow][8]);
            }
            //행 추가이면
            else if (dtTemp.Rows[selectedRow][8].ToString() == string.Empty)
            {
                if (dt.Rows.Count == 0) dateTemp = DateTime.Now;
                else dateTemp = (Convert.ToDateTime(dt.Rows[0]["w_finishD"])).AddSeconds(1);
            }
            using (TimeSelect timeSelect = new TimeSelect(dateTemp))
            {

                DialogResult result = timeSelect.ShowDialog();
                if (result == DialogResult.Cancel) { return; }
                if (result == DialogResult.OK)
                {
                    DateTime selected = timeSelect.SelectedDateTime;
                    dtTemp.Rows[selectedRow][8] = selected;
                }
            }

            dateTemp = DateTime.MinValue;
            //행수정이면
            if (dtTemp.Rows[selectedRow][9].ToString() != string.Empty)
            {
                dateTemp = Convert.ToDateTime(dtTemp.Rows[selectedRow][9]);
            }
            //행 추가이면
            else if (dtTemp.Rows[selectedRow][9].ToString() == string.Empty)
            {
                if (dt.Rows.Count == 0) dateTemp = DateTime.Now;
                else dateTemp = (Convert.ToDateTime(dt.Rows[0]["w_finishD"])).AddSeconds(1);
            }
            using (TimeSelect timeSelect = new TimeSelect(dateTemp))
            {

                DialogResult result = timeSelect.ShowDialog();
                if (result == DialogResult.Cancel) { return; }

                if (result == DialogResult.OK)
                {
                    DateTime selected = timeSelect.SelectedDateTime;
                    dtTemp.Rows[selectedRow][9] = selected;
                }
            }


            //작업지시번호가 없는 행일때 (즉 추가일때)
            if (metroGrid1.Rows[e.RowIndex].Cells[0] == null)
            {

            }
            //수정일때
            else
            {

            }
        }
        #endregion



        private void GetMachineInfo()
        {
            #region < 데이터베이스에서 정보 가져오기>

            try
            {
                sqlConnection.Open();

                //장비의 총개수 가져오기
                sqlStatement = $"select * from machine";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStatement, sqlConnection);
                sqlDataAdapter.Fill(machineTable);

                number_of_machine = machineTable.Rows.Count;

                //machineTable에 isChanged 컬럼 추가. 변경되었는지 여부
                DataColumn isChanged = new DataColumn("IsChanged", typeof(bool));
                machineTable.Columns.Add(isChanged);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            #endregion
            
        }

        //예방정비스케줄 생성해주는 메서드
        private void CreatePreventiveMaintenance()
        {
            //모든장비가 아니라 작업지시 추가 삭제 수정한 장비의 예방정비스케줄에 변동이있어야함


            //모든 장비의 스케줄을 만들기위해 장비의 개수만큼 반복
            for (int i = 0; i < number_of_machine; i++)
            {
                //바뀐장비가 아니면 안한다
                if ((bool)machineTable.Rows[i]["isChanged"]==false) continue;

                sqlStatement = "SELECT * " +
                         "FROM operation " +                                   // operation 테이블에서
                         $"WHERE m_id = {Convert.ToInt32(machineTable.Rows[i]["m_id"])} " + // i번째장비만
                         "ORDER BY op_date DESC; ";                      // 최근날짜순으로
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStatement, sqlConnection);
                DataTable dtTemp = new DataTable();
                sqlDataAdapter.Fill(dtTemp);


                //현재 장비가 operation테이블에 행이 없다면
                if (dtTemp.Rows.Count == 0) continue;

                //이미 미래에 정비스케줄이 있으면 만들필요없지
                                    string Sql = $"select top 1 * from work where m_id = '{machineTable.Rows[i]["m_id"]}' " +
                    $"AND w_startD > '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}' " +
                         $"AND w_classify in ('repair','preserve')"; 


                    SqlCommand sqlCommand99 = new SqlCommand(Sql, sCon);
                    sqlCommand99.CommandText = Sql;
                    SqlDataReader sqlDataReader99 = sqlCommand99.ExecuteReader();
                if(sqlDataReader99.Read() != false)
                {
                    //  MessageBox.Show("이미 예정된 정비/수리 일정이 있습니다");
                    sqlDataReader99.Close();

                    continue;
                }
                sqlDataReader99.Close();

                //어떤장비가 현재 정비중인 상태면 다음 예방정비스케쥴 안만들것임.
                //현재 장비가 미가동이고 정비중이라면
                if (dtTemp.Rows[0]["op_classify"].ToString() == "off")
                    if (dtTemp.Rows[0]["op_reason"].ToString() == "repair"
                        || dtTemp.Rows[0]["op_reason"].ToString() == "preserve")
                        continue;

                // < 예방정비 만들기 >

                // 최근정비일자 구하기
                DateTime recent_preservation_date = DateTime.MinValue;
                DateTime next_preservation_date = DateTime.MaxValue;

                //데이터베이스 테이블에 첫행이 on에 정비중라면
                if (dtTemp.Rows[0]["op_classify"].ToString() == "on")
                    if (dtTemp.Rows[0]["op_reason"].ToString() == "repair"
                        || dtTemp.Rows[0]["op_reason"].ToString() == "preserve")
                        recent_preservation_date = Convert.ToDateTime(dtTemp.Rows[0]["op_date"]);

                for (int j = 1; j < dtTemp.Rows.Count; j++)
                {
                    if (dtTemp.Rows[j]["op_reason"].ToString() == "fix"
                    || dtTemp.Rows[j]["op_reason"].ToString() == "preserve")
                    {
                        // 장비가 정비이후 operation의 시작date구하기 ( 즉 fix나 preserve가 끝난시각을 구하는 것.)
                        recent_preservation_date = Convert.ToDateTime(dtTemp.Rows[j - 1]["op_date"]);
                        break;
                    }
                }
                if (recent_preservation_date == DateTime.MinValue)
                {
                    recent_preservation_date = Convert.ToDateTime(dtTemp.Rows[dtTemp.Rows.Count - 1]["op_date"]);
                }
                if (recent_preservation_date == DateTime.MinValue)
                {
                    MessageBox.Show("datetime 오류 발생");
                    continue;
                }

                //1. 주기 에따라 예방정비만들기 2. 가동총합시간에 따라 예방정비만들기
                // 주기에 따라
                if (machineTable.Rows[i]["m_preSerMth"].ToString() == "period")
                {
                    //최근정비시각 + 예방정비주기 해서 다음예방정비시각 구하기
                    next_preservation_date =
                      recent_preservation_date.AddDays(Convert.ToDouble(machineTable.Rows[i]["m_preSerStd"]));
                }
                //가동총합시간(사용량)에 따라
                else if (machineTable.Rows[i]["m_preSerMth"].ToString() == "usage")
                {
                    //최근정비시각부터 현재시각까지 장비가동된 시간 구해서 
                    // 가동안된시간을 뺄거임. 그럼 지금까지 사용량 나옴

                    DateTime nowReport = DateTime.Now; //현재시각 기록용
                    TimeSpan totalTemp = nowReport - recent_preservation_date; //최근정비시각부터 지금까지 총시간
                    DateTime dateTimeTemp = nowReport; //어디까지 계산했는지 기록용변수


                    for (int k = 0; k < dtTemp.Rows.Count; k++)
                    {

                        if (Convert.ToString(dtTemp.Rows[k]["op_classify"]) == "on")
                        {
                            dateTimeTemp = Convert.ToDateTime(dtTemp.Rows[k]["op_date"]);
                        }
                        else if (Convert.ToString(dtTemp.Rows[k]["op_classify"]) == "off")
                        {
                            totalTemp -= (dateTimeTemp - Convert.ToDateTime(dtTemp.Rows[k]["op_date"]));
                            dateTimeTemp = Convert.ToDateTime(dtTemp.Rows[k]["op_date"]);

                        }
                        else
                        {
                            MessageBox.Show("error11111");
                            return;
                        }

                        //만약 최근정비시각까지 왔으면 for탈출
                        if (Convert.ToDateTime(dtTemp.Rows[k]["op_date"]) == recent_preservation_date)
                            break;

                    }

                    //그럼 totalTemp는 최근정비시각부터 지금까지 몇시간사용했는지 들고있잖아

                    //이미 예방정비기준사용량 넘었으면 바로 정비
                    if (totalTemp.TotalHours <= Convert.ToDouble(machineTable.Rows[i]["m_preSerStd"]))
                    {
                        next_preservation_date = DateTime.Now;
                    }
                    else// 예방정비기준사용량 안넘었으면 더쓰고 정비
                    {
                        double dTemp = totalTemp.TotalHours - Convert.ToDouble(machineTable.Rows[i]["m_preSerStd"]);
                        next_preservation_date = nowReport.AddHours(dTemp);
                    }
                }
                else continue;


                //만약 다음예방정비시각이 현재시각보다 과거라면 당장 x시간후 예방정비하기
                //현재시각보다 미래에 작업지시가 있다면 그거 끝나고 바로 정비해야함
                

                    //현재시각보다 미래에 작업지시가 있다면 그거바로 끝나고 정비해야함
                    Sql = $"select top 1 * from work where m_id = '{machineTable.Rows[i]["m_id"]}' and w_finishD >GETDATE() order by w_startD desc";
                    SqlCommand sqlCommand = new SqlCommand(Sql, sCon);
                    sqlCommand.CommandText = Sql;
                    SqlDataReader sqlDataReader9 = sqlCommand.ExecuteReader();


                //없다면
                if (sqlDataReader9.Read() == false)
                {
                    //
                    if (next_preservation_date <= DateTime.Now)
                    {
                        next_preservation_date = DateTime.Now.AddHours(1);
                    }
                }

                //있다면
                else
                {
                    next_preservation_date = Convert.ToDateTime(sqlDataReader9["w_finishD"]);
                }

                    sqlDataReader9.Close();

                

                DialogResult result = MessageBox.Show("작업지시가 추가됨에 따라 정비가 필요한 장비가 존재합니다.\n해당 장비의 정비일정을 자동등록 하시겠습니까?", "예방정비스케줄 자동등록", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    continue;
                }


                //데이터베이스 작업 만들기
                DataTable dataTable = new DataTable();
                sqlStatement = $"SELECT * " +
                               $"FROM WORK " +
                               $"WHERE m_id = '{machineTable.Rows[i]["m_id"]}' " +
                               $"AND w_classify in ('preserve','repair') " +
                               $"AND w_startD > GETDATE()";
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlStatement, sqlConnection);
                sqlDataAdapter1.Fill(dataTable);

                sqlConnection.Open();

                //미래에 정비스케쥴이 아예 없을시
                if (dataTable.Rows.Count == 0)
                {
                    //작업을 db에 생성
                    sqlStatement = "select top 1 w_num from work order by w_num desc";
                    SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlStatement, sqlConnection);
                    DataTable dataTable1 = new DataTable();
                    sqlDataAdapter2.Fill(dataTable1);

                    sqlStatement = $"insert into work (w_num, m_id, w_classify, w_startD, w_finishD, w_state, w_maker) " +
                                         $"values ({Convert.ToInt32(dataTable1.Rows[0]["w_num"]) + 1}," +
                                         $"{Convert.ToInt32(machineTable.Rows[i]["m_id"])}," +
                                         $"'preserve', " +
                                         $"'{next_preservation_date.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                         $"'{next_preservation_date.AddHours(2).ToString("yyyy-MM-dd HH:mm:ss")}', " +
                                         $"'ready', " +
                                         $"'관리자2')";
                    SqlCommand sqlCommand5 = new SqlCommand(sqlStatement, sqlConnection);
                    sqlCommand5.ExecuteNonQuery();
                }
                else
                //있을시 업데이트
                {

                    sqlStatement = $"UPDATE WORK " +
                        $"SET m_id = {Convert.ToInt32(machineTable.Rows[i]["m_id"])}, " +
                        $"w_classify = 'preserve', " +
                        $"w_startD = '{next_preservation_date.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                        $"w_finishD = '{next_preservation_date.AddHours(2).ToString("yyyy-MM-dd HH:mm:ss")}' " +
                        $"WHERE w_num = {Convert.ToInt32(dataTable.Rows[0]["w_num"])}";
                    SqlCommand sqlCommand5 = new SqlCommand(sqlStatement, sqlConnection);
                    sqlCommand5.ExecuteNonQuery();

                }
                sqlConnection.Close();
            }
        }

    }
}








    

