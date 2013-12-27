using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using PanGu;

namespace BookShop.Web.Common
{
    public class WebCommon
    {
        /// <summary>
        /// 计算文件的MD5值
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetStreamMD5(Stream stream)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;
            System.Security.Cryptography.MD5CryptoServiceProvider oMD5Hasher =
                new System.Security.Cryptography.MD5CryptoServiceProvider();
            arrbytHashValue = oMD5Hasher.ComputeHash(stream); //计算指定Stream 对象的哈希值
            //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”
            strHashData = System.BitConverter.ToString(arrbytHashValue);
            //替换-
            strHashData = strHashData.Replace("-", "");
            strResult = strHashData;
            return strResult;
        }

        /// <summary>
        /// 对字符串进行MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns>加密后的MD5值</returns>
        public static string GetStrMD5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] strArr = Encoding.UTF8.GetBytes(str);
            byte[] newArr = md5.ComputeHash(strArr);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in newArr)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 对字符串进行二次MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStrDoubleMD5(string str)
        {
            return GetStrMD5(GetStrMD5(str));
        }

        /// <summary>
        /// 按照指定大小创建缩略图并保存到服务器上
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void createThumbnail(Stream stream, string path, ref int width, ref int height)
        {
            using (Image priImg = Image.FromStream(stream))
            {
                if (priImg.Width > priImg.Height)
                {
                    height = width * priImg.Height / priImg.Width;
                }
                else
                {
                    width = height * priImg.Width / priImg.Height;
                }

                using (Bitmap bm = new Bitmap(width, height))
                {
                    using (Graphics g = Graphics.FromImage(bm))
                    {
                        g.DrawImage(priImg, 0, 0, bm.Width, bm.Height);
                        bm.Save(path);
                    }
                }
            }
        }

        /// <summary>
        /// 跳转页面
        /// </summary>
        public static void GoPage()
        {
            HttpContext.Current.Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode("请先登录！") + "&t=" + HttpUtility.UrlEncode("登录页面") + "&u=/Member/Login.aspx&returnUrl=" + HttpContext.Current.Request.Url);

        }

        /// <summary>
        /// 盘古分词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string[] PanGuSplit(string str)
        {
            Analyzer analyzer = new PanGuAnalyzer();//指定盘古分词算法。
            TokenStream tokenStream = analyzer.TokenStream("", new StringReader(str));
            Lucene.Net.Analysis.Token token = null;
            List<string> list = new List<string>();
            while ((token = tokenStream.Next()) != null)
            {
                list.Add(token.TermText());
            }
            return list.ToArray();
        }

        /// <summary>
        /// 对搜索的关键词keyword高亮显示
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Highlight(string keyword, string content)
        {
            //创建HTMLFormatter,参数为高亮单词的前后缀 
            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter = new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\"><b>", "</b></font>");
            //创建 Highlighter ，输入HTMLFormatter 和 盘古分词对象Semgent 
            PanGu.HighLight.Highlighter highlighter = new PanGu.HighLight.Highlighter(simpleHTMLFormatter, new Segment());
            //设置每个摘要段的字符数 
            highlighter.FragmentSize = 250;
            //获取最匹配的摘要段 
            return highlighter.GetBestFragment(keyword, content);
        }

        /// <summary>
        /// 获取处理后的时间差
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string GetTimeSpanStr(TimeSpan ts)
        {
            if (ts.TotalDays > 365)
            {
                return Math.Floor(ts.TotalDays / 365) + "年前";
            }
            else if (ts.TotalDays > 31)
            {
                return Math.Floor(ts.TotalDays / 31) + "月前";
            }
            else if (ts.TotalDays > 7)
            {
                return Math.Floor(ts.TotalDays / 7) + "周前";
            }
            else if (ts.TotalDays > 1)
            {
                return Math.Floor(ts.TotalDays) + "天前";
            }
            else if (ts.TotalHours > 1)
            {
                return Math.Floor(ts.TotalHours) + "小时前";
            }
            else if (ts.TotalMinutes > 1)
            {
                return Math.Floor(ts.TotalMinutes) + "分钟前";
            }
            else
            {
                return "刚刚";
            }
        }

        /// <summary>
        /// 显示图书描述
        /// </summary>
        /// <param name="des"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string CutString(string des, int max)
        {
            string res = "";
            if (des.Length > max)
            {
                res = des.Substring(0, max) + "......";
            }
            else
            {
                res = des;
            }
            return res;
        }

        /// <summary>
        /// 获取图书详细页面的路径
        /// </summary>
        /// <param name="time"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetPath(object time, object id)
        {
            DateTime date = Convert.ToDateTime(time);
            return "/StaticHtml/" + date.Year + "/" + date.Month + "/" + id.ToString() + ".html";
        }
    }
}