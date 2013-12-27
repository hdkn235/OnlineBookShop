using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Web.Common
{
    public class CheckLoginModule : IHttpModule
    {
        #region IHttpModule 成员

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            //AcquireRequestState:当 ASP.NET 获取与当前请求关联的当前状态（如会话状态）时发生,常用于session。
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }

        /// <summary>
        /// 检查权限 若没有权限 则跳转到默认界面
        /// </summary>
        /// <param name="sender">上下文对象</param>
        /// <param name="e"></param>
        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = (sender as HttpApplication).Context;

            if (context.Request.RawUrl.ToString().ToLower().StartsWith("/admin"))
            {
                if (context.Session["userInfo"] == null)
                {
                    context.Response.Redirect("/Default.aspx");
                }
            }
        }

        #endregion
    }
}