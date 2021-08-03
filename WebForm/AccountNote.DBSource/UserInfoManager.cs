using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AccountNote.DBSource
{
    public class UserInfoManager
    {
        //,[UserLevel],[CreateDate]

        public static DataRow GETUserInfoAccount(string account)
        {
            string connectionString = DBhelper.GetConnectionString();
            string dbCommandString =
                @"SELECT  [ID] ,[Account],[PWD] ,[Name] ,[Email]
                   FROM UserInfo
                   WHERE [Account] = @account
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBhelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(dbCommandString, connection);
            //    command.Parameters.AddWithValue("@account", account);//確保資料安全性

            //    try
            //    {
            //        connection.Open();
            //        SqlDataReader reader = command.ExecuteReader();

            //        DataTable dt = new DataTable();
            //        dt.Load(reader);
            //        reader.Close();

            //        if (dt.Rows.Count == 0)
            //            return null;

            //        DataRow dr = dt.Rows[0];
            //        return dr;

            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //        return null;
            //    }
            //}//自帶connection.close()
        }
        public static DataTable GetUserList()
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                @"SELECT  [ID] ,[Account],[Name] ,[Email],[UserLevel],[CreateDate]
                   FROM UserInfo ";

            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                return DBhelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static DataRow GetUserCount()
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                $@"SELECT Count(*) AS UserCount
                    FROM UserInfo
                  ";

            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                return DBhelper.ReadDataRow(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        public static bool IsAdministrator(string account)
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                $@"SELECT UserLevel
                    FROM UserInfo
                    WHERE Account = @account
                  ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));
            try
            {
                DataRow dr = DBhelper.ReadDataRow(connStr, dbCommand, list);
                if(dr == null)
                    return false;
                if (string.Compare(dr[0].ToString(), "0") == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        public static void CreateUser(string account, string name, string email, int actType)
        {
            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"INSERT INTO UserInfo
                       (ID,Account,PWD,Name,Email,UserLevel,CreateDate)
                    VALUES
                       (
                         @id,
                         @account, 
                         @password,
                         @name,
                         @email,
                         @actType,
                         @CreateDate);
             
                ";
            string userInfoID = GetUserInfoID();
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@id", userInfoID));
            paramlist.Add(new SqlParameter("@account", account));
            paramlist.Add(new SqlParameter("@password", "12345"));
            paramlist.Add(new SqlParameter("@name", name));
            paramlist.Add(new SqlParameter("@email", email));
            paramlist.Add(new SqlParameter("@actType", actType));
            paramlist.Add(new SqlParameter("@CreateDate", DateTime.Now));
            try
            {
                DBhelper.ModifyData(connectionString, dbCommandString, paramlist);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static string GetUserInfoID()
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                @"SELECT NEWID() ";

            List<SqlParameter> list = new List<SqlParameter>();
            try
            {
                DataRow dr = DBhelper.ReadDataRow(connStr, dbCommand, list);
                string userInfoID = dr[0].ToString();
                return userInfoID;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

        }
    }
}
