using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace AccountNote.DBSource
{
    public class AccountingManager
    {
        //public static string GetConnectionString()
        //{
        //    // string val = ConfigurationManager.AppSettings["ConnectionString"];
        //    string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    return val;
        //}

        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                $@"SELECT ID,
                         Caption,
                         Amount,
                         ActType,
                         CreateDate
                    FROM AccountingNote
                    WHERE UserID = @userID
                  ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));
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


        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                $@"SELECT ID,
                         Caption,
                         Amount,
                         ActType,
                         CreateDate,
                         Body
                    FROM AccountingNote
                    WHERE ID = @id AND UserID = @userID
                  ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));
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


        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount必須介於0到1000000之間");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType必須介於0到1之間");


            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"INSERT INTO AccountingNote
                       (UserID,Caption,Amount,ActType,CreateDate,Body)
                    VALUES
                       (
                         @userID, 
                         @caption,
                         @amount,
                         @actType,
                         @createDate, 
                         @body);
             
                ";

            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@userID", userID));
            paramlist.Add(new SqlParameter("@caption", caption));
            paramlist.Add(new SqlParameter("@amount", amount));
            paramlist.Add(new SqlParameter("@actType", actType));
            paramlist.Add(new SqlParameter("@createDate", DateTime.Now));
            paramlist.Add(new SqlParameter("@body", body));
            try
            {

                DBhelper.ModifyData(connectionString, dbCommandString, paramlist);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpateAccount(int id, string userID, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("Amount必須介於0到1000000之間");
            if (actType < 0 || actType > 1)
                throw new ArgumentException("actType必須介於0到1之間");


            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"UPDATE [AccountingNote]    
              SET
                     UserID=@userID, 
                     Caption=@caption,
                     Amount=@amount,
                     ActType=@actType,
                     CreateDate=@createDate, 
                     Body=@body
             WHERE 
                     ID=@id
             
                ";
            List<SqlParameter> paramlist = new List<SqlParameter>();
            paramlist.Add(new SqlParameter("@userID", userID));
            paramlist.Add(new SqlParameter("@caption", caption));
            paramlist.Add(new SqlParameter("@amount", amount));
            paramlist.Add(new SqlParameter("@actType", actType));
            paramlist.Add(new SqlParameter("@createDate", DateTime.Now));
            paramlist.Add(new SqlParameter("@body", body));
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

        public static void DeleteAccount(int id)
        {

            string connectionString = DBhelper.GetConnectionString();

            string dbCommandString =
            @"DELETE [AccountingNote]    
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
        public static DataRow GetDateAndCount()
        {
            string connStr = DBhelper.GetConnectionString();
            string dbCommand =
                $@"SELECT Max(AccountingNote.CreateDate)AS FirstTime,
                         MIN(AccountingNote.CreateDate)AS LastTime,
                         Count(*)AS AccountCount
                    FROM AccountingNote
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


    }
}
