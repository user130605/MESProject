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

namespace FormList
{
    public partial class FacilityManage : BaseChildForm
    {

    

        //데이터베이스 접속
        SqlConnection sCon = new SqlConnection(Commons.DbPath);

        DataTable dtTemp = new DataTable();
        public FacilityManage()
        {
            InitializeComponent();
        }

        public override void DoNew()
        {
            Facility_register M01 = new Facility_register();


            M01.ShowDialog(); //모달창 ,동기식 비밀번호 변경 창 호출
                              //비밀번호 변경 창이 닫히기 전까지는 해당 메서드 로직을 수행 하지않고 기다림.

        }

        public override void DoInquire()
        {
            try
            {
                sCon.Open();
                //그리드 데이터 초기화
                dtTemp.Clear();

                //조회조건의 데이터를 변수에 담기
                string s_m_id = txt_m_id.Text;  //사용자가 입력한 품목코드
                string s_m_name = txt_m_name.Text;  //사용자가 입력한 품목 명
                string s_m_fac = cbx_m_fac.SelectedValue.ToString();     //사용자가 입력한 출시 시작 일자
                string s_m_place = cbx_m_place.SelectedValue.ToString();       //사용자가 입력한 출시 종료 일자
                string s_m_preSerMth = cbx_m_preSerMth.SelectedValue.ToString();  //선택한 콤보박스(품목 유형) 코드값.



                //조회 해올 데이터 베이스에 전달할 명령 문 작성
                string sSqlSelect = "SELECT *                                        " +
                                    "FROM machine                              " +
                                    $"WHERE m_id LIKE '%{s_m_id}%'            " +
                                    $"AND m_name LIKE   '%{s_m_name}%'            " +
                                    $"AND m_fac LIKE   '%{s_m_fac}%'            " +
                                    $"AND m_workP LIKE   '%{s_m_place}%'            " +
                                    $"AND m_preSerMth LIKE   '%{s_m_preSerMth}%'            ";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dtTemp);
                //데이터베이스에서 받아온 결과를 그리드에 표현
                Grid_FM.DataSource = dtTemp;


            }
            catch(Exception ex)
            {

            }
            finally { sCon.Close(); }
        }







        private void btn_edit_F_Click(object sender, EventArgs e)
        {
            //설비 등록 선택시
            Facility_edit M01 = new Facility_edit();


            M01.ShowDialog(); //모달창 ,동기식 비밀번호 변경 창 호출
                              //비밀번호 변경 창이 닫히기 전까지는 해당 메서드 로직을 수행 하지않고 기다림.
        }

        private void FacilityManage_Load(object sender, EventArgs e)
        {
            //1.그리드에 세팅이 될 데이터 테이블의 컬럼 설정.
            //1.그리드에 세팅이 될 데이터 테이블의 컬럼 설정.
            dtTemp.Columns.Add("m_id", typeof(string));  //장비ID
            dtTemp.Columns.Add("m_name", typeof(string));  //장비 이름
            dtTemp.Columns.Add("m_fac", typeof(string));
            dtTemp.Columns.Add("m_workP", typeof(string));   //설치작업장
            dtTemp.Columns.Add("m_manufac", typeof(string));  //제조사
            dtTemp.Columns.Add("m_preSerMth", typeof(string));  //예방정비방법
            dtTemp.Columns.Add("m_preSerStd", typeof(string));  


            //dtTemp.Columns.Add("m_id", typeof(string));  //장비ID
            //dtTemp.Columns.Add("m_name", typeof(string));  //장비 이름
            //dtTemp.Columns.Add("m_manufac", typeof(string));  //제조사
            //dtTemp.Columns.Add("m_preSerMth", typeof(string));  //예방정비방법
            //dtTemp.Columns.Add("m_place", typeof(string));   //설치작업장

            //2. 컬럼이 설정된 데이터 테이블을 그리드뷰에 셋팅(매핑)
            //DataSource : DataTable 의 내용을 기반으로 그리드에 행과 열의 디자인을 표현하는 속성
            Grid_FM.DataSource = dtTemp;

            //3. 그리드에 표현될 헤더 (컬럼의 제목) 의 명칭을 설정.

            Grid_FM.Columns["m_id"].HeaderText = " 장비 ID";
            Grid_FM.Columns["m_name"].HeaderText = "장비 이름";
            Grid_FM.Columns["m_fac"].HeaderText = "공장";
            Grid_FM.Columns["m_workP"].HeaderText = "작업장";
            Grid_FM.Columns["m_manufac"].HeaderText = "제조사";
            Grid_FM.Columns["m_preSerMth"].HeaderText = "예방정비 방법";
            Grid_FM.Columns["m_preSerStd"].HeaderText = "예방정비 기준량";

            //4. 컬럼 폭지정
            Grid_FM.Columns[0].Width = 100;
            Grid_FM.Columns[1].Width = 150;
            Grid_FM.Columns[2].Width = 150;
            Grid_FM.Columns[3].Width = 150;
            Grid_FM.Columns[4].Width = 250;
            Grid_FM.Columns[5].Width = 150;
            Grid_FM.Columns[6].Width = 100;





            //콤보박스 설정

            cbx_m_fac.DisplayMember = "Name";
            cbx_m_fac.ValueMember = "Value";
            var fac_items = new[]
            {
                new{Name= "전체", value =""},
                new{Name= "진주공장", value ="진주공장"},
                new{Name= "창원공장", value ="창원공장"},
                new{Name= "부산공장", value ="부산공장"},
            };
            cbx_m_fac.DataSource = fac_items;




            cbx_m_preSerMth.DisplayMember = "Name";
            cbx_m_preSerMth.ValueMember = "Value";

            var Mth_items = new[]
            {
                new{Name ="전체" , value =""},
                new{ Name="가동시간기반" , value="usage" },
                new{ Name="주기기반" , value="period" }
            };

            cbx_m_preSerMth.DataSource = Mth_items;



            cbx_m_place.DisplayMember = "Name";
            cbx_m_place.ValueMember = "Value";

            var place_items = new[]
            {
                new{Name ="전체" , value =""},
                new{ Name="반제품작업장" , value="반제품작업장" },
                new{ Name="제품작업장" , value="제품작업장" }
            };
            cbx_m_place.DataSource = place_items;
        }

        private void btn_register_F_Click(object sender, EventArgs e)
        {
            Facility_register M01 = new Facility_register();


            M01.ShowDialog(); //모달창 ,동기식 비밀번호 변경 창 호출
                              //비밀번호 변경 창이 닫히기 전까지는 해당 메서드 로직을 수행 하지않고 기다림.
        }

    }

    

}
