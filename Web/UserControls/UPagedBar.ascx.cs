using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.UserControls
{
    public partial class UPagedBar : System.Web.UI.UserControl
    {
        //当前页数
        private int currentPage;

        public int CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; }
        }

        //总页数
        private int totalPageCount = 1;

        public int TotalPageCount
        {
            get { return totalPageCount; }
            set { totalPageCount = value; }
        }

        //分页的页面
        private string page;

        public string PageHtml
        {
            get { return page; }
            set { page = value; }
        }

        //类别编号
        private int categoryId = 0;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        //排序字段
        private string orderBy = "id";

        public string OrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }

        //页码条Html代码
        protected string pageUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            int step = 2;

            int leftNum;
            int rightNum;

            pageUrl += "<div class='paged'>";

            //显示首页
            pageUrl += "<a href='" + GetHref(1) + "' class='firstpage' >首页</a>";

            //是否显示上一页  
            if (currentPage > 1)
            {
                pageUrl += "<a href='" + GetHref(currentPage - 1) + "'>上一页</a>";
            }


            //此时应该这样显示页码 上一页 1 ...  5 6 7 8 9 ... 100 下一页  
            //即当前浏览的页数在中间几页  
            if ((currentPage - step) > 2 && (totalPageCount > step * 2 + 2))
            {
                pageUrl += "<a href='" + GetHref(1) + "'>1</a>";

                //标识变量，标识当前页是否是倒数几页，该变量在下面会用到  
                bool isLastFiewPages = false;


                //判断是否是倒数后几页  
                if (currentPage + (step * 2 + 1 + 1) > totalPageCount)
                {
                    leftNum = totalPageCount - (step * 2 + 1);
                    rightNum = totalPageCount;
                    isLastFiewPages = true;
                }
                else
                {
                    leftNum = currentPage - step;
                    rightNum = currentPage + step;
                }


                if (leftNum - 1 > 1)
                {
                    pageUrl += "<span>...</span>";
                }


                //拼装分页代码  
                for (int i = leftNum; i <= rightNum; i++)
                {
                    if (i == currentPage)
                    {
                        pageUrl = pageUrl + "<span class='current'>" + i + "</span>";
                    }
                    else
                    {
                        pageUrl = pageUrl + "<a href='" + GetHref(i) + "'>" + i + "</a>";
                    }
                }
                if (!isLastFiewPages)
                {
                    pageUrl += "<span>...</span><a href='" + GetHref(totalPageCount) + "'>" + totalPageCount + "</a>";
                }


            }
            //此时应该这样显示页码 上一页 1 2 3 4 5 6 ... 100 下一页或者  
            //当总页数小于或等于(2 * step + 1 + 1)的时候应该这样显示 上一页 1 2 3 4 5 下一页  
            else
            {
                if (currentPage <= 0)
                {
                    currentPage = 1;
                }


                leftNum = 1;
                //rightNum总页数和step * 2 + 1 + 1中较小的那个，  
                rightNum = totalPageCount < (step * 2 + 1 + 1) ? totalPageCount : (step * 2 + 2);


                for (int i = leftNum; i <= rightNum; i++)
                {
                    if (i == currentPage)
                    {
                        pageUrl += "<span class='current'>" + currentPage + "</span>";
                    }
                    else
                    {
                        pageUrl += "<a href='" + GetHref(i) + "'>" + i + "</a>";
                    }
                }


                //如果总条数大于前几页连续显示的条数需要这样显示 上一页 1 2 3 4 5 6 ... 100 下一页  
                if (totalPageCount > (step * 2 + 2))
                {
                    if (totalPageCount - 1 > rightNum)
                    {
                        pageUrl += "<span>...</span>";
                    }
                    pageUrl += "<a href='" + GetHref(totalPageCount) + "'>" + totalPageCount + "</a>";
                }
            }

            if (currentPage < totalPageCount)
            {
                pageUrl += "<a href='" + GetHref(currentPage + 1) + "'>下一页</a>";
            }

            //显示尾页
            pageUrl += "<a href='" + GetHref(totalPageCount) + "' class='lastpage'>尾页</a>";
            pageUrl += "</div>";
        }

        /// <summary>
        /// 获取条码的hrdf
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        private string GetHref(int pageIndex)
        {
            return page + "?page=" + pageIndex + "&categoryId=" + categoryId + "&orderBy=" + HttpUtility.UrlEncode(orderBy);
        }
    }
}