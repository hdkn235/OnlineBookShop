using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServiceApp
{
    /// <summary>
    /// Hello 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class Hello : System.Web.Services.WebService
    {
        public MySoapHeader mySoapHeader = null;////不能new，在调用的网站中去创建,在调用该服务的网站中指定了SoapHeader中用户名和密码.

        [WebMethod(Description = "返回字符串方法")]//该特性是对外公开的。
        public string HelloWorld()
        {
            return "Hello World";
        }

        [SoapHeader("mySoapHeader")]
        [WebMethod(Description = "打招呼方法")]//该特性是对外公开的。
        public string SayHi()
        {
            if (mySoapHeader.IsValidate())
            {
                return "Hello World";
            }
            else
            {
                return "用户名或密码不正确！";
            }
        }
    }
}
