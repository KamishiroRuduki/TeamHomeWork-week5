using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccountNote.DBSource;

namespace AccountingNote
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var AccountCountAndDate = AccountingManager.GetDateAndCount();
            var UserCount = UserInfoManager.GetUserCount();
            if (AccountCountAndDate == null || UserCount == null)
            {
                return;
            }
            //this.ltAccount.Text = cUser.Account;
            //this.ltName.Text = cUser.Name;
            //this.ltEmail.Text = cUser.Email;
            this.FirstTime.Text = AccountCountAndDate["FirstTime"].ToString();
            this.LastTime.Text = AccountCountAndDate["LastTime"].ToString();
            this.AccountCount.Text = AccountCountAndDate["AccountCount"].ToString();
            this.UserCount.Text = UserCount["UserCount"].ToString();
        }
    }
}