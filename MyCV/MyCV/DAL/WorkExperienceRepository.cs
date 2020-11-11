using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace MyCV.DAL
{
    public class WorkExperienceRepository : BaseRepository
    {
        public List<WorkExperience> GetWorkExperience()
        {
            var workExperienceList = new List<WorkExperience>();
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "SELECT Id, Begin, End, WorkName, PositionName FROM Education";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var workExperience = new WorkExperience();
                    workExperience.Id = Guid.Parse(sqlite_datareader.GetString(0));
                    workExperience.Begin = sqlite_datareader.GetString(1);
                    workExperience.End = sqlite_datareader.GetString(2);
                    workExperience.WorkName = sqlite_datareader.GetString(3);
                    workExperience.PositionName = sqlite_datareader.GetString(4);
                    workExperienceList.Add(workExperience);
                }
            }

            return workExperienceList;
        }

        public void DeleteWorkExperience(Guid id)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "DELETE FROM WorkExperience WHERE id = @id";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", id.ToString()));
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void AddWorkExperience(WorkExperience workExperience)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "INSERT INTO WorkExperience (Id, Begin, End, WorkName, PositionName) VALUES (@id, @begin, @end, @workName, @positionName)";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", Guid.NewGuid().ToString()));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@begin", workExperience.Begin));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@end", workExperience.End));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@workName", workExperience.WorkName));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@positionName", workExperience.PositionName));
                sqlite_cmd.ExecuteNonQuery();
            }
        }
    }
}