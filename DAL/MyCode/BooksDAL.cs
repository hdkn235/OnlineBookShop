using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
using BookShop.Model;
namespace BookShop.DAL
{
    /// <summary>
    /// 数据访问类:BooksDAL
    /// </summary>
    public partial class BooksDAL
    {
        public int GetBooksCount(int categoryId)
        {
            string sql = string.Format("select count(1) from Books {0}", categoryId == 0 ? "" : "where CategoryId=@CategoryId");
            SqlParameter param = new SqlParameter("@CategoryId", categoryId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql, param));
        }

        public DataTable GetPagedBooks(int pageIndex, int pageSize, int categoryId,string orderBy)
        {
            string sql = "usp_GetPagedBooks";
            SqlParameter[] param = { new SqlParameter("@PageIndex",SqlDbType.Int),
                                    new SqlParameter("@PageSize",SqlDbType.Int),
                                    new SqlParameter("@CategoryId",SqlDbType.Int),
                                    new SqlParameter("@OrderBy",SqlDbType.NVarChar)
                                 };
            param[0].Value = pageIndex;
            param[1].Value = pageSize;
            param[2].Value = categoryId;
            param[3].Value = orderBy;
           return DbHelperSQL.RunProcedure(sql, param, "PagedBooks").Tables[0];
        }
    }
}

