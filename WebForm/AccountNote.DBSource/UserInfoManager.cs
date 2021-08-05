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

        /// <summary>
        /// 依帳號取得使用者的資訊
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static DataRow GETUserInfoAccount(string account)
        {
            string connectionString = DBhelper.GetConnectionString();
            string dbCommandString =
                @"SELECT  [ID] ,[Account],[PWD] ,[Name] ,[Email],[UserLevel],[CreateDate]
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
        }

        /// <summary>
        /// 依ID取得使用者資訊
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static DataRow GETUserInfoData(string ID)
        {
            string connectionString = DBhelper.GetConnectionString();
            string dbCommandString =
                @"SELECT  [ID] ,[Account],[PWD] ,[Name] ,[Email],[UserLevel],[CreateDate]
                   FROM UserInfo
                   WHERE [ID] = @id
                ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", ID));

            try
            {
                return DBhelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }
        /// <summary>
        /// 取得密碼以外的所有使用者資訊
        /// </summary>
        /// <returns></returns>
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
        public static DataTable GetUserList( string account)
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                @"SELECT  [ID] ,[Account],[Name] ,[Email],[UserLevel],[CreateDate]
                   FROM UserInfo 
                   WHERE [Account] = @account";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));
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
        /// <summary>
        /// 取得總共有多少使用者
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 判斷此帳號是否已經被使用
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static bool IsAccountCreated(string account)
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                $@"SELECT *
                    FROM UserInfo
                    WHERE Account = @account
                  ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));
            try
            {
                DataTable dt = DBhelper.ReadDataTable(connStr, dbCommand, list);
                if (dt.Rows.Count > 0 )
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        /// <summary>
        /// 建立使用者
        /// </summary>
        /// <param name="account"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="actType"></param>
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
        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteUser(string id)
        {

            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"DELETE [UserInfo]    
              WHERE 
                   ID=@id
             
                ";
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("ID", @id));

            try
            {
                DBhelper.ModifyData(connectionString, dbCommandString, paramlist);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);

            }
        }
        /// <summary>
        /// 變更使用者資訊
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool UpateUser(string id, string name, string email)
        {

            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"UPDATE [UserInfo]    
              SET
                     Name=@name, 
                     Email=@email
             WHERE 
                     ID=@id
             
                ";
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@name", name));
            paramlist.Add(new SqlParameter("@email", email));
            paramlist.Add(new SqlParameter("ID", @id));
            try
            {

                int effectRows = DBhelper.ModifyData(connectionString, dbCommandString, paramlist);
                return true;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        /// <summary>
        /// 更變使用者密碼
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool UpatePassword(string id, string pwd)
        {

            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"UPDATE [UserInfo]    
              SET
                     PWD=@pwd
             WHERE 
                     ID=@id
             
                ";
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@PWD", pwd));
            paramlist.Add(new SqlParameter("ID", @id));
            try
            {

                int effectRows = DBhelper.ModifyData(connectionString, dbCommandString, paramlist);
                return true;

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        /// <summary>
        /// 建立新使用者的GUID
        /// </summary>
        /// <returns></returns>
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
