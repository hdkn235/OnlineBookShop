using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.Model;
using BookShop.BLL;

namespace BookShop.Web.Admin
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SettingsBLL sb = new SettingsBLL();
                this.txtActiveContent.Text = sb.GetValueByName("激活邮件内容");
                this.txtFindPwdContent.Text = sb.GetValueByName("找回密码邮件内容");
                this.txtSenderEmail.Text = sb.GetValueByName("系统邮件地址");
                this.txtSenderPwd.Text = sb.GetValueByName("系统邮件密码");
                this.txtSenderSmtp.Text = sb.GetValueByName("系统邮件SMTP");
                this.txtSenderUserName.Text = sb.GetValueByName("系统邮件用户名");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SettingsBLL sb = new SettingsBLL();
            sb.SetNameValue("激活邮件内容", this.txtActiveContent.Text);
            sb.SetNameValue("找回密码邮件内容", this.txtFindPwdContent.Text);
            sb.SetNameValue("系统邮件地址", this.txtSenderEmail.Text);
            sb.SetNameValue("系统邮件密码", this.txtSenderPwd.Text);
            sb.SetNameValue("系统邮件SMTP", this.txtSenderSmtp.Text);
            sb.SetNameValue("系统邮件用户名", this.txtSenderUserName.Text);
            txtMsg.Text = "更新成功！";
        }
    }
}