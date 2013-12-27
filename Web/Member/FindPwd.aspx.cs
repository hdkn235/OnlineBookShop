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
    public partial class FindPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string name = Request.Form["txtName"];
                string email = Request.Form["txtEmail"];
                string msg = string.Empty;
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
                {
                    if (CheckCode())
                    {
                        UsersBLL ub = new UsersBLL();
                        Users u = ub.GetModelByLoginId(name);
                        if (u != null)
                        {
                            if (u.Mail == email)
                            {
                                string link = "http://localhost:12358/Member/ModifyPwd.aspx?uid=" + u.Id + "&code=" + u.ActiveCode;
//                                string content = string.Format(@"亲爱的用户 {0}：您好！<br /><br />
//                                您收到这封这封电子邮件是因为您 (也可能是某人冒充您的名义) 申请了一个新的密码。假如这不是您本人所申请, 请不用理会这                                封电子邮件, 但是如果您持续收到这类的信件骚扰, 请您尽快联络管理员。<br /><br />
//                                要使用新的密码, 请使用以下链接启用密码。<br /><br />
//                                <a href='{1}' target='_blank'>{2}</a><br /><br />
//                                (如果无法点击该URL链接地址，请将它复制并粘帖到浏览器的地址输入框，然后单击回车即可。该链接使用后将立即失效。)<br /><br />
//                                注意:请您在收到邮件1个小时内({3}前)使用，否则该链接将会失效。<br /><br />
//                                网上图书商城",u.Name, link, link, DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss"));
                                string content = string.Format(new SettingsBLL().GetValueByName("找回密码邮件内容"), u.Name, link, link, DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss"));
                                string subject = "来自网上图书商城的找回密码邮件";
                                ub.SendEmail(content, u.Mail, subject);

                                msg = "您的申请已经提交成功，请查看您的邮箱。";
                                Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode(msg) + "&t=" + HttpUtility.UrlEncode("首页") + "&u=/Default.aspx");
                            }
                            else
                            {
                                msg = "邮箱输入错误！";
                            }
                        }
                        else
                        {
                            msg = "用户名不存在！";
                        }
                    }
                    else
                    {
                        msg = "验证码输入错误！";
                    }
                }
                else
                {
                    msg = "用户名和邮箱不能为空！";
                }
                txtMsg.Text = msg;
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