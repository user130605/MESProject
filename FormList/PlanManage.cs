
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
            CreatePreventiveMaintenance();
            #region < 발표용 임시 스케쥴 >
            var aaa = new CustomEvent
            {
                Date = new DateTime(2023, 7, 21, 8, 0, 0),
                EventLengthInHours = 2,
                EventText = "'C'장비 예비보전",
                EventColor = Color.Yellow,
                EventTextColor = Color.Black,
                
            };
            
            myCalendar.AddEvent(aaa);
            var bbb = new CustomEvent
            {
                Date = new DateTime(2023, 7, 22, 9, 30, 0),
                EventLengthInHours = 2,
                EventText = "''D'장비 수리",
                EventColor = Color.Red
            };
            myCalendar.AddEvent(bbb);
            #endregion
        }

        //예방정비스케줄 생성해주는 메서드
        private void CreatePreventiveMaintenance()
        {
            //모든 장비의 스케줄을 만들기위해 장비의 개수만큼 반복
            for(int i=0; i<number_of_machine; i++)
            {

                sqlStatement = "SELECT * " +                     
                         "FROM operation " +                                   // operation 테이블에서
                         $"WHERE m_id = {Convert.ToInt32(machineTable.Rows[i]["m_id"])} "+ // i번째장비만
                         "ORDER BY op_date DESC; ";                      // 최근날짜순으로
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlStatement, sqlConnection);
                DataTable dtTemp = new DataTable();
                sqlDataAdapter.Fill(dtTemp);


                //현재 장비가 operation테이블에 행이 없다면
                if (dtTemp.Rows.Count == 0) continue;

                //어떤장비가 현재 정비중인 상태면 다음 예방정비스케쥴 안만들것임.
                //현재 장비가 미가동이고 fix중이거나 preserve중이라면
                if (dtTemp.Rows[0]["op_classify"].ToString() == "off")
                    if (dtTemp.Rows[0]["op_reason"].ToString() == "fix" || dtTemp.Rows[0]["op_reason"].ToString() == "preserve")
                        continue;

                #region < 예방정비 만들기 >

                    // 최근정비일자 구하기
                    DateTime recent_preservation_date = DateTime.Now;
                DateTime next_preservation_date = DateTime.Now;

                    for(int j =0; j< dtTemp.Rows.Count; j++)
                    {
                        if (dtTemp.Rows[j]["op_reason"].ToString() == "fix" || dtTemp.Rows[j]["op_reason"].ToString() == "preserve")
                        {
                            // 장비가 fix나 preserve이후 operation의 시작date구하기 ( 즉 fix나 preserve가 끝난시각을 구하는 것.)
                            recent_preservation_date = Convert.ToDateTime(dtTemp.Rows[j - 1]["op_date"]);
                            break;
                        }
                    }
                //for문 다돌았는데 없으면 실행안되게 해야함. 나중에 구현합시다

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
                    //최근정비시각부터 현재시각까지 장비가동된 시간 구하기.(아직안만듬)
                    //임시코드
                    next_preservation_date = recent_preservation_date.AddDays(3);
                }
                else continue;

                //만약 다음예방정비시각이 현재시각보다 과거라면 당장 x시간후 예방정비하기
                if (next_preservation_date < DateTime.Now)
                    next_preservation_date.AddHours(1);

                  //스케줄 만들기
                  var PreservationEvent = new CustomEvent
                    {
                        Date = next_preservation_date,
                        EventLengthInHours = 2,
                        EventText = $"'{machineTable.Rows[i]["m_name"].ToString()}'장비 예방점검",
                        EventColor = Color.Green
                    };
                    myCalendar.AddEvent(PreservationEvent);
                    #endregion
                

                
            }
        }
    }
}
