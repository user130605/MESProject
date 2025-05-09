using MetroFramework.Controls;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FormList
{
    public partial class RealTimeMonitor : BaseChildForm
    {
        // 클래스 내에서 전역으로 사용할 데이터 테이블 (참조)
        DataTable dtTemp = new DataTable();         // 데이터그리드 뷰
        public static DataTable dtOperState = new DataTable();    // 설비 현재상태 출력 데이터테이블
        DataTable dtOperTime = new DataTable();     // 가동시간 출력 데이터테이블
        DataTable dtRepairT = new DataTable();      // 평균수리시간 출력 데이터테이블
        DataTable dtBrokenT = new DataTable();      // 평균고장시간 출력 데이터테이블

        string sMFac, sMWorkP, sMName;
        public static string oper;

        // 데이터 베이스 접속 
        public static SqlConnection sCon = new SqlConnection(Commons.DbPath);


        #region<차트세팅>
  

        public void ChartDataGet_Temp(int temp , int hum)
        {

                chart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), temp);
                chart1.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), hum);
            


            chart1.Series[0].XValueMember = "Date";
            chart1.Series[0].YValueMembers = "ºC";
            chart1.Series[0].Name = "온도";
            chart1.Series[0].Color = Color.DarkGoldenrod;
           // chart1.Series[0].IsValueShownAsLabel = true;



            chart1.Series[1].XValueMember = "Date";
            chart1.Series[1].YValueMembers = "%";
            chart1.Series[1].Name = "습도";
            chart1.Series[1].Color = Color.Red;
         //   chart1.Series[1].IsValueShownAsLabel = true;


        }

            public  void ChartDataGet_Snd(int snd, int vib)
            {

             

                    chart2.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), snd);
                    chart2.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), vib);



                    chart2.Series[0].XValueMember = "Date";
                    chart2.Series[0].YValueMembers = "ºC";
                    chart2.Series[0].Name = "소리";
                    chart2.Series[0].Color = Color.Blue;
                    //cha2t1.Series[0].IsValueShownAsLabel = true;
                         
                    chart2.Series[1].XValueMember = "Date";
                    chart2.Series[1].YValueMembers = "%";
                    chart2.Series[1].Name = "진동";
                    chart2.Series[1].Color = Color.Green;
                  //  chart1.Series[1].IsValueShownAsLabel = true;


                }


                #endregion

        #region < 설비 이미지 메소드>
        private void Img(string sMName)
        {
            m_pictureA.Visible = false;
            m_pictureB.Visible = false;
            m_pictureC.Visible = false;
            m_pictureD.Visible = false;
            m_pictureE.Visible = false;

            switch (cboMachine.SelectedItem.ToString())
            {
                case "CNC장비":
                    m_pictureA.Visible = true;
                    break;
                case "절삭장비":
                    m_pictureB.Visible = true;
                    break;
                case "용접장비":
                    m_pictureC.Visible = true;
                    break;
                case "조립장비":
                    m_pictureD.Visible = true;
                    break;
                case "검사장비":
                    m_pictureE.Visible = true;
                    break;
                default:
                    break;
            }
            // 이미지안에 설비이름 
            pic_mName.Text = $"< {cboMachine.SelectedItem.ToString()} >";
        }
        #endregion

        #region < 고장이력 및 보전실적(장비이름, 일련번호, 구분(고장, 예방보전), 고장일자) 메소드 >
        public void Grid(string sMFac, string sMWorkP, string sMName)
        {
            // 그리드 데이터 초기화 
            dtTemp.Clear();

            // 조회 해 올 데이터베이스에 전달 할 명령문 작성.
            string sSqlSelect = "SELECT A.M_NAME, ROW_NUMBER() OVER (PARTITION BY A.M_ID ORDER BY(SELECT 1)) AS NUM, B.OP_REASON, B.OP_DATE" +
                                "   FROM MACHINE AS A, OPERATION AS B" +
                                "   WHERE A.M_ID = B.M_ID " +
                                "       AND (B.OP_REASON = 'BROKEN' OR B.OP_REASON = 'repair' OR B.OP_REASON = 'preserve')" +
                               $"       AND (A.M_FAC = '{sMFac}' AND A.M_WORKP = '{sMWorkP}' AND A.M_NAME = '{sMName}')";

            // 조회된 데이터 데이터테이블에 담기
            SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
            adapter.Fill(dtTemp);

            // 데이터 베이스에서 받아온 결과를 그리드에 표현
            dataGridView1.DataSource = dtTemp;

            if (dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("해당장비의 이력이 존재하지 않습니다.");
                txtTemp.Text = "None";
                txtVol.Text = "None";
                txtHum.Text = "None";
                txtVib.Text = "None";
                txtProduceT.Text = "None";
                txtRepairT.Text = "None";
                operNoper.Text = "가동 / 비가동";
                txtOperTime.Text = "None";

                Graphics g = this.panel1.CreateGraphics();
                SolidBrush p = new SolidBrush(Color.Yellow);

                Rectangle rec = new Rectangle(5, 5, 20, 20);
                g.FillEllipse(p, rec);
                return;
            }
            else
            {
                // 데이터 베이스에서 받아온 결과를 그리드에 표현
                dataGridView1.DataSource = dtTemp;
            }
        }
        #endregion

        #region < 현재 설비 가동상태 출력 메소드 >
        public static void OperState(string sMFac, string sMWorkP, string sMName)
        {
            dtOperState.Clear();
            string sSqlSelect = "SELECT OP_CLASSIFY" +
                             "  FROM MACHINE AS A, OPERATION AS B" +
                             $"  WHERE A.M_ID = B.M_ID" +
                             $"     AND (A.M_FAC = '{sMFac}' AND A.M_WORKP = '{sMWorkP}' AND A.M_NAME = '{sMName}')";

            // 조회된 데이터 데이터테이블에 담기
            SqlDataAdapter adapterNowState = new SqlDataAdapter(sSqlSelect, sCon);
            adapterNowState.Fill(dtOperState);
        }
        #endregion

        #region < 도형 그리기 >
        public void Draw()
        {
            if (dtOperState.Rows.Count != 0)
            {
                // 장비 현재상태 변수 oper에 저장
                oper = $"{dtOperState.Rows[dtOperState.Rows.Count - 1][0].ToString()}";

                if (oper == "on")
                {
                    // 가동/비가동에 따라 도형 그리기 
                    Graphics g = this.panel1.CreateGraphics();
                    SolidBrush p = new SolidBrush(Color.Green);

                    Rectangle rec = new Rectangle(5, 5, 20, 20);
                    g.FillEllipse(p, rec);

                    // 가동/비가동 텍스트 표시
                    operNoper.Text = "가동 중";
                }
                else
                {
                    // 가동/비가동에 따라 도형 그리기
                    Graphics g = this.panel1.CreateGraphics();
                    SolidBrush p = new SolidBrush(Color.Red);

                    Rectangle rec = new Rectangle(5, 5, 20, 20);
                    g.FillEllipse(p, rec);

                    // 가동/비가동 텍스트 표시
                    operNoper.Text = "비가동";
                }
            }
        }
        #endregion

        #region < 설비 온도, 습도, 소리, 진동 출력 메소드 >
        public void MData(string sMFac, string sMWorkP, string sMName)
        {
            Hello.dtDetectData.Clear();
            // REALTIME과 MACHINE 테이블에서 레이블 출력
            string sSqlSelectTemp = "SELECT A.M_ID, B.R_TEMP, B.R_VOL, B.R_HUM, B.R_VIB" +
                                    "  FROM MACHINE AS A, REALTIME AS B" +
                                   $"  WHERE A.M_ID = B.M_ID " +
                                   $"   AND (M_FAC = '{sMFac}' AND M_WORKP = '{sMWorkP}' AND M_NAME = '{sMName}')";
            SqlDataAdapter adapterTemp = new SqlDataAdapter(sSqlSelectTemp, sCon);
            adapterTemp.Fill(Hello.dtDetectData);

            // 출력된 레이블이 없으면 None
            if (Hello.dtDetectData.Rows.Count == 0)
            {
                txtTemp.Text = "None";
                txtVol.Text = "None";
                txtHum.Text = "None";
                txtVib.Text = "None";
            }

            else
            {
                // 출력된 레이블 중 가장 마지막 값을 LABEL에 출력
                txtTemp.Text = $"{Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][1].ToString()}℃ ";
                txtHum.Text = $"{Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][2].ToString()}%";
                txtVib.Text = $"{Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][3].ToString()} Hz";
                txtVol.Text = $"{Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][4].ToString()} dB(V)";

                ChartDataGet_Temp((int)Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][1], (int)Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][2]);
                ChartDataGet_Snd((int)Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][3],(int)Hello.dtDetectData.Rows[Hello.dtDetectData.Rows.Count - 1][4]);
            }
        }
        #endregion

        #region < 가동시간 출력 메소드>
        public void OperTime(string sMFac, string sMWorkP, string sMName)
        {
            dtOperTime.Clear();
            if (oper == "on")
            {
                string sSqlSelectTemp = "SELECT TOP 1 DATEDIFF(HOUR, OP_DATE, GETDATE()) AS 가동시간 " +
                             "  FROM MACHINE AS A, OPERATION AS B" +
                            $"  WHERE (A.M_ID = B.M_ID " +
                            $"       AND (A.M_FAC = '{sMFac}' AND A.M_WORKP = '{sMWorkP}' AND A.M_NAME = '{sMName}'))" +
                            $"     ORDER BY OP_DATE DESC";
                SqlDataAdapter adapterTemp = new SqlDataAdapter(sSqlSelectTemp, sCon);
                adapterTemp.Fill(dtOperTime);

                if (dtOperTime.Rows.Count != 0)
                {
                    txtOperTime.Text = $"{dtOperTime.Rows[0][0].ToString()} 시간";
                }
            }
            else
            {
                txtOperTime.Text = "0시간";
            }
        }
        #endregion

        #region < 평균수리시간 계산 메소드 >
        public void RepairT(string sMFac, string sMWorkP, string sMName)
        {
            dtRepairT.Clear();
            string sSqlSelectTemp = "SELECT AVG(DATEDIFF(HOUR, W_STARTD, W_FINISHD))" +
                                        "  FROM MACHINE AS A, WORK AS B" +
                                       $"  WHERE A.M_ID = B.M_ID  " +
                                       $"     AND (A.M_FAC = '{sMFac}' AND A.M_WORKP = '{sMWorkP}' AND A.M_NAME = '{sMName}')" +
                                       $"     AND B.w_classify = 'REPAIR'" +
                                        "GROUP BY B.M_ID, B.W_CLASSIFY";
            SqlDataAdapter adapterTemp = new SqlDataAdapter(sSqlSelectTemp, sCon);
            adapterTemp.Fill(dtRepairT);

            if (dtRepairT.Rows.Count != 0)
            {
                txtRepairT.Text = $"{dtRepairT.Rows[0][0].ToString()} 시간";
            }
            else
            {
                txtRepairT.Text = "None";
                return;
            }
        }
        #endregion

        #region < 평균고장시간 계산 메소드 >
        public void BrokenT(string sMFac, string sMWorkP, string sMName)
        {
            dtBrokenT.Clear();
            string sSqlSelectTemp = "SELECT AVG(DATEDIFF(HOUR, OP_DATE, OP_FINISHD))" +
                                        "  FROM MACHINE AS A, OPERATION AS B" +
                                       $"  WHERE A.M_ID = B.M_ID  " +
                                       $"     AND (A.M_FAC = '{sMFac}' AND A.M_WORKP = '{sMWorkP}' AND A.M_NAME = '{sMName}')" +
                                       $"     AND B.OP_REASON = 'BROKEN'" +
                                        "GROUP BY B.M_ID, B.OP_REASON";
            SqlDataAdapter adapterTemp = new SqlDataAdapter(sSqlSelectTemp, sCon);
            adapterTemp.Fill(dtBrokenT);

            if (dtBrokenT.Rows.Count != 0)
            {
                txtProduceT.Text = $"{dtBrokenT.Rows[0][0].ToString()} 시간";
            }
            else
            {
                txtRepairT.Text = "None";
            }
        }
        #endregion

        public RealTimeMonitor()
        {
            InitializeComponent();

            Commons.DefaultM();
        }

        private void RealTimeMonitor_Load(object sender, EventArgs e)
        {
            Commons.DefaultM();
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
            dtTemp.Columns.Add("M_NAME", typeof(string)); // 장비이름
            dtTemp.Columns.Add("NUM", typeof(string)); // 일련번호
            dtTemp.Columns.Add("OP_REASON", typeof(string)); // (고장, 수리, 예방정비)구분
            dtTemp.Columns.Add("OP_DATE", typeof(string)); // 일시

            // 2. 컬럼이 설정된 데이터 테이블 을 그리드뷰 에 셋팅 (매핑) 
            // DataSource :DataTable 의 내용을 기반으로 그리드 에 행과 열의 디자인을 표현하는 속성
            dataGridView1.DataSource = dtTemp;

            // 3. 그리드에 표현될 헤더(컬럼의 제목) 의 명칭을 설정. 
            dataGridView1.Columns["M_NAME"].HeaderText = "장비이름";
            dataGridView1.Columns["NUM"].HeaderText = "일련번호";
            dataGridView1.Columns["OP_REASON"].HeaderText = "구분";
            dataGridView1.Columns["OP_DATE"].HeaderText = "일시";

            // 컬럼의 폭 지정
            dataGridView1.Columns[0].Width = 196;
            dataGridView1.Columns[1].Width = 196;
            dataGridView1.Columns[2].Width = 196;
            dataGridView1.Columns[3].Width = 200;
            #endregion

            #region < 로드했을 때 출력할 데이터 값 >
            // 콤보박스에 디폴트 설비 텍스트 출력
            sMFac = cboFac.Text = Commons.DMFac;
            sMWorkP = cboWorkP.Text = Commons.DMWorkP;
            sMName = cboMachine.Text = Commons.DMName;

            // 이미지
            Img(Commons.DMName);

            // 이미지안에 설비이름 
            pic_mName.Text = $"< {Commons.DMName} >";

            try
            {
                // 데이터베이스 오픈
                sCon.Open();

                // 고장이력 및 보전실적(장비이름, 일련번호, 구분(고장, 예방보전), 고장일자)
                Grid(Commons.DMFac, Commons.DMWorkP, Commons.DMName);

                // 장비 현재상태 출력
                OperState(Commons.DMFac, Commons.DMWorkP, Commons.DMName);

                // 도형 그리기
                Draw();
                
                // 가동시간 출력                                                                                                                      
                OperTime(Commons.DMFac, Commons.DMWorkP, Commons.DMName);

                // 평균수리시간 계산                                                                                                                 
                RepairT(Commons.DMFac, Commons.DMWorkP, Commons.DMName);

                // 평균고장시간 계산                                                                                                       
                BrokenT(Commons.DMFac, Commons.DMWorkP, Commons.DMName);

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
            #endregion
        }

        public override void DoInquire()
        {
            try
            {
                // 데이터베이스 오픈
                sCon.Open();

                // 조회 조건의 데이터를 변수에 담기 . 
                sMFac = cboFac.SelectedItem.ToString();     // 사용자가 선택한 사업장
                sMWorkP = cboWorkP.SelectedItem.ToString(); // 사용자가 선택한 작업장
                sMName = cboMachine.SelectedItem.ToString(); // 사용자가 선택한 설비

                // 고장이력 및 보전실적(장비이름, 일련번호, 구분(고장, 예방보전), 고장일자)
                Grid(sMFac, sMWorkP, sMName);
                
                // 장비 현재상태 출력 
                OperState(sMFac, sMWorkP, sMName);

                // 도형 그리기
                Draw();

                // 가동시간 출력                                                                                                                    
                OperTime(sMFac, sMWorkP,sMName);
                
                // 평균수리시간 계산                                                                                                                 
                RepairT(sMFac, sMWorkP, sMName);
                
                // 평균고장시간 계산                                                                                                      
                BrokenT(sMFac, sMWorkP, sMName);             
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                sCon.Close();
            }

            //설비 이미지
            Img(sMName);
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            MData(sMFac, sMWorkP, sMName);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            #region 로드했을 때 출력
            string sSqlSelect = "SELECT OP_CLASSIFY" +
                                "  FROM MACHINE AS A, OPERATION AS B" +
                               $"  WHERE A.M_ID = B.M_ID" +
                               $"     AND (A.M_FAC = '{Commons.DMFac}' AND A.M_WORKP = '{Commons.DMWorkP}' AND A.M_NAME = '{Commons.DMName}')";

            // 조회된 데이터 데이터테이블에 담기
            SqlDataAdapter adapterNowState = new SqlDataAdapter(sSqlSelect, sCon);
            adapterNowState.Fill(dtOperState);

            string oper = string.Empty;
            // 장비 현재상태 변수 oper에 저장
            if (dtOperState.Rows.Count == 0) oper = "off";
            else oper = $"{dtOperState.Rows[dtOperState.Rows.Count - 1][0].ToString()}";

            if (oper == "on")
            {
                // 가동/비가동에 따라 도형 그리기 
                e.Graphics.FillEllipse(new SolidBrush(Color.Green), new Rectangle(5, 5, 20, 20));

                // 가동/비가동 텍스트 표시
                operNoper.Text = "가동 중";
            }
            else
            {
                // 가동/비가동에 따라 도형 그리기
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(5, 5, 20, 20));

                // 가동/비가동 텍스트 표시
                operNoper.Text = "비가동";
            }
            #endregion
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
