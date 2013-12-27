﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using BookShop.Model;
using System.Web;
using System.IO;
using System.Text;

namespace BookShop.BLL
{
    /// <summary>
    /// BooksBLL
    /// </summary>
    public partial class BooksBLL
    {
        private readonly BookShop.DAL.BooksDAL dal = new BookShop.DAL.BooksDAL();

        public BooksBLL()
        { }

        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ISBN, int Id)
        {
            return dal.Exists(ISBN, Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BookShop.Model.Books model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BookShop.Model.Books model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Books book)
        {
            return Delete(book.Id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ISBN, int Id)
        {

            return dal.Delete(ISBN, Id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BookShop.Model.Books GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public BookShop.Model.Books GetModelByCache(int Id)
        {

            string CacheKey = "BooksModel-" + Id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (BookShop.Model.Books)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BookShop.Model.Books> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BookShop.Model.Books> DataTableToList(DataTable dt)
        {
            List<BookShop.Model.Books> modelList = new List<BookShop.Model.Books>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                BookShop.Model.Books model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        public void CreateSaticHtml(int id)
        {
            Books b = dal.GetModel(id);
            if (b != null)
            {
                string temPath = HttpContext.Current.Request.MapPath("/Template/BookTemplate.htm");//求解
                string txt = File.ReadAllText(temPath,Encoding.Default);
                txt = txt.Replace("$Author", b.Author).Replace("$ContentDescription", b.ContentDescription).Replace("$ISBN", b.ISBN).Replace("$PublishDate", b.PublishDate.ToString("yyyy-MM-dd")).Replace("$Title", b.Title).Replace("$UnitPrice", b.UnitPrice.ToString("0.00")).Replace("$bookId",b.Id.ToString());
                string desPath = HttpContext.Current.Server.MapPath("/StaticHtml/" + b.PublishDate.Year + "/" + b.PublishDate.Month + "/");
                Directory.CreateDirectory(Path.GetDirectoryName(desPath));
                File.WriteAllText(desPath+b.Id+".html", txt,Encoding.UTF8);
            }
        }

        #endregion  BasicMethod

    }
}
