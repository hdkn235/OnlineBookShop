using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace BookShop.DAL
{
    /// <summary>
    /// 数据访问类:UsersDAL
    /// </summary>
    public partial class UsersDAL
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string LoginId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Users");
            strSql.Append(" where LoginId=@LoginId");
            SqlParameter[] parameters = { new SqlParameter("@LoginId", SqlDbType.NVarChar, 50) };
            parameters[0].Value = LoginId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 激活账户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SetActived(int id)
        {
            string sql = "update users set Actived=1 where id=" + id;
            int rows = DbHelperSQL.ExecuteSql(sql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BookShop.Model.Users GetModelByLoginId(string LoginId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LoginId,LoginPwd,Name,Address,Phone,Mail,UserStateId,Actived,ActiveCode from Users ");
            strSql.Append(" where LoginId=@LoginId");
            SqlParameter[] parameters = {
					new SqlParameter("@LoginId", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = LoginId;

            BookShop.Model.Users model = new BookShop.Model.Users();
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

