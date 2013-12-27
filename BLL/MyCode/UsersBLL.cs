using System;
using System.Collections.Generic;
using System.Text;
using BookShop.Model;
using BookShop.DAL;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace BookShop.BLL
{
    public partial class UsersBLL
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BookShop.Model.Users model, out string msg)
        {
            if (dal.Exists(model.LoginId))
            {
                msg = "用户名存在！";
                return 0;
            }
            else
            {
                msg = "注册成功！";
                return dal.Add(model);
            }

        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        public void SendEmail(string content, string email, string subject)
        {
            SettingsBLL sb = new SettingsBLL();
            MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
            mailMsg.From = new MailAddress(sb.GetValueByName("系统邮件地址"), sb.GetValueByName("系统邮件用户名"), Encoding.Default);//源邮件地址 
            mailMsg.To.Add(new MailAddress(email));//目的邮件地址。可以有多个收件人
            mailMsg.Subject = subject;//发送邮件的标题 
            mailMsg.SubjectEncoding = Encoding.Default;//设置主题的编码
            mailMsg.Body = content;
            mailMsg.BodyEncoding = Encoding.Default;//设置内容的编码
            mailMsg.IsBodyHtml = true;//内容支持HTML
            SmtpClient client = new SmtpClient(sb.GetValueByName("系统邮件SMTP"));//smtp.163.com，smtp.qq.com 邮件的smtp服务地址
            client.Credentials = new NetworkCredential(sb.GetValueByName("系统邮件用户名"), sb.GetValueByName("系统邮件密码"));//邮箱登陆的账号 和密码
            client.Send(mailMsg);
        }

        /// <summary>
        /// 激活账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SetActived(int id)
        {
            return dal.SetActived(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BookShop.Model.Users GetModelByLoginId(string LoginId)
        {
            return dal.GetModelByLoginId(LoginId);
        }

        /// <summary>
        /// 检查登录
        /// </summary>
        /// <param name="name">用户民</param>
        /// <param name="pwd">密码</param>
        /// <param name="msg">信息</param>
        /// <param name="u">获得users</param>
        /// <returns></returns>
        public bool CheckLogin(string name, string pwd, out string msg, out Users u)
        {
            u = dal.GetModelByLoginId(name);
            if (u != null)
            {
                if (u.UserState.Id ==2 )
                {
                    msg = "用户已被禁用！";
                    return false;
                }
                else
                {
                    if (u.Actived == true)
                    {
                        if (u.LoginPwd == pwd)
                        {
                            msg = "登录成功！";
                            return true;
                        }
                        else
                        {
                            msg = "用户名密码错误！";
                            return false;
                        }  
                    }
                    else
                    {
                        msg = "请激活用户后再登录！";
                        return false;
                    }

                }
            }
            else
            {
                msg = "用户名不存在！";
                return false;
            }
        }
    }
}
