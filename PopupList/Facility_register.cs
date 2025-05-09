using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PopupList
{
    public partial class Facility_register : MetroFramework.Forms.MetroForm
    {
        DataTable dtTemp = new DataTable();

        SqlConnection sCon = new SqlConnection(Commons.DbPath);
        public Facility_register()
        {
            InitializeComponent();
        }
        private void Facility_register_Load(object sender, EventArgs e)
        {
            //1.그리드에 세팅이 될 데이터 테이블의 컬럼 설정.
            dtTemp.Columns.Add("m_id", typeof(string));  //장비ID
            dtTemp.Columns.Add("m_name", typeof(string));  //장비 이름
            dtTemp.Columns.Add("m_fac", typeof(string));
            dtTemp.Columns.Add("m_manufac", typeof(string));  //제조사
            dtTemp.Columns.Add("m_preSerMth", typeof(string));  //예방정비방법
            dtTemp.Columns.Add("m_place", typeof(string));   //설치작업장
            dtTemp.Columns.Add("m_preSerStd", typeof(string));

            //2. 컬럼이 설정된 데이터 테이블을 그리드뷰에 셋팅(매핑)
            //DataSource : DataTable 의 내용을 기반으로 그리드에 행과 열의 디자인을 표현하는 속성
            Grid_Fr.DataSource = dtTemp;

            //3. 그리드에 표현될 헤더 (컬럼의 제목) 의 명칭을 설정.

            Grid_Fr.Columns["m_id"].HeaderText = " 장비 ID";
            Grid_Fr.Columns["m_name"].HeaderText = "장비 이름";
            Grid_Fr.Columns["m_fac"].HeaderText = "공장";
            Grid_Fr.Columns["m_manufac"].HeaderText = "제조사";
            Grid_Fr.Columns["m_preSerMth"].HeaderText = "예방정비 방법";
            Grid_Fr.Columns["m_place"].HeaderText = "작업장";
            Grid_Fr.Columns["m_preSerStd"].HeaderText = "예방정비 기준량";


            // 컬럼의 폭 지정
            Grid_Fr.Columns[0].Width = 100;
            Grid_Fr.Columns[1].Width = 100;
            Grid_Fr.Columns[2].Width = 100;
            Grid_Fr.Columns[3].Width = 150;
            Grid_Fr.Columns[4].Width = 100;
            Grid_Fr.Columns[5].Width = 100;
            Grid_Fr.Columns[6].Width = 100;


            //콤보박스안 데이터 설정 

            var fac_items = new[] { "진주공장", "창원공장", "부산공장" };
            cbx_m_fac.DataSource = fac_items;
            
            cbx_m_preSerMth.DisplayMember = "Name";
            cbx_m_preSerMth.ValueMember = "Value";

            var Mth_items = new[]
            {
                new{ Name="가동시간기반" , value="usage" },
                new{ Name="주기기반" , value="period" }
            };

            cbx_m_preSerMth.DataSource = Mth_items;


            var place_items = new[] { "반제품 작업장", "제품작업장"};
            cbx_m_place.DataSource = place_items;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //ID 값이 중복될때 밸리데이션 체크
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                if (dtTemp.Rows[i][0].ToString() == txt_m_id.Text ) return;
            }

            // 품목 코드, 출시 일자 정보 누락 시 체크 밸리데이션;

            string sMessage = string.Empty;
            if (txt_m_id.Text == "") sMessage += "장비 ID";
            if (txt_m_name.Text == "") sMessage += " 장비이름";
            if (sMessage != "")
            {
                MessageBox.Show($"{sMessage} 를 입력하지 않았습니다.");
              
                return;
            }


            dtTemp.Rows.Add(txt_m_id.Text, txt_m_name.Text,cbx_m_fac.Text, txt_m_manufac.Text, cbx_m_preSerMth.Text, cbx_m_place.Text, txtPreserStd.Text);
            txt_m_id.Clear();
            txt_m_name.Clear();
            txt_m_manufac.Clear();
            txtPreserStd.Clear();
            //cbx_m_place.SelectedIndex = 0;
           // cbx_m_preSerMth.SelectedIndex = 0;
            //dtTemp 행에 입력값 입력


        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //삭제 될것이 없을때 밸리데이션 체크
            if (dtTemp.Rows.Count == 0) return;

            dtTemp.Rows[Grid_Fr.CurrentCell.RowIndex].Delete(); //그리드에서 선택된 셀 제거
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            
                DataTable dtChange = new DataTable();

                //품목의 저장보가 갱신괸 데이터를 추출
                dtChange = dtTemp.GetChanges();

                //수정한 행이 없을경우
                if (dtChange.Rows.Count == 0) return;


                if (MessageBox.Show("변경된 내역을 등록하시겠습니까 ?", "데이터저장", MessageBoxButtons.YesNo) == DialogResult.No)
                { return; }

                //1.DataBase 오픈
                sCon.Open();

                //2.SQL Command 객체 생성 (U/D/I)
                SqlCommand cmd = new SqlCommand();
                //3.데이터 베이스에 접속 정보 전달
                cmd.Connection = sCon;
                //4. 트랜잭션 설정, (일광승인 , 일괄복원)
                cmd.Transaction = sCon.BeginTransaction();
                // 트랜잭션(Transaction)
                // .데이터 갱신 내역을 승인 또는 복구 하는 기능.
                // .데어터의 일관성 (하나의 데이터라도 오류가 발생할 경우 전체 데이터를 복원하여 일부 데이터만 격차가 
                //  발생하는 현상을 막기위함)




                string s_m_id = string.Empty; //장비ID
                string s_m_name = string.Empty; //장비이름
                string s_m_fac = string.Empty; //공장
                string s_m_manufac = string.Empty; //제조사
                string s_m_preSerMth = string.Empty; //예방정비 방법
                string s_m_place = string.Empty;  //설치작업장
                                                  //  string sProdDate = string.Empty; //출시일자.

            int s_m_preSerStd = 0;



            //DataRow : 데이터 테이블의 행을 단위별로 담는 클래스.
            try
                {

                    string Sql = string.Empty;  //행의상태에 따라 처리할 SQL 구문.
                    string sMessage = string.Empty; //필수입력값 누락여부.

                    foreach (DataRow dr in dtChange.Rows) //모든행 만큼 반복
                    {
                        // 변경된 행을 하나씩 추출하여 행의 상태에 따라서 데이터베이스 처리.
                        switch (dr.RowState)
                        {
                            case DataRowState.Deleted:
                                dr.RejectChanges(); //삭제되기전 상태의 데이터로 원상복구.
                                Sql = $"DELETE machine WHERE m_id = '{dr["m_id"]}'";
                                break;
                            case DataRowState.Added:
                                s_m_id = dr["m_id"].ToString();
                                s_m_name = dr["m_name"].ToString();
                                s_m_fac = dr["m_fac"].ToString();
                                s_m_manufac = dr["m_manufac"].ToString();
                                s_m_place = dr["m_place"].ToString();
                                 s_m_preSerMth = dr["m_preSerMth"].ToString();
                            s_m_preSerStd = Convert.ToInt32(dr["m_preSerStd"]);
                            //삼항 연산자 true false 에 따른 비교 분기.
                            // 단종 여부에 값이 없을 경우 N 아닐 경우는 Y (무조건 N, 또는 Y 만 입력 가능 하도록)

                            //  sProdDate = dr["PRODDATE"].ToString();



                            // 데이터가 없는경우 INSERT
                            Sql = "INSERT INTO machine (m_id,      m_name,     m_fac,     m_workP,     m_manufac,     m_preSerMth,    m_preSerStd)" +
                                                 $"  VALUES('{s_m_id}','{s_m_name}','{s_m_fac}', '{s_m_place}','{s_m_manufac}','{s_m_preSerMth}', '{s_m_preSerStd}');";



                                break;
                                //case DataRowState.Modified:
                                //    sItemCode = dr["ITEMCODE"].ToString();
                                //    sItemName = dr["ITEMNAME"].ToString();
                                //    sItemType = dr["ITEMTYPE"].ToString();
                                //    sItemDesc = dr["ITEMDESC"].ToString();
                                //    //삼항 연산자 true false 에 따른 비교 분기.
                                //    // 단종 여부에 값이 없을 경우 N 아닐 경우는 Y (무조건 N, 또는 Y 만 입력 가능 하도록)
                                //    sEndFlag = dr["ENDFLAG"].ToString() == "" ? "N" : "Y";
                                //    sProdDate = dr["PRODDATE"].ToString();

                                //    // 품목 코드, 출시 일자 정보 누락 시 체크 밸리데이션;

                                //    if (sItemCode == "") sMessage += "품목 코드";
                                //    if (sProdDate == "") sMessage += " 출시일자";
                                //    if (sMessage != "")
                                //    {
                                //        MessageBox.Show($"{sMessage} 를 입력하지 않았습니다.");
                                //        cmd.Transaction.Rollback();
                                //        return;
                                //    }


                                //    Sql = "UPDATE TB_ItemMaster                             " +
                                //              $"    SET ITEMNAME  = '{sItemName}',            " +
                                //              $"        ITEMTYPE  = '{sItemType}',            " +
                                //              $"        ITEMDESC = '{sItemDesc}',           " +
                                //              $"        ENDFLAG   = '{sEndFlag}',             " +
                                //              $"        PRODDATE  = '{sProdDate}',            " +
                                //              $"        EDITOR    = 'ADMIN',  " +
                                //              $"        EDITDATE  = GETDATE()                 " +
                                //              $"  WHERE ITEMCODE  = '{sItemCode}'             ";
                                //    break;
                        }
                        cmd.CommandText = Sql; //커맨드에 실행할 SQL 명령 등록
                        cmd.ExecuteNonQuery(); //커맨드를 실행.
                    }

                    //정상등록 완료.
                    cmd.Transaction.Commit();

                    MessageBox.Show("정상 처리 되었습니다.");

                dtTemp.Clear();

                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback(); //예외상황 발생시 복구.
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sCon.Close();
                }
            


            //sql 일괄 업데이트 로직
        }


    }
}
