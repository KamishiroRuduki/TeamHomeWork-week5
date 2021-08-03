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

            var dt = UserInfoManager.GetUserList();
            if (dt.Rows.Count > 0)
            {
                if (UserInfoManager.IsAdministrator(this.Session["UserLoginInfo"].ToString()))
                    btnAdd.Visible = true;

                this.gvUserList.DataSource = dt;
                this.gvUserList.DataBind();
            }
            else
            {
                this.gvUserList.Visible = false;
                this.plcNoData.Visible = true;

            }
                    }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!UserInfoManager.IsAdministrator(this.Session["UserLoginInfo"].ToString()))
            {
                Response.Redirect("/SystemAdmin/UserList.aspx");
                return;
            }

            else
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