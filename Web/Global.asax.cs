using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using BookShop.Web.Common;

namespace BookShop.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            IndexManage.myManage.Start();
            QuartzClass.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.AppRelativeCurrentExecutionFilePath;
            Match match = Regex.Match(url, @"~/BookList_(\d+).aspx");
            if (match.Success)
            {
                string categoryId = match.Groups[1].Value;
                Context.RewritePath("/BookList.aspx?categoryId=" + categoryId);
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}