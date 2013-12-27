using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Maticsoft.DBUtility;

namespace BookShop.DAL
{
    public partial class SettingsDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BookShop.Model.Settings GetModel(string name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Value from Settings ");
            strSql.Append(" where Name=@Name");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = name;

            BookShop.Model.Settings model = new BookShop.Model.Settings();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
