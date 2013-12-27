using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.BLL;
using System.Web.Script.Serialization;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// AutoComplete 的摘要说明
    /// </summary>
    public class AutoComplete : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string keyWord = context.Request["term"];
            if (!string.IsNullOrEmpty(keyWord))
            {
                KeyWordsRankBLL bll = new KeyWordsRankBLL();
                string[] array = bll.GetStrLike(keyWord);
                if (array.Length > 0)
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    context.Response.Write(jss.Serialize(array));
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}