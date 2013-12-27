using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.Web.Member
{
    public partial class ULogin : System.Web.UI.UserControl
    {
        protected string msg = "";
        protected string returnUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string name = Context.Request.Form["txtName"];
                string pwd = Common.WebCommon.GetStrDoubleMD5(Context.Request.Form["txtPwd"]);
                Users u = null;
                if (new UsersBLL().CheckLogin(name, pwd, out msg, out u))
                {
                    if (string.IsNullOrEmpty(Request.Form["cbAutoLogin"]))
                    {
                        ClearCookies();
                    }
                    else
                    {
                        SetCookies(name, pwd);
                    }
                    //Session["userInfo"] = u;
                    LoginSucess(u);
                }
            }
            else
            {
                CheckUserInfo();
                returnUrl = Context.Request.QueryString["returnUrl"];
            }
        }

        /// <summary>
        /// 登录成功后的处理
        /// </summary>
        /// <param name="u"></param>
        private void LoginSucess(Users u)
        {
            string key = Guid.NewGuid().ToString();
            Common.MemCacheHelper.Insert(key, u, DateTime.Now.AddMinutes(20));
            HttpCookie hc = new HttpCookie("userInfo");
            hc.Value = key;
            Response.Cookies.Add(hc);
            GoToPage("登录成功！");
        }

        /// <summary>
        /// 清除用户cookies
        /// </summary>
        private void ClearCookies()
        {
            Response.Cookies["c1"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["c2"].Expires = DateTime.Now.AddDays(-1);
        }

        /// <summary>
        /// 跳转到
        /// </summary>
        /// <param name="u"></param>
        private void GoToPage(string message)
        {
            if (string.IsNullOrEmpty(Context.Request["returnUrl"]))
            {
                Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode(message) + "&t=" + HttpUtility.UrlEncode("首页") + "&u=/BookList.aspx");
            }
            else
            {
                Response.Redirect(Context.Request["returnUrl"]);
            }
        }

        /// <summary>
        /// 添加用户cookie信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        private void SetCookies(string name, string pwd)
        {
            HttpCookie hc1 = new HttpCookie("c1", name);
            HttpCookie hc2 = new HttpCookie("c2", pwd);
            hc1.Expires = DateTime.Now.AddDays(7);
            hc2.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(hc1);
            Response.Cookies.Add(hc2);
        }

        /// <summary>
        /// 检查用户存储的cookie信息
        /// </summary>
        /// <returns></returns>
        private void CheckUserInfo()
        {
            if (Request.Cookies["c1"] != null && Request.Cookies["c1"].Value != "" && Request.Cookies["c2"] != null && Request.Cookies["c2"].Value != "")
            {
                Users u = new UsersBLL().GetModelByLoginId(Request.Cookies["c1"].Value);
                if (u != null)
                {
                    if (u.LoginPwd == Request.Cookies["c2"].Value)
                    {
                        LoginSucess(u);
                    }
                    else
                    {
                        ClearCookies();
                    }
                }
            }
            else
            {
                if (Request.Cookies["userInfo"] != null && Request.Cookies["userInfo"].ToString() != "")
                {
                    string key = Request.Cookies["userInfo"].Value;
                    object obj = Common.MemCacheHelper.GetValue(key);
                    if (obj != null)
                    {
                        Response.Redirect("/BookList.aspx");
                    }
                }
            }
        }

    }
}