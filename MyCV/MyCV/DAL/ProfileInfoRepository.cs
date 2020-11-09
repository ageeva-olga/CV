using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MyCV.Logic.Models;

namespace MyCV.DAL
{
    public class ProfileInfoRepository
    {
        public PersonalInfo GetPersonalInfo()
        {
            var profile = new PersonalInfo();
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "SELECT Id, Name, SureName, Email, Phone FROM PersonalInfo";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    profile.Id = sqlite_datareader.GetString(0);
                    profile.Name = sqlite_datareader.GetString(1);
                    profile.Surname = sqlite_datareader.GetString(2);
                    profile.Email = sqlite_datareader.GetString(3);
                    profile.Phone = sqlite_datareader.GetString(4);
                }
            }

            return profile;
        }

        public void SavePersonalInfo(PersonalInfo model)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
@"UPDATE PersonalInfo 
SET Name = @name, SureName = @surename, Email = @email, Phone = @phone 
WHERE Id = @id";
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", model.Id));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@name", model.Name));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@surename", model.Surname));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@email", model.Email));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@phone", model.Phone));
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        private static SQLiteConnection CreateConnection()
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