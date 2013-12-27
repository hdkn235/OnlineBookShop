using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShop.Model;
using BookShop.BLL;

namespace BookShop.Web.Member
{
    public partial class Cart : Common.CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddBookToCart();
                BindRptCartList();
            }
        }

        /// <summary>
        /// 显示购物车的商品
        /// </summary>
        private void BindRptCartList()
        {
            CartBLL bll = new CartBLL();
            rptCartList.DataSource = bll.GetModelList("UserId=" + LoginUser.Id);
            rptCartList.DataBind();
        }

        /// <summary>
        /// 将商品添加到购物车中
        /// </summary>
        private void AddBookToCart()
        {
            int bookId;
            if (int.TryParse(Request.QueryString["id"], out bookId))
            {
                BooksBLL bb = new BooksBLL();
                Books book = bb.GetModel(bookId);
                if (book != null)
                {
                    CartBLL cb = new CartBLL();
                    Model.Cart cart = cb.GetModel(LoginUser.Id, bookId);
                    if (cart != null)
                    {
                        cart.Count = cart.Count + 1;
                        cb.Update(cart);
                    }
                    else
                    {
                        Model.Cart newCart = new Model.Cart();
                        newCart.Book.Id = bookId;
                        newCart.Count = 1;
                        newCart.UserId = LoginUser.Id;
                        cb.Add(newCart);
                    }
                }
                else
                {
                    Response.Redirect("/ShowMsg.aspx?m=" + HttpUtility.UrlEncode("此商品不存在！"));
                }
            }
        }
    }
}