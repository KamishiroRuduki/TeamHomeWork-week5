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
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (this.Session["UserLoginInfo"] == null)
            if(!AuthManger.IsLogined())
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

            var dt = AccountingManager.GetAccountingList(cUser.ID);
            if(dt.Rows.Count>0)
            {
                var dtPaged = this.GetPageDataTable(dt);
                this.gvAccountList.DataSource = dtPaged;
                this.gvAccountList.DataBind();
                this.UcPager.TotalSize = dt.Rows.Count;
                this.UcPager.Bind();
                decimal Add, Minus;
            var drAdd = AccountingManager.GetAmount(cUser.ID, 1);
            var drMinus = AccountingManager.GetAmount(cUser.ID, 0);
                if (drAdd == null)
                    Add = 0;
                else
                    Add = Convert.ToDecimal(drAdd["Amount"].ToString());
                if (drMinus == null)
                    Minus = 0;
                else
                    Minus = Convert.ToDecimal(drMinus["Amount"].ToString());
                this.lblAmount.Text = $"小計{Add - Minus}元";
            }
            else
            {
                this.gvAccountList.Visible = false;
                this.plcNoData.Visible = true;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!AuthManger.IsLogined())
            {
                Response.Redirect("/SystemAdmin/UserInfo.aspx");
                return;
            }
            else
                Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
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
        protected void gvAccountList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = row.FindControl("lbl") as Label;
                var dr = row.DataItem as DataRowView;
                int actType = dr.Row.Field<int>("ActType");

                if (actType == 0)
                {
                    lbl.Text = "支出";
                }
                    
                else
                {
                    lbl.Text = "收入";
                }

                if( dr.Row.Field<int>("Amount") > 1500 )
                {
                    lbl.ForeColor = Color.Red;
                }
                    
            }
        }
    }
}