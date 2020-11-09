using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace MyCV.DAL
{
    public class EducationRepository : BaseRepository
    {
        public List<Education> GetEducations()
        {
            var educationList = new List<Education>();
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "SELECT Id, Begin, End, Name FROM Education";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var education = new Education();
                    education.Id = Guid.Parse(sqlite_datareader.GetString(0));
                    education.Begin = sqlite_datareader.GetInt32(1);
                    education.End = sqlite_datareader.GetInt32(2);
                    education.SchoolName = sqlite_datareader.GetString(3);
                    educationList.Add(education);
                }
            }

            return educationList;
        }

        public void DeleteEducation(Guid id)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "DELETE FROM Education WHERE id = @id";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", id.ToString()));
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void AddEducation(Education education)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "INSERT INTO Education (Id, Begin, End, Name) VALUES (@id, @begin, @end, @name)";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", Guid.NewGuid().ToString()));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@begin", education.Begin));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@end", education.End));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@name", education.SchoolName));
                sqlite_cmd.ExecuteNonQuery();
            }
        }
    }
}