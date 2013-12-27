using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace BookShop.Web.Test
{
    public partial class WebServiceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HelloWorld.HelloSoapClient hsc = new HelloWorld.HelloSoapClient();//初始化WebService服务
            //Response.Write(hsc.HelloWorld());//调用WebService中的方法

            //using (WeatherService.WeatherWebServiceSoapClient wwsc = new WeatherService.WeatherWebServiceSoapClient())
            //{
            //    string[] strs = wwsc.getWeatherbyCityName("北京");
            //    foreach (string str in strs)
            //    {
            //        Response.Write(str + "<br/>");
            //    }
            //}

            using (HelloWorld.HelloSoapClient hsc = new HelloWorld.HelloSoapClient())
            {
                HelloWorld.MySoapHeader msh = new HelloWorld.MySoapHeader();//创建定义的SoapHeader
                msh.UserName = "admin";
                msh.UserPwd = "admin";
                Response.Write(hsc.SayHi(msh));//将创建好的SoapHeader发送到服务中。
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WeatherService.WeatherWebServiceSoapClient wwsc = new WeatherService.WeatherWebServiceSoapClient())//创建客户单代理类
            {
                wwsc.getWeatherbyCityNameAsync("周口");//进行异步调用
                wwsc.getWeatherbyCityNameCompleted += new EventHandler<WeatherService.getWeatherbyCityNameCompletedEventArgs>(wwsc_getWeatherbyCityNameCompleted);
            }
        }

        //异步的方法完成以后触发wwsc_getWeatherbyCityNameCompleted事件。
        void wwsc_getWeatherbyCityNameCompleted(object sender, WeatherService.getWeatherbyCityNameCompletedEventArgs e)
        {
            string[] strs = e.Result;
            foreach (string str in strs)
            {
                Response.Write(str + "<br/>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //BackgroundWorker 类允许您在单独的专用线程上运行操作。 耗时的操作（如下载和数据库事务）在长时间运行时可能会导致用户界面 (UI) 似乎处于停止响应状态。 如果您需要能进行响应的用户界面，而且面临与这类操作相关的长时间延迟，则可以使用 BackgroundWorker 类方便地解决问题。
            BackgroundWorker background = new BackgroundWorker();
            // 在此事件处理程序中调用耗时的操作
            background.DoWork += new DoWorkEventHandler(background_DoWork);
            //若要在操作完成时收到通知，请处理 RunWorkerCompleted 事件。
            background.RunWorkerCompleted += new RunWorkerCompletedEventHandler(background_RunWorkerCompleted);
            //要开始此操作，请调用 RunWorkerAsync
            background.RunWorkerAsync();//开始真正执行异步操作.
        }

        void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string[] strs = (string[])e.Result;//从Result获取耗时操作返回的值
            foreach (string str in strs)
            {
                Response.Write(str + "<br/>");
            }
        }

        void background_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WeatherService.WeatherWebServiceSoapClient wwsc = new WeatherService.WeatherWebServiceSoapClient())
            {
                e.Result = wwsc.getWeatherbyCityName("周口");//进行方法调用，并将返回值存放到事件中的Result进行传递
            }
        }
    }
}