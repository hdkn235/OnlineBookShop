using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using BookShop.Model;
using BookShop.BLL;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BookShop.Web.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (CheckCode())
                {
                    Users u = new Users();
                    u.LoginId = Request.Form["txtName"];
                    u.LoginPwd = Common.WebCommon.GetStrDoubleMD5(Request.Form["txtPass"]);
                    u.Name = Request.Form["txtTrueName"];
                    u.Mail = Request.Form["txtEmail"];
                    u.Address = Request.Form["txtAddress"];
                    u.Phone = Request.Form["txtPhone"];
                    u.UserState.Id = 1;
                    u.ActiveCode = Guid.NewGuid().ToString().Replace("-", "");
                    string msg;
                    UsersBLL ub = new UsersBLL();
                    int uid = ub.Add(u, out msg);
                    if (uid > 0)
                    {
                        //注册成功
                        //发送激活链接
                        string link = "http://localhost:12358/ashx/Active.ashx?uid=" + uid + "&code=" + u.ActiveCode;
                        #region 冗余 注册激活邮件内容
                        //                        string content = string.Format(@"亲爱的网上图书商城用户：<br /><br /><br />
                        //                                        请通过<a target='_blank' href='{0}'>{1}</a>激活账号，也可以复制激活链接至浏览器 
                        //                                        <br /><br /><br />
                        //                                        网上图书商城
                        //                                        <br />
                        //                                        {2}
                        //                                        <br /><br /><br />
                        //                                        此邮件为系统自动发出的邮件，请勿直接回复。", link, link, DateTime.Now.ToString()); 
                        #endregion
                        string content = string.Format(new SettingsBLL().GetValueByName("激活邮件内容"), link, link, DateTime.Now.ToString());
                        string subject = "来自网上图书商城的注册确认邮件";
                        ub.SendEmail(content, u.Mail, subject);

                        //页面的跳转
                        Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode(msg+"<br />激活邮件已发到您的"+u.Mail+"的邮箱中，请激活账号后登录！") + "&t=" + HttpUtility.UrlEncode("登录页面") + "&u=/Member/Login.aspx");
                    }
                    else
                    {
                        //注册失败
                        txtMsg.Text = msg;
                        txtMsg.ForeColor = Color.Red;
                    }
                }
                else
                {
                    txtMsg.Text = "验证码错误，请重新输入！";
                    txtMsg.ForeColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 检查验证码输入是否正确
        /// </summary>
        /// <returns>true 正确  false 错误</returns>
        private bool CheckCode()
        {
            string txtCode = Request.Form["txtCode"];

            if (Session["vCode"] != null && txtCode.Equals(Session["vCode"].ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                Session.Remove("vCode");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}