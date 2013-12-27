using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.BLL;
using BookShop.Model;

namespace BookShop.Web.Master
{
    public partial class List : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object obj = Common.MemCacheHelper.GetValue("category");
            List<Categories> list = null;
            if (obj == null)
            {
                CategoriesBLL cb = new CategoriesBLL();
                list = cb.GetModelList("");
                Common.MemCacheHelper.Insert("category", list);
            }
            else
            {
                list = obj as List<Categories>;
            }

            if (list != null)
            {
                foreach (Categories c in list)
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = c.Name;
                    //tn.NavigateUrl = "/BookList.aspx?categoryId=" + c.Id;
                    tn.NavigateUrl = "/BookList_" + c.Id + ".aspx";
                    this.tvCategory.Nodes.Add(tn);
                }

            }
        }

        /// <summary>
        /// 跳转到搜索界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Member/SearchBooks.aspx?w=" + HttpUtility.UrlEncode(Request["txtSearch"]));
        }
    }
}