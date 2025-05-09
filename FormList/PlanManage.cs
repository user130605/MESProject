

using Calendar.NET;
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

namespace FormList
{
    public partial class PlanManage : BaseChildForm
    {

        SqlConnection sqlConnection = new SqlConnection(Commons.DbPath); //DB경로
        string sqlStatement;//sql문 작성용 string변수
        DataTable machineTable = new DataTable(); //장비정보 저장테이블
        int number_of_machine = 0; //장비 총 개수

        public PlanManage()
        {
            InitializeComponent();
        }

        //폼 로드될 때
        private void PlanManage_Load(object sender, EventArgs e)
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

            AAAAAA();
            #region < 발표용 임시 스케쥴 >
            //var aaa = new CustomEvent
            //{
            //    Date = new DateTime(2023, 7, 21, 8, 0, 0),
            //    EventLengthInHours = 2,
            //    EventText = "'C'장비 예비보전",
            //    EventColor = Color.Yellow,
            //    EventTextColor = Color.Black,
            //    
            //};
            //
            //myCalendar.AddEvent(aaa);
            //var bbb = new CustomEvent
            //{
            //    Date = new DateTime(2023, 7, 22, 9, 30, 0),
            //    EventLengthInHours = 2,
            //    EventText = "''D'장비 수리",
            //    EventColor = Color.Red
            //};
            //myCalendar.AddEvent(bbb);
            #endregion
        }


        private void AAAAAA()
        {
            //이제 여기에 정비나 고장 작업지시 보여주는 코드



            try
                {
                sqlConnection.Open();

                //장비의 총개수 가져오기
                sqlStatement = $"select * from work left join machine on work.m_id = machine.m_id where w_classify in ('repair','preserve') order by work.m_id,w_startD";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStatement, sqlConnection);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                string eventText = string.Empty; //어떤 이벤트인지
                Color eventColor = Color.Black; //어떤 색으로할지
                Color eventTextColor = Color.White;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (dt.Rows[i]["w_classify"].ToString() == "repair")
                    {
                        eventText = $"[{dt.Rows[i]["m_fac"]}]'{dt.Rows[i]["m_name"].ToString()}'장비 수리";
                        eventColor = Color.Red;
                    }
                    else if (dt.Rows[i]["w_classify"].ToString() == "preserve")
                    {
                        eventText = $"[{dt.Rows[i]["m_fac"]}]'{dt.Rows[i]["m_name"].ToString()}'장비 예방점검";
                        eventColor = Color.Green;
                    }

                    if (dt.Rows[i]["w_state"].ToString() == "done")
                        eventTextColor = Color.Black;

                    else if (dt.Rows[i]["w_state"].ToString() == "ready")
                        eventTextColor = Color.White;
                    //아 왜 장비당 1개만 되는거지?????

                    //?????
                    var PreservationEvent = new CustomEvent
                    {
                        Date = Convert.ToDateTime(dt.Rows[i]["w_startD"]),
                        EventLengthInHours = 2, //여기 코드 추가해야할듯              
                        EventText = eventText + $"[{dt.Rows[i]["w_num"]}]",
                        EventColor = eventColor,
                        EventTextColor = eventTextColor
                            
                    };

                    myCalendar.AddEvent(PreservationEvent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }
                


        //예지보전스케줄 생성해주는 메서드
        private void CreatePredictiveMaintenance()
        {
            //예지보전이 생기면 // 원래 예정이던 예방정비는 뒤로 미뤄야겠지..
        }
    }
}
