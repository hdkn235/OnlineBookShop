using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;

namespace BookShop.Web
{
    public partial class BookList : System.Web.UI.Page
    {
        protected int pageSize = 10;
        protected string orderbyBtnValue = "出版价格";
        protected string obDateBtnValue = "出版日期";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookList();
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.Form["btnPrice"]))
                {
                    OrderListByPrice();
                }
                if (!string.IsNullOrEmpty(Request.Form["btnDate"]))
                {
                    OrderListByDate();
                }
            }
        }

        protected void OrderListByPrice()
        {
            string orderBy = "";
            switch (Request.Form["btnPrice"])
            {
                case "出版价格":
                    orderbyBtnValue = "出版价格↓";
                    orderBy = "unitPrice desc";
                    break;
                case "出版价格↑":
                    orderbyBtnValue = "出版价格↓";
                    orderBy = "unitPrice desc";
                    break;
                case "出版价格↓":
                    orderbyBtnValue = "出版价格↑";
                    orderBy = "unitPrice asc";
                    break;
            }
            GoPage(orderBy);
        }

        private void GoPage(string orderBy)
        {
            string url = "";
            if (!string.IsNullOrEmpty(Request["categoryId"]))
            {
                url = string.Format("/BookList.aspx?categoryId={0}&orderBy={1}", Request["categoryId"], HttpUtility.UrlEncode(orderBy));
            }
            else
            {
                url = string.Format("/BookList.aspx?orderBy={0}", HttpUtility.UrlEncode(orderBy));
            }
            Response.Redirect(url);
        }

        protected void OrderListByDate()
        {
            string orderBy = "";
            switch (Request.Form["btnDate"])
            {
                case "出版日期":
                    orderbyBtnValue = "出版日期↓";
                    orderBy = "publishDate desc";
                    break;
                case "出版日期↑":
                    orderbyBtnValue = "出版日期↓";
                    orderBy = "publishDate desc";
                    break;
                case "出版日期↓":
                    orderbyBtnValue = "出版日期↑";
                    orderBy = "publishDate asc";
                    break;
            }
            GoPage(orderBy);
        }

        /// <summary>
        /// 绑定图书列表
        /// </summary>
        /// <param name="pageIndex"></param>
        protected void BindBookList()
        {
            //图书类别编号
            int categoryId;
            if (!int.TryParse(Request.QueryString["categoryId"], out categoryId))
            {
                categoryId = 0;
            }
            //当前页码
            int pageIndex;
            if (!int.TryParse(Request.QueryString["page"], out pageIndex))
            {
                pageIndex = 1;
            }
            //图书总页数
            int pageCount = 0;
            BooksBLL bb = new BooksBLL();
            pageCount = bb.GetPageCount(categoryId, pageSize);
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageCount < pageIndex)
            {
                pageIndex = pageCount;
            }
            //排序字符串
            string orderBy = "";
            if (!string.IsNullOrEmpty(Request.QueryString["orderBy"]))
            {
                orderBy = Request.QueryString["orderBy"];
                SetOrderByValue(orderBy);
            }
            BookListRepeater.DataSource = bb.GetPagedBooks(pageIndex, pageSize, categoryId, orderBy);
            BookListRepeater.DataBind();

            CreatePagedBar(pageIndex, pageCount, categoryId, orderBy);

        }

        private void SetOrderByValue(string orderBy)
        {
            switch (orderBy)
            {
                case "unitPrice desc":
                    orderbyBtnValue = "出版价格↓";
                    break;
                case "unitPrice asc":
                    orderbyBtnValue = "出版价格↑";
                    break;
                case "publishDate desc":
                    obDateBtnValue = "出版日期↓";
                    break;
                case "publishDate asc":
                    obDateBtnValue = "出版日期↑";
                    break;
            }
        }

        private void CreatePagedBar(int pageIndex, int pageCount, int categoryId, string orderBy)
        {
            pageBar.PageHtml = "/BookList.aspx";
            pageBar.CurrentPage = pageIndex;
            pageBar.TotalPageCount = pageCount;
            pageBar.CategoryId = categoryId;
            pageBar.OrderBy = orderBy;
        }
    }
}