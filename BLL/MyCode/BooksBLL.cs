using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
namespace BookShop.BLL
{
    /// <summary>
    /// BooksBLL
    /// </summary>
    public partial class BooksBLL
    {
        /// <summary>
        /// 获取图书类别下的分页后的总页数
        /// </summary>
        /// <param name="categoryId">类别ID</param>
        /// <returns></returns>
        public int GetPageCount(int categoryId,int pageSize)
        {
            int count = dal.GetBooksCount(categoryId);
            return Convert.ToInt32(Math.Ceiling(count * 1.0 / pageSize));
        }

        /// <summary>
        /// 获取图书的分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Books> GetPagedBooks(int pageIndex, int pageSize, int categoryId)
        {
            DataTable dt = dal.GetPagedBooks(pageIndex, pageSize, categoryId,"");
            return DataTableToList(dt);
        }

        /// <summary>
        /// 获取图书的分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Books> GetPagedBooks(int pageIndex, int pageSize, int categoryId,string orderBy)
        {
            DataTable dt = dal.GetPagedBooks(pageIndex, pageSize, categoryId, orderBy);
            return DataTableToList(dt);
        }
    }
}

