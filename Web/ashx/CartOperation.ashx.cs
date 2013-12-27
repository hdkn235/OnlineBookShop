using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookShop.Model;
using BookShop.BLL;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// CartOperation 的摘要说明
    /// </summary>
    public class CartOperation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string res = "no";
            string oper = context.Request["oper"];
            if (oper == "change")
            {
                int id;
                if (int.TryParse(context.Request["id"], out id))
                {
                    CartBLL bll = new CartBLL();
                    Cart model = bll.GetModel(id);
                    if (model != null)
                    {
                        model.Count = Convert.ToInt32(context.Request["count"]);
                        bll.Update(model);
                        res = "yes";
                    }
                }

            }
            else if (oper == "del")
            {
                int id;
                if (int.TryParse(context.Request["id"], out id))
                {
                    CartBLL bll = new CartBLL();
                    if (bll.Delete(id))
                    {
                        res = "yes";
                    }
                }
            }
            context.Response.Write(res);
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