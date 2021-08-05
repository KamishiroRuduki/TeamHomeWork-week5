using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountNote.DBSource;
using System.Data;
using System.Drawing;
using AccountingNote.Auth;

namespace AccountingNote.SystemAdmin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManger.IsLogined())
            {
                Response.Redirect("/login.aspx");
                return;
            }
            var cUser = AuthManger.GetCurrentUser();
            if (cUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;

            }

            //if (UserInfoManager.IsAdministrator(this.Session["UserLoginInfo"].ToString()))
            //{

            //    var dt = UserInfoManager.GetUserList();
            //    if (dt.Rows.Count > 0)
            //    {
            //        if (UserInfoManager.IsAdministrator(this.Session["UserLoginInfo"].ToString()))
            //            btnAdd.Visible = true;

            //        this.gvUserList.DataSource = dt;
            //        this.gvUserList.DataBind();
            //    }
            //    else
            //    {
            //        this.gvUserList.Visible = false;
            //        this.plcNoData.Visible = true;

            //    }
            //}
            //else
            //{
                var dt = UserInfoManager.GetUserList();
                if (dt.Rows.Count > 0)
                {
                var dtPaged = this.GetPageDataTable(dt);
                this.gvUserList.DataSource = dtPaged;
                    this.gvUserList.DataBind();
                this.UcPager.TotalSize = dt.Rows.Count;
                this.UcPager.Bind();
            }
                else
                {
                    this.gvUserList.Visible = false;
                    this.plcNoData.Visible = true;

                }
          //  }

        }
        private int GetCurrectPage()
        {
            string pageText = Request.QueryString["Page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;
            if (!int.TryParse(pageText, out intPage))
                return 1;
            if (intPage <= 0)
                return 1;
            return intPage;
        }

        private DataTable GetPageDataTable(DataTable dt)
        {
            //  DataTable dtPaged = (dt.Rows.Count==0)?dt.Clone() : dt.Copy();
            DataTable dtPaged = dt.Clone();

            int startIndex = (this.GetCurrectPage() - 1) * 10;
            int endIndex = (this.GetCurrectPage()) * 10;
            // foreach( DataRow dr in dt.Rows)
            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;

            for (var i = startIndex; i < endIndex; i++)
            {

                DataRow dr = dt.Rows[i];
                var drNew = dtPaged.NewRow();
                foreach (DataColumn dc in dt.Columns)
                {
                    drNew[dc.ColumnName] = dr[dc];
                }

                dtPaged.Rows.Add(drNew);
            }
            return dtPaged;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (!UserInfoManager.IsAdministrator(this.Session["UserLoginInfo"].ToString()))
            //{
            //    Response.Redirect("/SystemAdmin/UserList.aspx");
            //    return;
            //}

            //else
                Response.Redirect("/SystemAdmin/UserDetail.aspx");
        }
        protected void gvUserList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lbl") as Label;
                //Literal ltl = row.FindControl("ltlActType") as Literal;
                var dr = row.DataItem as DataRowView;
                int userLevel = dr.Row.Field<int>("UserLevel");

                if (userLevel == 0)
                {
                    // ltl.Text = "支出";
                    lbl.Text = "管理者";
                }

                else
                {
                    //   ltl.Text = "收入";
                    lbl.Text = "一般會員";
                }

                if (dr.Row.Field<int>("UserLevel") == 0)
                {
                    lbl.ForeColor = Color.Red;
                }

            }
        }
    }
}