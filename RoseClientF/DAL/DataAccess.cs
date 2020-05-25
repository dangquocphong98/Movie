using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using RoseClientF.Helper;

namespace RoseClientF.DAL
{
    public static class DataAccess
    {
        public static List<T> LoadData<T>(string sql, DynamicParameters param = null)
        {
            List<T> ListModel = new List<T>();
            using (IDbConnection db = new SqlConnection(Helper.Helper.HelperCommon("Rose"))) 
            {
                ListModel = db.Query<T>(sql,param, commandType: CommandType.StoredProcedure).ToList();
            }
            return ListModel;
        }

        public static T Get<T>(string sql, DynamicParameters param = null)
        {
            IDbConnection db = new SqlConnection(Helper.Helper.HelperCommon("Rose"));
            return (T)Convert.ChangeType(db.Query<T>(sql,param,commandType:CommandType.StoredProcedure),typeof(T));
        }

        public static int SaveData(string sql, DynamicParameters param)
        {
           
            using (IDbConnection db = new SqlConnection(Helper.Helper.HelperCommon("Rose")))
            {
                return db.Execute(sql, param, commandType: CommandType.StoredProcedure);
            }
            
        }
    }
}