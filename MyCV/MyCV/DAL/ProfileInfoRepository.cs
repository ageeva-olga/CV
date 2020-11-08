using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MyCV.DAL
{
    public class ProfileInfoRepository
    {
        public void GetProfileInfo()
        {

            using (var sqlite_conn = CreateConnection())
            {

                SQLiteDataReader sqlite_datareader;
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM PersonalInfo";

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string myreader = sqlite_datareader.GetString(0);
                    Console.WriteLine(myreader);
                }
                //sqlite_conn.Close();
            }

        }

        static SQLiteConnection CreateConnection()
        {
            var parentdir = AppDomain.CurrentDomain.BaseDirectory;
            var sqlite_conn = new SQLiteConnection($"Data Source={parentdir}\\Database\\mycvdb.db; Version=3");
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

    }
}