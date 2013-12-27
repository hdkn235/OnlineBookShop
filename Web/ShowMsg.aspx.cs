using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web
{
    public partial class ShowMsg : System.Web.UI.Page
    {
        protected string txt = "";
        protected string url = "";
        /// <summary>
        /// m t 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["m"]))
            {
                lblMsg.Text = Request.QueryString["m"];
            }
            else
            {
                lblMsg.Text = "暂无信息";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["t"]))
            {
                txt = Request.QueryString["t"];
            }
            else
            {
                txt = "图书列表";
            }
            if (!string.IsNullOrEmpty(Request.QueryString["u"]))
            {
                url = Request.QueryString["u"];
                string returnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    url += "?returnUrl=" + returnUrl;
                }
            }
            else
            {
                url = "/BookList.aspx";
            }
        }
    }
}