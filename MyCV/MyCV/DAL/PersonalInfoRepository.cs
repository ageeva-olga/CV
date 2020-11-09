using System.Data.SQLite;
using System;
using MyCV.Logic.Models;

namespace MyCV.DAL
{
    public class PersonalInfoRepository: BaseRepository
    {
        public PersonalInfo GetPersonalInfo()
        {
            var personalInfo = new PersonalInfo();
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "SELECT Id, Name, SureName, Email, Phone FROM PersonalInfo";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    personalInfo.Id = sqlite_datareader.GetString(0);
                    personalInfo.Name = sqlite_datareader.GetString(1);
                    personalInfo.Surname = sqlite_datareader.GetString(2);
                    personalInfo.Email = sqlite_datareader.GetString(3);
                    personalInfo.Phone = sqlite_datareader.GetString(4);
                }
            }

            return personalInfo;
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
    }
}