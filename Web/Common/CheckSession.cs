using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Model;
using BookShop.BLL;

namespace BookShop.Web.Common
{
    public class CheckSession : System.Web.UI.Page
    {
        //登陆用户的信息
        protected Model.Users LoginUser { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //if (Session["userInfo"] == null)
            //{
            //    WebCommon.GoPage();
            //}
            if (Request.Cookies["c1"] != null && Request.Cookies["c1"].Value != "" && Request.Cookies["c2"] != null && Request.Cookies["c2"].Value != "")
            {
                Users u = new UsersBLL().GetModelByLoginId(Request.Cookies["c1"].Value);
                if (u != null)
                {
                    if (u.LoginPwd == Request.Cookies["c2"].Value)
                    {
                        LoginUser = u;
                    }
                    else
                    {
                        WebCommon.GoPage();
                    }
                }
            }

            if (Request.Cookies["userInfo"] != null && Request.Cookies["userInfo"].ToString() != "")
            {
                string key = Request.Cookies["userInfo"].Value;
                object obj = Common.MemCacheHelper.GetValue(key, DateTime.Now.AddMinutes(20));
                if (obj != null)
                {
                    LoginUser = obj as Model.Users;
                }
                else
                {
                    WebCommon.GoPage();
                }
            }
            else
            {
                WebCommon.GoPage();
            }

        }
    }
}