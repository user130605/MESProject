using MetroFramework.Controls;
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
//using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormList
{
    public partial class FacilityWarning : BaseChildForm
    {
        #region < 데이터그리드뷰 출력 메소드 >
        private void GridOutput(string sMFac, string sMWorkP, string sMName)
        {
            // 그리드 데이터 초기화 
            dtTemp.Clear();

            // 조회 해 올 데이터베이스에 전달 할 명령문 작성.
            string sSqlSelect = "SELECT  A.M_NAME, A.M_FAC, A.M_WORKP, B.R_TIME, B.R_TEMP, B.R_VOL, B.R_HUM, B.R_VIB" +
                                "   FROM MACHINE AS A, REALTIME AS B" +
                                "   WHERE A.M_ID = B.M_ID " +
                               $"       AND (A.m_fac = '{sMFac}' " +
                               $"       AND A.m_workP = '{sMWorkP}' " +
                               $"       AND A.M_NAME = '{sMName}')" +
                               $" order by B.R_TIME DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
            adapter.Fill(dtTemp);

            // 데이터 베이스에서 받아온 결과를 그리드에 표현
            dataGridView2.DataSource = dtTemp;
        }
        #endregion
        public FacilityWarning()
        {
            InitializeComponent();

            Commons.DefaultM();

            // 경고알림 출력할 텍스트박스 배열
            Hello.warningTextBoxes = new RichTextBox[]
            {
                txtWarning1,
                txtWarning2,
                txtWarning3,
                txtWarning4,
                txtWarning5,
                txtWarning6,
                txtWarning7
            };

            // 기준치 가져오기
            Hello.StdSelect();
        }

        // 클래스 내에서 전역으로 사용할 데이터 테이블 (참조)
        DataTable dtTemp = new DataTable();                                 // 데이터그리드뷰
        DataTable dtIdealValue = new DataTable();                           // 이상치 존재 레이블을 저장할 데이터테이블
        DataTable dtWarningM = new DataTable();                             // 경고알림메세지 데이터테이블
        string tempTrb, humTrb, volTrb, vibTrb;                             // 이상여부 확인 변수
        string sMFac, sMWorkP, sMName;                                      // 출력할 설비

        private void timer1_Tick(object sender, EventArgs e)
        {
            GridOutput(sMFac, sMWorkP, sMName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 관리자가 TextBox에 입력한 기준치 데이터 가져오기

            #region < 입력한 기준치 UPDATE >
            try
            {
                sCon.Open();

                if (txtInpTemp.Text != "")
                {
                    Hello.tempStd = int.Parse(txtInpTemp.Text);
                    string sSqlUpdate = "UPDATE FLAG " +
                                        $" SET TEMP_SCALE = {Hello.tempStd}";
                    using (SqlCommand command = new SqlCommand(sSqlUpdate, sCon))
                    {
                        command.Parameters.AddWithValue("@TempScale", Hello.tempStd);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    txtInpTemp.Text = string.Empty;
                }
                if (txtInpVol.Text != "")
                {
                    Hello.volStd = int.Parse(txtInpVol.Text);
                    string sSqlUpdate = "UPDATE FLAG " +
                                        $" SET VOL_SCALE = {Hello.volStd}";
                    using (SqlCommand command = new SqlCommand(sSqlUpdate, sCon))
                    {
                        command.Parameters.AddWithValue("@VolScale", Hello.volStd);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    txtInpVol.Text = string.Empty;
                }
                if (txtInpHum.Text != "")
                {
                    Hello.humStd = int.Parse(txtInpHum.Text);
                    string sSqlUpdate = "UPDATE FLAG " +
                                        $" SET HUM_SCALE = {Hello.humStd}";
                    using (SqlCommand command = new SqlCommand(sSqlUpdate, sCon))
                    {
                        command.Parameters.AddWithValue("@HUM_SCALE", Hello.humStd);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    txtInpHum.Text = string.Empty;
                }
                if (txtInpVib.Text != "")
                {
                    Hello.vibStd = int.Parse(txtInpVib.Text);
                    string sSqlUpdate = "UPDATE FLAG " +
                                        $" SET VIB_SCALE = {Hello.vibStd}";
                    using (SqlCommand command = new SqlCommand(sSqlUpdate, sCon))
                    {
                        command.Parameters.AddWithValue("@VibScale", Hello.vibStd);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    txtInpVib.Text = string.Empty;
                }
                if (txtInpDuration.Text != "")
                {
                    Hello.durStd = int.Parse(txtInpDuration.Text);
                    string sSqlUpdate = "UPDATE FLAG " +
                                        $" SET DURATION = {Hello.durStd}";
                    using (SqlCommand command = new SqlCommand(sSqlUpdate, sCon))
                    {
                        command.Parameters.AddWithValue("@DURATION", Hello.durStd);
                        int rowsAffected = command.ExecuteNonQuery();
                    }
                    txtInpDuration.Text = string.Empty;
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                sCon.Close();
            }
            #endregion           

            // 텍스트 박스 초기화
            for (int i = 0; i < Hello.warningTextBoxes.Length; i++)
            {
                Hello.warningTextBoxes[i].Text = string.Empty;
            }

            // 경고알림 출력
            try
            {
                // 데이터베이스 오픈
                sCon.Open();
                Hello.WarningM(Hello.tempStd, Hello.volStd, Hello.humStd, Hello.vibStd);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }

        // 데이터 베이스 접속 
        public static SqlConnection sCon = new SqlConnection(Commons.DbPath);

        private void FacilityWarning_Load(object sender, EventArgs e)
        {
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
            #region < 그리드 셋팅 >
            // 그리드 : 행과 열의 데이터 베이스 테이블의 데이터를 사용자가 확인하고 관리 할 수 있도록
            //          제공되는 디자인 기능을 가지고 있는 컨트롤 (클래스)

            // 1. 그리드에 셋팅이 될 데이터 테이블의 컬럼 설정. 
            dtTemp.Columns.Add("M_NAME", typeof(string));   // 장비이름
            dtTemp.Columns.Add("M_FAC", typeof(string));    // 공장
            dtTemp.Columns.Add("M_WORKP", typeof(string));  // 작업장
            dtTemp.Columns.Add("R_TIME", typeof(string));   // 일시
            dtTemp.Columns.Add("R_TEMP", typeof(string));   // 온도
            dtTemp.Columns.Add("R_VOL", typeof(string));    // 소리
            dtTemp.Columns.Add("R_HUM", typeof(string));    // 습도
            dtTemp.Columns.Add("R_VIB", typeof(string));    // 진동

            // 2. 컬럼이 설정된 데이터 테이블 을 그리드뷰 에 셋팅 (매핑) 
            // DataSource :DataTable 의 내용을 기반으로 그리드 에 행과 열의 디자인을 표현하는 속성
            dataGridView2.DataSource = dtTemp;

            // 3. 그리드에 표현될 헤더(컬럼의 제목) 의 명칭을 설정. 
            dataGridView2.Columns["M_NAME"].HeaderText = "장비이름";
            dataGridView2.Columns["M_FAC"].HeaderText = "공장";
            dataGridView2.Columns["M_WORKP"].HeaderText = "작업장";
            dataGridView2.Columns["R_TIME"].HeaderText = "일시";
            dataGridView2.Columns["R_TEMP"].HeaderText = "온도";
            dataGridView2.Columns["R_VOL"].HeaderText = "소리";
            dataGridView2.Columns["R_HUM"].HeaderText = "습도";
            dataGridView2.Columns["R_VIB"].HeaderText = "진동";

            // 컬럼의 폭 지정
            dataGridView2.Columns[0].Width = 164;
            dataGridView2.Columns[1].Width = 168;
            dataGridView2.Columns[2].Width = 168;
            dataGridView2.Columns[3].Width = 200;
            dataGridView2.Columns[4].Width = 128;
            dataGridView2.Columns[5].Width = 128;
            dataGridView2.Columns[6].Width = 128;
            dataGridView2.Columns[7].Width = 128;
            #endregion

            // 데이터그리드뷰 출력
            GridOutput(Commons.DMFac, Commons.DMWorkP, Commons.DMName);

            // 콤보박스에 디폴트 설비 텍스트 출력
            sMFac = cboFac.Text = Commons.DMFac;
            sMWorkP = cboWorkP.Text = Commons.DMWorkP;
            sMName = cboMachine.Text = Commons.DMName;

            dtWarningM.Columns.Add("warningMessage", typeof(string));        // 경고알림메세지 데이터테이블에 열 추가

            // 경고알림 메세지 출력
            try
            {
                // 데이터베이스 오픈
                sCon.Open();
                Hello.WarningM(Hello.tempStd, Hello.volStd, Hello.humStd, Hello.vibStd);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                sCon.Close();
            }

            timer1.Enabled = true;

            // 기춘치 출력
            txtTempStd.Text = $"{Hello.tempStd.ToString()}℃";
            txtVolStd.Text = $"{Hello.volStd.ToString()}Hz";
            txtHmStd.Text = $"{Hello.humStd.ToString()} %";
            txtVibStd.Text = $"{Hello.vibStd.ToString()} dB(V)";
        }

        public override void DoInquire()
        {
            // 조회 할 때 수행하는 기능.  (데이터그리드 뷰)
            try
            {
                sCon.Open();

                sMFac = cboFac.SelectedItem.ToString();         // 사용자가 선택한 사업장
                sMWorkP = cboWorkP.SelectedItem.ToString();     // 사용자가 선택한 작업장
                sMName = cboMachine.SelectedItem.ToString();     // 사용자가 선택한 설비

                GridOutput(sMFac, sMWorkP, sMName); 
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }
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
        #endregion

    }
}
