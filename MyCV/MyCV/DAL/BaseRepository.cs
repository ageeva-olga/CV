using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace MyCV.DAL
{
    public class BaseRepository
    {
        protected SQLiteConnection CreateConnection()
        {
            var parentdir = AppDomain.CurrentDomain.BaseDirectory;
            var sqlite_conn = new SQLiteConnection($"Data Source={parentdir}\\Database\\mycvdb.db; Version=3");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlite_conn;
        }
    }
}