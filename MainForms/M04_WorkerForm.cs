using MetroFramework.Controls;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PopupList;
using System.Threading;
using System.Runtime.CompilerServices;

namespace MainForms
{
    public partial class M04_WorkerForm : MetroFramework.Forms.MetroForm
    {
       // Thread thread_sendTemp; //
        SqlConnection sCon = new SqlConnection(Commons.DbPath);
        SqlConnection sCon_2 = new SqlConnection(Commons.DbPath);
        SqlConnection sCon_3 = new SqlConnection(Commons.DbPath);

        DataTable dtTemp = new DataTable();
        DataTable dtTemp_2 = new DataTable();
        string userID = string.Empty;
        string w_state = string.Empty;
        string w_rAmount = string.Empty;

        static bool FlagHighTemp = false; // 알람울리는것 false
        static int continuousTime = 0 ;
        static int HighTempHold ; // 지속되는 조건온도값
        int scale ; //지속되는 시간값

        static bool InnerAlarmFlag = true;  //이상치알람 1번만 하기위한용

        Random random = new Random();

        string rand_vol = string.Empty;
        string rand_hum = string.Empty;
        string rand_vib = string.Empty;
        string rand_temp = string.Empty;
        public bool alarmonoff;
        public bool isThreadRunning =true  ;

        string sMId, sMFac, sMWorkP, sMName;
        DataTable dtMId = new DataTable();          // 장비ID 가져올 데이터테이블

        public ArrayList arrSerialbuff = new ArrayList(); // 수신용 List 버퍼 선언
        SerialPort myport = new SerialPort();
        string in_data;
        string Temp;

        #region ▶ 각종 메서드 ◀
        //선택한 공장에 있는 작업장 데이터 가져와서 콤보박스에 보여주기
        private void cboFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFac.SelectedIndex != -1)
            {
                cboWorkP.Enabled = true;
            }
            sCon_3.Open();
            string sql = $"SELECT DISTINCT m_workP FROM machine where m_fac = '{((MetroComboBox)sender).Text}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sCon_3);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sCon_3.Close();

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
            sCon_3.Open();
            string sql = $"SELECT DISTINCT m_name FROM machine " +
                               $"where m_fac = '{cboFac.Text}' " +
                               $"and m_workP = '{((MetroComboBox)sender).Text}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sCon_3);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            sCon_3.Close();

