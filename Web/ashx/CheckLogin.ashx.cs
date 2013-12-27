using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using BookShop.Model;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// CheckLogin 的摘要说明
    /// </summary>
    public class CheckLogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            if (context.Request.Form["action"] == "check")
            {
                if (context.Session["userInfo"] != null && context.Session["userInfo"].ToString() != "")
                {
                    Users u = context.Session["userInfo"] as Users;
                    msg = "yes:" + u.LoginId;
                }
                else
                {
                    msg = "no:not login";
                }
                context.Response.Write(msg);
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}