using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using BookShop.Web.Common;

namespace BookShop.Web.ashx
{
    /// <summary>
    /// UploadImage 的摘要说明
    /// </summary>
    public class UploadImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = "";
            HttpPostedFile file = context.Request.Files["fileData"];
            if (file.ContentLength > 0)
            {
                string ext = Path.GetExtension(Path.GetFileName(file.FileName));
                if (ext == ".jpg" || ext == ".png" || ext == ".gif")
                {
                    string fileName = WebCommon.GetStreamMD5(file.InputStream) + ext;
                    string path = Path.Combine("/UpImages", fileName);
                    //file.SaveAs(context.Request.MapPath(path));
                    int width = 400;
                    int height = 400;
                    WebCommon.createThumbnail(file.InputStream, context.Request.MapPath(path), ref width, ref height);
                    msg = "ok," + path + "," + width + "," + height;
                }
                else
                {
                    msg = "error,上传文件格式错误！";
                }
            }
            else
            {
                msg = "error,请选择文件！";
            }

            context.Response.Write(msg);

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