using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// Active 的摘要说明
    /// </summary>
    public class Active : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "激活链接无效！";
            int id;
            if (int.TryParse(context.Request.QueryString["uid"], out id))
            {
                string code = context.Request.QueryString["code"];
                if (!string.IsNullOrEmpty(code))
                {
                    UsersBLL ub = new UsersBLL();
                    Users u = ub.GetModel(id);
                    if (u != null && u.ActiveCode == code)
                    {
                        if (u.Actived == false)
                        {
                            if ((ub.SetActived(id)))
                            {
                                msg = "账户激活成功！";
                            }
                            else
                            {
                                msg = "账户激活失败！";
                            }
                        }
                        else
                        {
                            msg = "账户已激活！";
                        }
                    }
                }
            }

            context.Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode(msg) + "&t=" + HttpUtility.UrlEncode("登陆页面") + "&u=/Login.aspx");
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