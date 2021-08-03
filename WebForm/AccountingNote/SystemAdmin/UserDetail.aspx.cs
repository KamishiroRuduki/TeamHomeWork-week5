﻿using System;
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
    public partial class UserDetail : System.Web.UI.Page
    {
        private static Label lbl = new Label();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AuthManger.IsLogined())
            //if(!AuthManger.IsLogined())
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
            //if (!this.IsPostBack)
            //{
            // this.AccountPanel.Controls.Clear();
            if (this.Request.QueryString["ID"] == null && UserInfoManager.IsAdministrator(this.Session["UserLoginInfo"].ToString()))
            {
                TextBox tb = new TextBox();
                tb.ID = "tb";
                lbl.Text = "帳號:";
                AccountPanel.Controls.Add(lbl);
                AccountPanel.Controls.Add(tb);
                if (!this.IsPostBack)
                {
                    this.btnDel.Visible = true;
                    this.ddlActType.Visible = true;
                    this.lblDate.Visible = false;
                    this.lblLevel.Visible = false;

                }
            }
            else
            {
                this.btnDel.Visible = true;
                string idtext = this.Request.QueryString["ID"];
                int id;
                if (int.TryParse(idtext, out id))
                {
                    var drAcc = AccountingManager.GetAccounting(id, cUser.ID);
                    if (drAcc == null)
                    {
                        this.ltMsg.Text = "無資料";
                        this.btnDel.Visible = false;
                        this.btnSave.Visible = false;
                    }
                    else
                    {
                        this.ddlActType.SelectedValue = drAcc["ActType"].ToString();
                        // this.txtAccount.Text = drAcc["Account"].ToString();
                        this.txtName.Text = drAcc["Name"].ToString();
                        this.txtMail.Text = drAcc["Email"].ToString();
                        this.lblDate.Text = drAcc["CreateDate"].ToString();

                    }
                }

            }
            // }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
            TextBox txtbox = AccountPanel.FindControl("tb") as TextBox;
            string userID = currentUser.ID;
            string actTypeText = this.ddlActType.SelectedValue;
            string accountText = txtbox.Text;
            string nameText = this.txtName.Text;
            string emailText = this.txtMail.Text;

            int actType = Convert.ToInt32(actTypeText);


            string idtext = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idtext))
            {
                UserInfoManager.CreateUser(accountText, nameText, emailText, actType);
            }
            //else
            //{
            //    int id;
            //    if (int.TryParse(idtext, out id))
            //    {
            //        AccountingManager.UpateAccount(id, userID, caption, amount, actType, body);
            //    }
            //}
            Response.Redirect("/SystemAdmin/UserList.aspx");
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {

        }
        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();
            if (this.ddlActType.SelectedValue != "0" && this.ddlActType.SelectedValue != "1")
            {
                msgList.Add("Type必須是0或1");
            }

            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                msgList.Add("姓名不能為空");
            }

            if (string.IsNullOrWhiteSpace(this.txtMail.Text))
            {
                msgList.Add("Email不能為空");
            }

            errorMsgList = msgList;
            if (msgList.Count == 0)
                return true;
            else
                return false;
        }
    }
}