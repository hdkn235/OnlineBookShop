using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BookShop.Web.Test
{
    public partial class WebForm1 : Common.CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SendEmail();
        }

        private void SendEmail()
        {
            MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
            mailMsg.From = new MailAddress("huoda@hd.com", "灬达", Encoding.Default);//源邮件地址 
            mailMsg.To.Add(new MailAddress("maktub@hd.com", "豁达", Encoding.Default));//目的邮件地址。可以有多个收件人
            mailMsg.Subject = "Hello,大家好!";//发送邮件的标题 
            mailMsg.SubjectEncoding = Encoding.Default;//设置主题的编码
            mailMsg.Body = "<a href='http://www.baidu.com'>百度</a>";//发送邮件的内容 
            mailMsg.BodyEncoding = Encoding.Default;//设置内容的编码
            mailMsg.IsBodyHtml = true;//内容支持HTML
            SmtpClient client = new SmtpClient("127.0.0.1");//smtp.163.com，smtp.qq.com 邮件的smtp服务地址
            client.Credentials = new NetworkCredential("huoda", "spring");//邮箱登陆的账号 和密码
            client.Send(mailMsg);
        }
    }
}