            cboMachine.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                cboMachine.Items.Add(dr["m_name"].ToString());
            }
        }
        #endregion

        public M04_WorkerForm()
        {
            InitializeComponent();
        }

        public M04_WorkerForm(string sUsername, string uID)
        {
            InitializeComponent();
            Tag = false;

            label_uname.Text = sUsername;
            userID = uID;
        }
        #region<타이머, 키패드>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Time.Text = "현재시간 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateTemp();
        }

        private void panel16_Click(object sender, EventArgs e)
        {
            if (w_state == "running")
            {
                MyKeyPad keypad = new MyKeyPad();
                keypad.ShowDialog();
                if (keypad.Tag == null) return;
                label_amount.Text = Convert.ToString((int)keypad.Tag);
            }
        }
        #endregion

        #region<폼로드 될때 작업지시 그리드 설정>
        private void M04_WorkerForm_Load(object sender, EventArgs e)
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
            sMFac = cboFac.Text = Commons.DMFac;
            sMWorkP = cboWorkP.Text = Commons.DMWorkP;
            sMName = cboMachine.Text = Commons.DMName;
            #region ▶ 그리드 셋팅 ◀
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

            Grid1.DataSource = dtTemp;


            //2. 컬럼이 설정된 데이터 테이블을 그리드뷰에 셋팅(매핑)
            //DataSource : DataTable 의 내용을 기반으로 그리드에 행과 열의 디자인을 표현하는 속성
            Grid1.DataSource = dtTemp;

            //3. 그리드에 표현될 헤더 (컬럼의 제목) 의 명칭을 설정.
            Grid1.Columns["w_num"].HeaderText = "작업지시번호";
            Grid1.Columns["m_fac"].HeaderText = "공장";
            Grid1.Columns["m_workP"].HeaderText = "작업장";
            Grid1.Columns["m_name"].HeaderText = "설비이름";
            Grid1.Columns["w_classify"].HeaderText = "작업분류";
            Grid1.Columns["w_obj"].HeaderText = "작업대상";
            Grid1.Columns["w_gAmount"].HeaderText = $"목표\r작업량";
            Grid1.Columns["w_rAmount"].HeaderText = $"실제\r작업량";
            Grid1.Columns["w_startD"].HeaderText = "시작시각";
            Grid1.Columns["w_finishD"].HeaderText = "종료시각";
            Grid1.Columns["w_state"].HeaderText = "작업상태";
            Grid1.Columns["w_maker"].HeaderText = "작업지시자";

            Grid1.Columns["m_workP"].Width = 140;
            Grid1.Columns["w_startD"].Width = 200;
            Grid1.Columns["w_finishD"].Width = 200;
            Grid1.Columns["w_maker"].Width = 120;

            //데이터베이스에서 받아오는 로직

            //string sFac = string.Empty;
            //string sWorkP = string.Empty;
            //string sMachineName = string.Empty;
            //string sMachineID = string.Empty;
            //bool sCheckMachineID = false;
            #endregion

            try
            {
                sCon_2.Open();
                //그리드 데이터 초기화
                dtTemp_2.Clear();

                string sSqlSelect = "SELECT * FROM flag";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon_2);
                adapter.Fill(dtTemp_2);
                //데이터베이스에서 받아온 결과를 그리드에 표현

                HighTempHold = (int)dtTemp_2.Rows[0]["temp_scale"];
                scale = (int)dtTemp_2.Rows[0]["duration"];

                label4.Text = $"고장기준 - 온도 \r\n {scale}초, {HighTempHold}ºC 초과";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { sCon_2.Close(); }

            //알람정보 불러오는 로직
            try
            {
                sCon_2.Open();
                //그리드 데이터 초기화
                dtTemp.Clear();

                //조회조건의 데이터를 변수에 담기
                //DateTime dStart = dtpStart.Value;
                //DateTime dFinish = dtpFinish.Value;
                //if (cboFac.SelectedValue != null)
                //    sFac = cboFac.SelectedValue.ToString();
                //if (cboWorkP.SelectedValue != null)
                //    sWorkP = cboWorkP.SelectedValue.ToString();
                //if (cboMachine.SelectedValue != null)
                //    sMachineName = cboMachine.SelectedValue.ToString();
                //sMachineID = txtMachineID.Text;
                //sCheckMachineID = chkMachineID.Checked;


                //조회 해올 데이터 베이스에 전달할 명령 문 작성
                string sSqlSelect = $"SELECT work.w_num, " +
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
                                              $"FROM work   " +
                                              $"LEFT JOIN machine " +
                                              $"ON work.m_id = machine.m_id " +
                                              $"WHERE machine.m_fac = '{sMFac}' " +
                                              $"AND machine.m_workP = + '{sMWorkP}' " +
                                              $"AND machine.m_name = '{sMName}' " +
                                              $"AND (w_state = 'ready' OR w_state = 'running')  ";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon_2);
                adapter.Fill(dtTemp);
                //데이터베이스에서 받아온 결과를 그리드에 표현
                Grid1.DataSource = dtTemp;

                w_state = Convert.ToString(dtTemp.Rows[0]["w_state"]);
                label_classfiy.Text = Convert.ToString(dtTemp.Rows[0]["w_classify"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { sCon_2.Close(); }
        }
        #endregion

        //아두이노 연결을 위한 선언
        #region<이상치 저장>
        private void myport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myport.ReadLine();
            Temp = in_data.ToString();
            //  this.Invoke(new EventHandler(displayData));
            double value; //온도를 비교하기위해 자료형 변경

            if (alarmonoff == false) return;//알람끄면 안동작하도록


            if (Double.TryParse(Temp, out value))
            {
                if (value >= HighTempHold)
                {
                    if (!FlagHighTemp  )
                    {
                        continuousTime++;
                        if (continuousTime >= scale && InnerAlarmFlag)
                        {
                            #region<이상치 값 저장하는 sql>
                                try
                                {
                                sCon_2.Open();
                                SqlCommand sqlCommand = new SqlCommand();
                                sqlCommand.Connection = sCon_2;
                                sqlCommand.Transaction = sCon_2.BeginTransaction();

                                string Sql = string.Empty;

                                Sql = "INSERT INTO detection (m_id,      detecT,     m_temp,     m_vol,     m_hum,     m_vib) " +
                                   $"  VALUES('1',GETDATE(),{value},'{rand_vol}', '{rand_hum}','{rand_vib}');";

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
                                sCon_2.Close();

                            }
                            #endregion

                            #region<알람뜰수있도록 flag 테이블 수정하는 sql
                            try
                            {
                                sCon_2.Open();
                                SqlCommand sqlCommand = new SqlCommand();
                                sqlCommand.Connection = sCon_2;
                                sqlCommand.Transaction = sCon_2.BeginTransaction();

                                string Sql = string.Empty;

                                Sql = "update flag Set alarm = 1; ";

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
                                sCon_2.Close();

                            }
                            #endregion

                            continuousTime = 0;
                            InnerAlarmFlag = false;
                            //if (MessageBox.Show($"경고 ! 온도가 {scale}초 동안 높습니다.", "warning", MessageBoxButtons.OK) == DialogResult.OK)
                            //    InnerAlarmFlag = true;
                        }
                        if (InnerAlarmFlag == false) 
                        {
                            btn_Run_Click(sender, e);
                        if ( MessageBox.Show($"경고 ! 온도가 {scale}초 동안 높습니다.", "warning", MessageBoxButtons.OK,MessageBoxIcon.Warning)
                                == DialogResult.OK)
                                InnerAlarmFlag = true;
                        }
                    }
                    else
                    {
                        continuousTime = 0;
                    }
                    FlagHighTemp = false;
                }
                else
                {
                    FlagHighTemp = true;
                    continuousTime = 0;
                }
            }
            else return; //값이 이상해서 변환 실패하면 리턴~
        }
        #endregion

        #region <아두이노 연결CODE>
        //콤보박스에 포트담기
        private void cbo_Select_Port_Click(object sender, EventArgs e)
        {
            cbo_Select_Port.Items.Clear();
            foreach (var item in SerialPort.GetPortNames())
            {
                cbo_Select_Port.Items.Add(item);
            }
        }

        //아두이노 연결로직
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (myport.IsOpen)
                {
                    label_Temp.Text = "";
                    label_sound.Text = "";
                    myport.Write("0");
                    label_state.Text = "정지";
                    
                    myport.Close();
                    // isThreadRunning = false;

                    timer2.Enabled = false;
                }
                else
                {
                    myport.PortName = cbo_Select_Port.SelectedItem.ToString();
                    myport.BaudRate = 9600;
                    myport.DataBits = 8;
                    myport.StopBits = StopBits.One;
                    myport.Parity = Parity.None;
                    myport.DataReceived += myport_DataReceived;
                   // myport.DataReceived += new SerialDataReceivedEventHandler(myport_DataReceived);
                    // myport.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived); //이것이 꼭 필요하다

                    myport.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            btn_Connect.Text = myport.IsOpen ? "연결해제" : "연결하기";
            cbo_Select_Port.Enabled = !myport.IsOpen;
        }

        //바이트 단위 받아오기위한 로직
        public void RcvSerialComm()
        {
            try
            {
                // 포트가 열린 상태인지 체크
                if (myport.IsOpen)
                {
                    // 시리얼 수신 버퍼에 적재된 byte 개수를 읽어 온다.
                    int nbyte = myport.BytesToRead;

                    // 시리얼 byte개수 만큼 버퍼를 생성한다.
                    byte[] rbuff = new byte[nbyte];

                    // byte개수가 0보다 크다면
                    if (nbyte > 0)
                    {
                        //  수신버퍼에서 버퍼의 지정된 인덱스 부터 개수 만큼 읽어 온다.
                        myport.Read(rbuff, 0, nbyte);
                    }

                    // ArrayList에 적재한다.
                    for (int i = 0; i < nbyte; i++)
                    {
                        arrSerialbuff.Add(rbuff[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                // 수신에러 발생시 
                // ArrayList를 클리어한다.
                arrSerialbuff.Clear();
                //예외를 던지고 종료
                throw ex;
            }
        }

        //가동버튼 눌렀을때
        private void btn_Run_Click(object sender, EventArgs e)
        {
            if (!(sMFac == Commons.DMFac && sMWorkP == Commons.DMWorkP && sMName == Commons.DMName))
            {
                if (label_state.Text == "정지")
                {

                    label1.Text = DateTime.Now.ToString("MM-dd HH:mm");
                    label2.Text = "시작시간";

                    label_state.Text = "동작";
                    label15.Text = "설비정지";
                    label_state.ForeColor = Color.LimeGreen;
                    //thread_sendTemp.Start();

                    // isThreadRunning = true;
                    timer2.Enabled = true;
                    // autoResetEvent.Reset();
                    alarmonoff = true;
                }
                else if (label_state.Text == "동작")
                {
                    if (label1.InvokeRequired || label2.InvokeRequired || label_state.InvokeRequired || label15.InvokeRequired)
                    {

                        //timer2.Enabled = false;
                        label1.Invoke(new MethodInvoker(delegate { label1.Text = DateTime.Now.ToString("MM-dd HH:mm"); }));
                        label2.Invoke(new MethodInvoker(delegate { label2.Text = "종료시간"; }));
                        label_state.Invoke(new MethodInvoker(delegate { label_state.Text = "정지"; }));
                        label15.Invoke(new MethodInvoker(delegate { label15.Text = "설비동작"; }));
                    }
                    else

                        //timer2.Enabled = false;
                        label1.Text = DateTime.Now.ToString("MM-dd HH:mm");
                    label2.Text = "종료시간";

                    label_state.Text = "정지";
                    label15.Text = "설비동작";
                    label_state.ForeColor = Color.Red;

                    //  isThreadRunning = false;
                    timer2.Enabled = false;
                    alarmonoff = false;
                }
                return;
            }

            if (!myport.IsOpen) return;

            //ThreadStart StartThread = new ThreadStart(UpdateTemp);
            //thread_sendTemp = new Thread(StartThread);
            if (label_state.Text == "정지")
            {
                myport.Write("1");

                label1.Text = DateTime.Now.ToString("MM-dd HH:mm");
                label2.Text = "시작시간";

                label_state.Text = "동작";
                label15.Text = "설비정지";
                label_state.ForeColor = Color.LimeGreen;
                //thread_sendTemp.Start();
                
               // isThreadRunning = true;
                timer2.Enabled = true;
                // autoResetEvent.Reset();
                alarmonoff = true;
            }
            else if (label_state.Text == "동작")
            {
                if (label1.InvokeRequired || label2.InvokeRequired || label_state.InvokeRequired || label15.InvokeRequired)
                {
                    myport.Write("0");
                    //timer2.Enabled = false;
                    label1.Invoke(new MethodInvoker(delegate { label1.Text = DateTime.Now.ToString("MM-dd HH:mm"); }));
                    label2.Invoke(new MethodInvoker(delegate { label2.Text = "종료시간"; }));
                    label_state.Invoke(new MethodInvoker(delegate { label_state.Text = "정지";}));
                    label15.Invoke(new MethodInvoker(delegate { label15.Text = "설비동작"; }));
                }
                else
                myport.Write("0");
                //timer2.Enabled = false;
                label1.Text = DateTime.Now.ToString("MM-dd HH:mm");
                label2.Text = "종료시간";

                label_state.Text = "정지";
                label15.Text = "설비동작";
                label_state.ForeColor = Color.Red;

              //  isThreadRunning = false;
                timer2.Enabled = false;
                alarmonoff = false;
            }
            //else { thread_sendTemp.Abort(); }
        }
        //시간나오는 타이머사용해서 출력.
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    label_Temp.Text = Temp;
        //   // textBox1.AppendText(DateTime.Now.ToString("MM-dd HH:mm:ss") + "  현재온도 : " + Temp + "\r\n");
        //}
        #endregion

        #region< 랜덤 난수로 습도 , 소리 , 진동 생성하는 메서드 (디폴트 장비일 때)>
        public void RealTimeShow(string hum, string vol, string vib)
        {
            if (label_Temp.InvokeRequired)
            {
                label_Temp.Invoke(new MethodInvoker(delegate { label_Temp.Text = string.Format("{0}", Temp) + "ºC | " + hum + "%"; }));
            }
            else
            {
                label_Temp.Text = string.Format("{0}", Temp) + "ºC " + hum;
            }
            if (label_sound.InvokeRequired)
            {
                label_sound.Invoke(new MethodInvoker(delegate { label_sound.Text = vol + "db | " + vib + "Hz"; }));
            }
            else
            {
                label_sound.Text = vol + "db " + vib + "Hz";
            }
        }
        #endregion

        #region < 랜덤 난수로 습도 , 소리 , 진동 생성하는 메서드 (디폴트 장비가 아닐 때)>
        public void RealTimeShow2(string temp, string hum, string vol, string vib)
        {
            if (label_Temp.InvokeRequired)
            {
                label_Temp.Invoke(new MethodInvoker(delegate { label_Temp.Text = temp + "ºC | " + hum + "%"; }));
            }
            else
            {
                label_Temp.Text = temp + "db " + hum + "Hz";
            }
            if (label_sound.InvokeRequired)
            {
                label_sound.Invoke(new MethodInvoker(delegate { label_sound.Text = vol + "db | " + vib + "Hz"; }));
            }
            else
            {
                label_sound.Text = vol + "db " + vib + "Hz";
            }
        }
            #endregion

        #region < realtime 테이블에 데이터 삽입 메서드 >
        public void UpdateTemp()
        {
            // 디폴트 장비일 때
            if (sMFac == Commons.DMFac && sMWorkP == Commons.DMWorkP && sMName == Commons.DMName)
            {
                //스레드가 실행할 로직.
                //while (isThreadRunning)
                //{

                // 랜덤 난수 발생
                rand_vol = random.Next(10, 21).ToString();
                rand_hum = random.Next(10, 21).ToString();
                rand_vib = random.Next(10, 21).ToString();

                RealTimeShow(rand_hum, rand_vol, rand_vib);

                // 스레드 종료 조건 체크
                try
                {
                    //dtMId.Clear();
                    sCon.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sCon;
                  sqlCommand.Transaction = sCon.BeginTransaction();

                    string Sql = string.Empty;

                    // 장비 ID가져오기
                    //  Sql = "select m_id " +
                    //      "from machine" +
                    //     $"where m_fac = '{sMFac}' and m_workP = '{sMWorkP}' and m_name = '{sMName}'";

                    //SqlDataAdapter adapterTemp = new SqlDataAdapter(Sql, sCon);
                    // adapterTemp.Fill(dtMId);
                    //sMId = dtMId.Rows[0][0].ToString();

                    

                    Sql = "INSERT INTO realtime (m_id,      r_Time,     r_temp,     r_vol,     r_hum,     r_vib) " +
                           $"  VALUES('1',GETDATE(),{Temp},'{rand_vol}', '{rand_hum}','{rand_vib}');";

                    sqlCommand.CommandText = Sql;
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Transaction.Commit();

                    // Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sCon.Close();
                }
                //    if (isThreadRunning == false) break;
                //}
            }
            // 디폴트 장비가 아닐 때
            else
            {
                rand_temp = random.Next(20, 50).ToString();
                rand_vol = random.Next(10, 21).ToString();
                rand_hum = random.Next(10, 21).ToString();
                rand_vib = random.Next(10, 21).ToString();

                RealTimeShow2(rand_temp, rand_hum, rand_vol, rand_vib);

                // 스레드 종료 조건 체크
                try
                {
                    dtMId.Clear();
                    sCon.Close();
                    sCon.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sCon;
                    //sqlCommand.Transaction = sCon.BeginTransaction();

                    string Sql = string.Empty;

                    // 장비 ID가져오기
                    Sql = "select m_id " +
                            "from machine" +
                           $" where m_fac = '{sMFac}' and m_workP = '{sMWorkP}' and m_name = '{sMName}'";

                    SqlDataAdapter adapterTemp = new SqlDataAdapter(Sql, sCon);
                    adapterTemp.Fill(dtMId);
                    sMId = dtMId.Rows[0][0].ToString();

                    // realtime 테이블에 데이터 삽입
                    Sql = "INSERT INTO realtime (m_id,      r_Time,     r_temp,     r_vol,     r_hum,     r_vib) " +
                           $"  VALUES('{sMId}',GETDATE(),{rand_temp},'{rand_vol}', '{rand_hum}','{rand_vib}');";

                    sqlCommand.CommandText = Sql;
                    sqlCommand.ExecuteNonQuery();
          //          sqlCommand.Transaction.Commit();

                    // Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sCon.Close();
                }
            }
        }
        #endregion

        #region<로그아웃버튼>
        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("로그아웃 하시겠습니까?", "로그아웃", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                timer2.Enabled = false;
                this.Tag = true;
                this.Close();
            }
            else
                return;
        }
        #endregion

        #region<작업조회 ,작업시작 , 작업량 저장>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            // 조회 조건의 데이터를 변수에 담기 . 
            sMFac = cboFac.SelectedItem.ToString();     // 사용자가 선택한 사업장
            sMWorkP = cboWorkP.SelectedItem.ToString(); // 사용자가 선택한 작업장
            sMName = cboMachine.SelectedItem.ToString(); // 사용자가 선택한 설비이름
            
            try
            {
                sCon_2.Open();
                //그리드 데이터 초기화
                dtTemp.Clear();

                //조회 해올 데이터 베이스에 전달할 명령 문 작성
                string sSqlSelect = $"SELECT work.w_num, " +
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
                                              $"FROM work   " +
                                              $"LEFT JOIN machine " +
                                              $"ON work.m_id = machine.m_id " +
                                              $"WHERE machine.m_fac = '{sMFac}' " +
                                              $"AND machine.m_workP = '{sMWorkP}' " +
                                              $"AND machine.m_name = '{sMName}' " +
                                              $"AND (w_state = 'ready' OR w_state = 'running') ";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon_2);
                adapter.Fill(dtTemp);
                //데이터베이스에서 받아온 결과를 그리드에 표현
                Grid1.DataSource = dtTemp;

                if(dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("데이터가 없습니다.");
                }
                else 
                w_state = Convert.ToString(dtTemp.Rows[0]["w_state"]);

                if (w_state == "running")
                {
                    labelstate.Text = "작업중";
                    labelstate.ForeColor = Color.LimeGreen;
                    btn_goalSave.Enabled = true;
                    btn_goalSave.BackColor = Color.FromArgb(124, 146, 180);
                    label13.Text = "작업종료";
                    label_amount.Text = "";
                }
                else
                {
                    labelstate.Text = "작업준비";
                    labelstate.ForeColor = Color.Red;
                    btn_goalSave.Enabled = false;
                    btn_goalSave.BackColor = Color.Silver;
                    label13.Text = "작업시작";
                    label_amount.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { sCon_2.Close(); }

            try
            {
                sCon_2.Open();
                //그리드 데이터 초기화
                dtTemp_2.Clear();

                string sSqlSelect = "SELECT * FROM flag";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon_2);
                adapter.Fill(dtTemp_2);
                //데이터베이스에서 받아온 결과를 그리드에 표현

                HighTempHold = (int)dtTemp_2.Rows[0]["temp_scale"];
                scale = (int)dtTemp_2.Rows[0]["duration"];

                label4.Text = $"고장기준 - 온도 \r\n {scale}초, {HighTempHold}ºC 초과";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { sCon_2.Close(); }

        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            sCon_2.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sCon_2;
            sqlCommand.Transaction = sCon_2.BeginTransaction();

            //그리드의 첫행첫열 고정

            string w_num = Convert.ToString(dtTemp.Rows[0]["w_num"]);
            w_state = Convert.ToString(dtTemp.Rows[0]["w_state"]);

            try
            {

                string Sql = string.Empty;
                string state = string.Empty;

                //변경된 행을 하나씩 추출하여 데이터베이스에 처리.

                //현재가동상태에 따라 업데이트문 작성
                switch (w_state)
                {
                    case "ready":
                        Sql = $"UPDATE work SET u_id = '{userID}',  w_state = 'running'  " +
                              $"FROM work     WHERE w_num = '{w_num}'  AND w_state = '{w_state}' ";
                        state = "시작";
                        break;

                    case "running":
                        if (w_rAmount == "")
                        {
                            MessageBox.Show("작업량을 입력하세요", "작업량", MessageBoxButtons.OK);
                            return;
                        }
                        Sql = "UPDATE work                             " +
                          $"    SET w_rAmount = '{w_rAmount}',           " +
                          $"         w_state = 'done' " +
                          $"    FROM work " +
                          $"    WHERE w_num = '{w_num}' " +
                          $"    AND w_state = '{w_state}' ";

                        state = "종료";
                        break;
                }

                sqlCommand.CommandText = Sql;
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Transaction.Commit();
                MessageBox.Show($"작업이 {state}되었습니다");
            }

            catch (Exception ex)
            {
                sqlCommand.Transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon_2.Close();
            }

            btn_Search_Click(sender, e);
        }
        private void btn_goalSave_Click(object sender, EventArgs e)
        {
            if (label_amount.Text == "") { MessageBox.Show("작업량을 입력하세요"); return; }

            w_rAmount = label_amount.Text;
            MessageBox.Show($"작업량을 입력하였습니다 \r\n 입력한 작업량 : {w_rAmount} ", "작업량", MessageBoxButtons.OK);
        }
        #endregion

        private void M04_WorkerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // if (thread_sendTemp.IsAlive)
            //  thread_sendTemp.Abort(); 
            timer2.Enabled = false;
        }
    }
    }





    
    
    

