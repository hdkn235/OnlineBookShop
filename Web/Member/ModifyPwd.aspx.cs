using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.Model;
using BookShop.BLL;

namespace BookShop.Web.Member
{
    public partial class ModifyPwd : Common.CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uid;
                string code = Request.QueryString["code"];
                string msg = "";
                if (int.TryParse(Request.QueryString["uid"], out uid))
                {
                    if (!string.IsNullOrEmpty(code))
                    {
                        Users u = new UsersBLL().GetModel(uid);
                        if (u != null)
                        {
                            lblName.Text = u.LoginId;
                            hdUid.Value = u.Id.ToString();
                        }
                        else
                        {
                            msg = "用户不存在！";
                        }
                    }
                    else
                    {
                        msg = "参数错误！";
                    }
                }
                else
                {
                    msg = "参数错误！";
                }

                if (!string.IsNullOrEmpty(msg))
                {
                    Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode(msg) + "&t=" + HttpUtility.UrlEncode("首页") + "&u=/Default.aspx");
                }
            }
            else
            {
                UsersBLL ub = new UsersBLL();
                Users u = ub.GetModel(Convert.ToInt32(hdUid.Value));
                u.LoginPwd = Request.Form["txtPass"];
                if (ub.Update(u))
                {
                    ClearCookies();
                    Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode("修改密码成功，请重新登录！") + "&t=" + HttpUtility.UrlEncode("登录") + "&u=Login.aspx");
                }
                else
                {
                    txtMsg.Text = "修改密码失败！";
                }
            }

        }

        /// <summary>
        /// 清除用户cookies
        /// </summary>
        private void ClearCookies()
        {
            Response.Cookies["c1"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["c2"].Expires = DateTime.Now.AddDays(-1);
        }

    }
}