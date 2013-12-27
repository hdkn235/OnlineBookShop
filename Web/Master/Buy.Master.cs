using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookShop.Web.Master
{
    public partial class Buy : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Member/SearchBooks.aspx?w=" + HttpUtility.UrlEncode(Request["txtSearch"]));
        }
    }
}