using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountingNote.UserControl
{
    public partial class UcPager : System.Web.UI.UserControl
    {
        /// <summary>頁面URL</summary>
        public string Url { get; set; }
        /// <summary>總筆數 </summary>
        public int TotalSize { get; set; }
        /// <summary>頁面筆數 </summary>
        public int PageSize { get; set; }
        /// <summary>目前頁數 </summary>
        public int CurrentPage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Bind()
        {
            ////檢查一頁筆數
            if (this.PageSize <= 0)
                throw new DivideByZeroException();

            //算總頁數
            int totalPage = this.TotalSize / this.PageSize;
            if (this.TotalSize % this.PageSize > 0)
                totalPage += 1;

            this.alinkFirst.HRef = $"{this.Url}?Page=1";
            this.alinkLast.HRef = $"{this.Url}?Page={totalPage}";
            //依目前頁數計算
            this.CurrentPage = this.GetCurrectPage();
            this.ltlCurrentPage.ToString();
            //計算頁數
            int prevM1 = this.CurrentPage - 1;
            int prevM2 = this.CurrentPage - 2;
            int nextP1 = this.CurrentPage + 1;
            int nextP2 = this.CurrentPage + 2;

            this.alink2.HRef = $"{this.Url}?Page={prevM1}";
            this.alink2.InnerText = prevM1.ToString();

            this.alink1.HRef = $"{this.Url}?Page={prevM2}";
            this.alink1.InnerText = prevM2.ToString();

            this.alink4.HRef = $"{this.Url}?Page={nextP1}";
            this.alink4.InnerText = nextP1.ToString();

            this.alink5.HRef = $"{this.Url}?Page={nextP2}";
            this.alink5.InnerText = nextP2.ToString();
            //依頁數，決定是否隱藏超連結
            this.alink1.Visible = (prevM2 > 0);
            this.alink2.Visible = (prevM1 > 0);
            this.alink4.Visible = (nextP1 <= totalPage);
            this.alink5.Visible = (nextP2 <= totalPage);

            this.ltPager.Text = $"共{TotalSize}筆，共{totalPage}頁，目前在第{this.GetCurrectPage()}頁<br/>";
        }
        private int GetCurrectPage()
        {
            string pageText = Request.QueryString["Page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int pageIndex;
            if (!int.TryParse(pageText, out pageIndex))
                return 1;

            return pageIndex;
        }
    }
}