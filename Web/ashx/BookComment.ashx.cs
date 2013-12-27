using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Model;
using BookShop.BLL;
using System.Web.Script.Serialization;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// BookComment 的摘要说明
    /// </summary>
    public class BookComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request.Form["action"];
            if (action == "add")
            {
                BookShop.Model.BookComment bc = new BookShop.Model.BookComment();
                bc.BookId = Convert.ToInt32(context.Request.Form["bookId"]);
                bc.CreateDateTime = DateTime.Now;

                if (!string.IsNullOrEmpty(context.Request.Form["comment"]))
                {
                    bc.Msg = context.Request.Form["comment"];
                    if (new BookCommentBLL().Add(bc) > 0)
                    {
                        context.Response.Write("yes");
                    }
                    else
                    {
                        context.Response.Write("no");
                    }
                }
            }
            else if (action == "load")
            {
                string bookId = context.Request.Form["bookId"];
                List<BookShop.Model.BookComment> list = new BookCommentBLL().GetModelList("BookId=" + bookId, "CreateDateTime");

                List<ViewBookComment> newList = new List<ViewBookComment>();
                foreach (Model.BookComment bc in list)
                {
                    ViewBookComment vbc = new ViewBookComment();
                    vbc.CreateDateTime = Common.WebCommon.GetTimeSpanStr(DateTime.Now - bc.CreateDateTime);
                    vbc.Msg = bc.Msg;
                    newList.Add(vbc);
                }

                JavaScriptSerializer jss = new JavaScriptSerializer();
                context.Response.Write(jss.Serialize(newList));
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