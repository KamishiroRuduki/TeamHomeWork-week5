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
    public partial class UserPassword : System.Web.UI.Page
    {
        private static string NewPwd = string.Empty;
        private static string orgpwd = string.Empty;
        private static string cpwd = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManger.IsLogined())
            {
                Response.Redirect("/login.aspx");
                return;
            }
            string account = this.Session["UserLoginInfo"] as string;
            var cUser = AuthManger.GetCurrentUser();
            if (cUser == null)
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }
            if (!this.IsPostBack)
            {

                string idtext = this.Request.QueryString["ID"];
                if (idtext!=null)
                {
                    var drAcc = UserInfoManager.GETUserInfoData(idtext);
                    if (drAcc == null)
                    {
                        return;
                    }
                    else
                    {
                        this.lblAccount.Text = drAcc["Account"].ToString();
                        //this.txtAmount.Text = drAcc["Amount"].ToString();
                        //this.txtCaption.Text = drAcc["Caption"].ToString();
                        //this.txtDesc.Text = drAcc["Body"].ToString();
                    }
                }


            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();
            if (!this.CheckInput(out msgList))
            {
                this.ltMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            UserInfoModel currentUser = AuthManger.GetCurrentUser();
            if (currentUser == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }

            string idtext = this.Request.QueryString["ID"];
            DataRow dr = UserInfoManager.GETUserInfoData(idtext);
            string accountText = currentUser.Account;
            string userID = currentUser.ID;
            string pwd = dr["PWD"].ToString();
            orgpwd = this.txtPWD.Text;
            cpwd = this.txtCurretPWD.Text;
            NewPwd = this.txtNewPWD.Text;



            
            if ( string.Compare(orgpwd, cpwd) == 0)
            {
                if( string.Compare(orgpwd, pwd) != 0 || string.Compare(cpwd, pwd) != 0)
                {
                    this.ltMsg.Text = "密碼不正確或是原密碼和確認密碼不一致";
                    return;
                }
                else
                {
                    this.btnChange.Visible = false;
                    this.btnNo.Visible = true;
                    this.btnYes.Visible = true;
                    this.txtCurretPWD.Visible = false;
                    this.txtPWD.Visible = false;
                    this.txtNewPWD.Visible = false;
                    this.lblAccount.Visible = false;
                    this.Label1.Visible = false;
                    this.Label2.Visible = false;
                    this.Label3.Visible = false;
                    this.Label4.Visible = false;
                    this.txtPWD.Text = orgpwd;
                    this.txtCurretPWD.Text = cpwd;
                    this.txtNewPWD.Text = NewPwd;
                    this.ltMsg.Text = "是否確認變更密碼";
                }

            }
            else
            {
                this.ltMsg.Text = "密碼不正確或是原密碼和確認密碼不一致";
                return;
            }
     

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {

            UserInfoManager.UpatePassword(this.Request.QueryString["ID"], NewPwd);
            Response.Redirect($"/SystemAdmin/UserDetail.aspx?ID={this.Request.QueryString["ID"]}");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/SystemAdmin/UserDetail.aspx?ID={this.Request.QueryString["ID"]}");
        }
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();
            if (string.IsNullOrWhiteSpace(this.txtPWD.Text))
            {
                msgList.Add("原密碼不能為空");
            }

            if (string.IsNullOrWhiteSpace(this.txtCurretPWD.Text))
            {
                msgList.Add("確認密碼不能為空");
            }

            if (string.IsNullOrWhiteSpace(this.txtNewPWD.Text))
            {
                msgList.Add("新密碼不能為空");
            }

            if(this.txtNewPWD.Text.Length<8 || this.txtNewPWD.Text.Length > 16)
            {
                msgList.Add("新密碼長度不能小於8或大於16");
            }
            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }
    }
}