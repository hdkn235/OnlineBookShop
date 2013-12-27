using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebServiceApp
{
    /// <summary>
    /// 自己定义一个SoapHeaer,封装了用户名和密码.
    /// </summary>
    public class MySoapHeader:SoapHeader
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string userPwd;

        public string UserPwd
        {
            get { return userPwd; }
            set { userPwd = value; }
        }

        /// <summary>
        /// 验证用户名、密码是否正确的方法
        /// </summary>
        /// <returns></returns>
        public bool IsValidate()
        {
            if (userName=="admin"&&userPwd=="admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}