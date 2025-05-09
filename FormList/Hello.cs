using MetroFramework.Controls;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormList
{
    public partial class Hello : Form
    {
        private System.Windows.Forms.Timer yourTimer;                       // 타이머

        public static DataTable dtDetectData = new DataTable();                           // 온도, 습도, 진동, 소리 저장 데이터테이블

        int ideal = 0;                                                      // 이상여부 확인 변수

        public static DataTable dtIdealValue = new DataTable();             // 이상치 존재 레이블을 저장할 데이터테이블
        public static DataTable dtWarningM = new DataTable();               // 경고알림메세지 데이터테이블
        public static DataTable dtStandard = new DataTable();               // 기준치 데이터테이블

        public static int tempStd, volStd, humStd, vibStd, durStd;          // 온도, 소리, 습도, 진동 기준치 변수
        public static string tempTrb, humTrb, volTrb, vibTrb;               // 이상여부 확인 변수
        
        public static RichTextBox[] warningTextBoxes;                       // 경고알림메세지 텍스트박스 배열 생성

        public static SqlConnection sCon = new SqlConnection(Commons.DbPath);   // 데이터 베이스 접속 
        public static SqlConnection sCon_2 = new SqlConnection(Commons.DbPath);   // 데이터 베이스 접속 


        DataTable dtTemp_chart = new DataTable();

        public static int now_stack = 0; //0: 0시 0분    1: 0시 30분   2: 1시 00분 ~~~~ 0~47까지
        public static DataTable dtTimeTable = new DataTable(); //해당장비 하루일정 담을 데이터테이블
        public static List<MyMetroTile> myMetroTiles = new List<MyMetroTile>(); //메트로타일들 리스트

        public static int defaultMachineID = 1;

        private void MyClear()
        {
            dtDetectData.Clear();
            dtIdealValue.Clear();
            dtWarningM.Clear();
            dtStandard.Clear();
            dtTemp_chart.Clear();
            dtTimeTable.Clear();
        }

        private void InitializeChart()
        {

            dtTemp_chart.Columns.Add("time", typeof(string));
            dtTemp_chart.Columns.Add("temp", typeof(string));

            //for (int i = 0; i < 31; i++)
            //{
            //    dtTemp_chart.Rows.Add(new object[] { $"8/{i}", $"{i}" });
            //}

            //chart1.DataSource = dtTemp_chart;
            //chart1.Series[0].XValueMember = "time";
            //chart1.Series[0].YValueMembers = "temp";
            //chart1.Series[0].Name = "Temp";
            //chart1.Series[0].Color = Color.Blue;
            //chart1.Series[0].IsValueShownAsLabel = true;

        }
        public void DoInquire()
        {
            selectedDate_ValueChanged(null, null);
        }

        //date선택 할때마다
        private void selectedDate_ValueChanged(object sender, EventArgs e)
        {
            roundPanel6.Controls.Clear();
            now_stack = 0;
            dtTimeTable.Clear();
            string sSqlSelect = $"select * from work where m_id = '{defaultMachineID}' and w_finishD >= '{selectedDate.Value.ToString("yyyy-MM-dd")}' " +
                $"and w_startD < '{selectedDate.Value.AddDays(1).ToString("yyyy-MM-dd")}' order by w_startD";

            SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
            adapter.Fill(dtTimeTable);

            for (int i = 0; i < dtTimeTable.Rows.Count; i++)
            {
                //첫번째 시작date가 전날이라면
                if (i == 0 && selectedDate.Value.Day != (Convert.ToDateTime(dtTimeTable.Rows[0]["w_startD"])).Day)
                {
                    dtTimeTable.Rows[0]["w_startD"] = new DateTime((Convert.ToDateTime(dtTimeTable.Rows[0]["w_startD"])).Year,
                        (Convert.ToDateTime(dtTimeTable.Rows[0]["w_startD"])).Month,
                        ((Convert.ToDateTime(dtTimeTable.Rows[0]["w_startD"])).AddDays(1)).Day);
                }

                int start = ChangeMyDateToStartInt(Convert.ToDateTime(dtTimeTable.Rows[i]["w_startD"]));
                int squares = HowManySquares(Convert.ToDateTime(dtTimeTable.Rows[i]["w_startD"]), Convert.ToDateTime(dtTimeTable.Rows[i]["w_finishD"]));

                if (squares == 0) continue;

                //하루의 마지막 일정이라면 조금 특별하게
                if (i == dtTimeTable.Rows.Count - 1)
                {
                    //다음날까지 이어지는 일정이라면
                    if ((start + squares) >= 48)
                        CreateMyMetroTile((dtTimeTable.Rows[i]["w_classify"]).ToString(), 48 - start);
                    else
                    {

                        CreateMyMetroTile((dtTimeTable.Rows[i]["w_classify"]).ToString(), squares);
                        now_stack += squares;

                        CreateMyMetroTile("rest", 48 - (start + squares));
                        return;
                    }

                }

                //바로 이어지는 일정이 없다면 하나 먼저 만들고
                if (start > now_stack)
                {
                    CreateMyMetroTile("rest", start - now_stack);
                    now_stack = start;
                }
                CreateMyMetroTile((dtTimeTable.Rows[i]["w_classify"]).ToString(), squares);
                now_stack += squares;
            }

        }
        private int ChangeMyDateToStartInt(DateTime dt)
        {

            //30분 기준
            return (dt.Hour * 2) + (dt.Minute / 30);
        }
        private int HowManySquares(DateTime dt1, DateTime dt2)
        {
            //30분기준
            return ChangeMyDateToStartInt(dt2) - ChangeMyDateToStartInt(dt1);
        }

        private void CreateMyMetroTile(string w_class, int squares)
        {

            myMetroTiles.Add(new MyMetroTile(squares));
            roundPanel6.Controls.Add(myMetroTiles.Last());
            myMetroTiles.Last().Dock = DockStyle.Bottom;
            myMetroTiles.Last().TextAlign = ContentAlignment.MiddleCenter;

            switch (w_class)
            {
                case "produce":
                    myMetroTiles.Last().Style = MetroFramework.MetroColorStyle.Green;
                    myMetroTiles.Last().Text = "생산작업";
                    break;
                case "preserve":
                    myMetroTiles.Last().Style = MetroFramework.MetroColorStyle.Blue;
                    myMetroTiles.Last().Text = "장비 예방정비";

                    break;
                case "repair":
                    myMetroTiles.Last().Style = MetroFramework.MetroColorStyle.Yellow;
                    myMetroTiles.Last().Text = "장비 수리작업";

                    break;
                default:
                    myMetroTiles.Last().Style = MetroFramework.MetroColorStyle.Silver;
                    myMetroTiles.Last().Text = "장비 비가동 상태";

                    break;
            }

        }

        #region < (타이머) REALTIME 테이블 레이블 중 기준치를 초과하는 레이블을 DETECTION 테이블에 삽입 및 온도,습도,진동,소리 출력 >
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 주기적으로 실행할 코드를 여기에 작성

            // REALTIME과 MACHINE 테이블에서 레이블 출력
            string sSqlSelectTemp = "SELECT A.M_ID, B.R_TEMP, B.R_VOL, B.R_HUM, B.R_VIB" +
                                    "  FROM MACHINE AS A, REALTIME AS B" +
                                   $"  WHERE A.M_ID = B.M_ID "+
                                   $"   AND (M_FAC = '{Commons.DMFac}' AND M_WORKP = '{Commons.DMWorkP}' AND M_NAME = '{Commons.DMName}')";
            SqlDataAdapter adapterTemp = new SqlDataAdapter(sSqlSelectTemp, sCon);
            adapterTemp.Fill(dtDetectData);

            RealTimeMonitor.OperState(Commons.DMFac, Commons.DMWorkP, Commons.DMName);
            
            // 출력된 레이블이 없으면 None
            if (dtDetectData.Rows.Count == 0)
            {
                txtTemp.Text = "None";
                txtVol.Text = "None";
                txtHum.Text = "None";
                txtVib.Text = "None";
            }

            else
            {
                // 출력된 레이블 중 가장 마지막 값을 LABEL에 출력
                txtTemp.Text = $"{dtDetectData.Rows[dtDetectData.Rows.Count - 1][1].ToString()}℃ ";
                txtHum.Text = $"{dtDetectData.Rows[dtDetectData.Rows.Count - 1][2].ToString()}%";
                txtVib.Text = $"{dtDetectData.Rows[dtDetectData.Rows.Count - 1][3].ToString()} Hz";
                txtVol.Text = $"{dtDetectData.Rows[dtDetectData.Rows.Count - 1][4].ToString()} dB(V)";


                //정상가동확률
                Calcul_Possiblity((int)dtDetectData.Rows[dtDetectData.Rows.Count - 1][1], (int)dtDetectData.Rows[dtDetectData.Rows.Count - 1][2],
                  (int)dtDetectData.Rows[dtDetectData.Rows.Count - 1][4], (int)dtDetectData.Rows[dtDetectData.Rows.Count - 1][3]);
                // 출력된 레이블 중 이상치가 존재하는지 확인
                // 존재하면 detection 테이블에 삽입
                for (int j = 1; j < dtDetectData.Columns.Count; j++)
                {
                    if (j == 1 && Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][j]) > tempStd)     // 온도가 이상치인지 확인
                    {
                        ideal = 1;
                    }
                    if (j == 2 && Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][j]) > volStd)      // 습도가 이상치인지 확인
                    {
                        ideal = 1;
                    }
                    if (j == 3 && Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][j]) > humStd)      // 진동이 이상치인지 확인
                    {
                        ideal = 1;
                    }
                    if ((j == 4) && (Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][j]) > vibStd))  // 소리가 이상치인지 확인
                    {
                        ideal = 1;
                    }
                    if (ideal == 1)     // 온도, 습도, 진동, 소리 중 하나라도 기준치 이상이면 ideal = 1
                    {
                        // detection 테이블에 레이블 삽입
                        sSqlSelectTemp = "INSERT INTO DETECTION " +
                                         $" VALUE       {Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][0])}," +        //M_ID
                                         $"             {Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][1])}," +        //TEMP
                                         $"             {Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][2])}," +        //HUM
                                         $"             {Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][3])}," +        //VIB
                                         $"             {Convert.ToInt32(dtDetectData.Rows[dtDetectData.Rows.Count - 1][4])}";          //VOL
                        adapterTemp = new SqlDataAdapter(sSqlSelectTemp, sCon);

                        ideal = 0;      // ideal 초기화
                    }
                }
            }

            if (Commons.refresh)
            {
                // Hello_Load( sender,  e);
                for (int i = 0; i < warningTextBoxes.Length; i++)
                {
                    warningTextBoxes[i].Text = string.Empty;
                }
                WarningM(tempStd, volStd, humStd, vibStd);
                Commons.refresh = false;
            }
            
        }
        #endregion

        #region < [경고] 글꼴 색 변경 메소드 >
        public static void WarningTextColor(RichTextBox textBox)
        {
            string fullText = textBox.Text;
            string warningText = "[경고]";

            int warningStartIndex = fullText.IndexOf(warningText);
            int warningEndIndex = warningStartIndex + warningText.Length;

            if (warningStartIndex >= 0)
            {
                textBox.Select(warningStartIndex, warningText.Length);
                textBox.SelectionColor = Color.Red;
            }
        }
        #endregion

        #region < 기준치 가져오기 메소드 >
        public static void StdSelect()
        {
            try
            {
                sCon.Open();
                dtStandard.Clear();

                string sSqlSelect = "SELECT TEMP_SCALE, VOL_SCALE, HUM_SCALE, VIB_SCALE" +
                                    "   FROM FLAG";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dtStandard);

                tempStd = (int)dtStandard.Rows[0][0];
                volStd = (int)dtStandard.Rows[0][1];
                humStd = (int)dtStandard.Rows[0][2];
                vibStd = (int)dtStandard.Rows[0][3];
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

        #endregion

        #region < 경고알림메세지 출력 메소드 >
        public static void WarningM(int tempStd, int volStd, int humStd, int vibStd)
        {   
            // 그리드 데이터 초기화 
            dtIdealValue.Clear();
            dtWarningM.Clear();      

            // 기준치 이상인 레이블 출력
            string sSqlSelect = "SELECT A.M_NAME, B.M_TEMP, B.M_VOL, B.M_HUM, B.M_VIB, DETECT" +
                                "   FROM MACHINE AS A, DETECTION B" +
                                "   WHERE A.M_ID = B.M_ID " +
                               $"       AND (B.M_TEMP > {tempStd} OR B.M_VOL > {volStd} OR B.M_HUM >{humStd} OR B.M_VIB > {vibStd}) " +
                               $" order by detecT desc";

            SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
            adapter.Fill(dtIdealValue);

            // 이상치 존재 데이터테이블 검사해서 경고알림을 이상치여부변수에 삽입
            for (int i = 0; i < dtIdealValue.Rows.Count; i++)
            {
                for (int j = 1; j < dtIdealValue.Columns.Count; j++)
                {
                    if (j == 1 && Convert.ToInt32(dtIdealValue.Rows[i][j]) > tempStd)
                    {
                        tempTrb = $"'{dtIdealValue.Rows[i][0]}' 온도 {tempStd}℃ 초과 알림 \r\n('{dtIdealValue.Rows[i][5]}')\r\n";
                    }
                    if (j == 2 && Convert.ToInt32(dtIdealValue.Rows[i][j]) > volStd)
                    {
                        volTrb = $"'{dtIdealValue.Rows[i][0]}' 소리 {volStd}dB(V) 초과 알림 \r\n('{dtIdealValue.Rows[i][5]}')\r\n";
                    }
                    if (j == 3 && Convert.ToInt32(dtIdealValue.Rows[i][j]) > humStd)
                    {
                        humTrb = $"'{dtIdealValue.Rows[i][0]}' 습도 {humStd}%초과 알림 \r\n('{dtIdealValue.Rows[i][5]}')\r\n";
                    }
                    if (j == 4 && Convert.ToInt32(dtIdealValue.Rows[i][j]) > vibStd)
                    {
                        vibTrb = $"'{dtIdealValue.Rows[i][0]}' 진동 {vibStd}Hz초과 알림 \r\n('{dtIdealValue.Rows[i][5]}')";
                    }
                }
                if (tempTrb != "" || volTrb != "" || humTrb != "" || vibTrb != "")
                {
                    dtWarningM.Rows.Add($"[경고] \r\n {tempTrb}{volTrb}{humTrb} {vibTrb}");          // 경고알림메세지 데이터테이블에 경고알림메세지 삽입
                }
                else
                {
                    return;
                }
                tempTrb = "";
                volTrb = "";
                humTrb = "";
                vibTrb = "";
            }

            // 텍스트박스에 경고알림메세지 출력
            for (int i = 0; i < dtWarningM.Rows.Count; i++)
            {
                if (i >= warningTextBoxes.Length) break;          // 배열의 길이를 초과할 경우 처리 중단

                if (warningTextBoxes[i].Text == "")
                {
                    warningTextBoxes[i].Text = dtWarningM.Rows[i][0].ToString();
                    WarningTextColor(warningTextBoxes[i]);
                }
                else
                {
                    break;
                }
            }
        }
        #endregion

        public Hello()
        {
            InitializeComponent();
            InitializeChart();

            // 경고알림 출력할 텍스트박스 배열
            warningTextBoxes = new RichTextBox[]
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
            StdSelect();

            selectedDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //처음로드할때 현재날짜로

        }

        private void Hello_Load(object sender, EventArgs e)
        {
            Commons.DefaultM();

            txtmName.Text = $"{Commons.DMFac} {Commons.DMWorkP} {Commons.DMName}";

            dtWarningM.Columns.Add("warningMessage", typeof(string));        // 경고알림메세지 데이터테이블에 열 추가

            // 경고알림 메세지 출력
            try
            {
                // 데이터베이스 오픈
                sCon.Open();
                WarningM(tempStd, volStd, humStd, vibStd);
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                sCon.Close();
            }
            selectedDate_ValueChanged(null, null);
        }
        //확률계산
        public void Calcul_Possiblity(int temp, int hum, int snd, int vib)
        {
            // 온도 범위
            int minTemperature = 20;
            int maxTemperature = 50;

            // 습도 범위
            int minHumidity = 0;
            int maxHumidity = 30;

            // 소리 범위
            int minSound = 0;
            int maxSound = 30;

            // 진동 범위
            int minVibration = 0;
            int maxVibration = 30;

            // 난수 생성을 위한 Random 객체 생성

            // 무작위 온도, 습도, 소리, 진동 값 생성
            int temperature = temp;
            int humidity = hum;
            int sound = snd;
            int vibration = vib;



            // 기준 온도, 습도, 소리, 진동 값
            int baseTemperature = 25;
            int baseHumidity = 15;
            int baseSound = 15;
            int baseVibration = 15;

            // 기준과 주어진 값들의 차이를 구함
            int temperatureDifference = Math.Abs(baseTemperature - temperature);
            int humidityDifference = Math.Abs(baseHumidity - humidity);
            int soundDifference = Math.Abs(baseSound - sound);
            int vibrationDifference = Math.Abs(baseVibration - vibration);

            // 각각의 차이를 정규화하여 최종 확률 계산
            double temperatureProbability = 1 - Math.Min(1, (double)temperatureDifference / (maxTemperature - minTemperature));
            double humidityProbability = 1 - Math.Min(1, (double)humidityDifference / (maxHumidity - minHumidity));
            double soundProbability = 1 - Math.Min(1, (double)soundDifference / (maxSound - minSound));
            double vibrationProbability = 1 - Math.Min(1, (double)vibrationDifference / (maxVibration - minVibration));

            // 최소 확률인 40%로 설정
            const double minimumProbability = 0.4;

            // 각각의 확률 중 가장 낮은 값을 선택
            double minProbability = Math.Min(temperatureProbability, Math.Min(humidityProbability, Math.Min(soundProbability, vibrationProbability)));

            // 모든 값이 범위 내에 있으면 최소 확률과 비교하여 더 큰 값을 선택
            double overallProbability = (temperature >= minTemperature && temperature <= maxTemperature) &&
                                        (humidity >= minHumidity && humidity <= maxHumidity) &&
                                        (sound >= minSound && sound <= maxSound) &&
                                        (vibration >= minVibration && vibration <= maxVibration)
                ? Math.Max(minimumProbability, minProbability)
                : 0;

            Bar_possible.Text = $"{(overallProbability * 100).ToString("0")}";

            // Console.WriteLine($"정상 가동 확률: {overallProbability * 100}%");
        }
    }
}
