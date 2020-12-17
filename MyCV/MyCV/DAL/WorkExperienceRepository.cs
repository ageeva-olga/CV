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
                    @"SELECT w.Id, Begin, End, WorkName, PositionName, se.SkillId, s.Name
                    FROM WorkExperience w
                    LEFT JOIN SkillExperience se ON w.Id = se.ExpId
                    LEFT JOIN Skills s ON s.ID = se.SkillId
                    ORDER BY Begin, End, WorkName";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var id = Guid.Parse(sqlite_datareader.GetString(0));
                    var workExperience = workExperienceList.FirstOrDefault(x => x.Id == id);
                    if (workExperience == null)
                    {
                        workExperience = new WorkExperience();
                        workExperience.Id = id;
                        workExperience.Begin = sqlite_datareader.GetInt32(1);
                        workExperience.End = sqlite_datareader.GetInt32(2);
                        workExperience.WorkName = sqlite_datareader.GetString(3);
                        workExperience.PositionName = sqlite_datareader.GetString(4);
                        workExperienceList.Add(workExperience);
                    }

                    var skillIdObj = sqlite_datareader.GetValue(5);
                    var skillId = skillIdObj is DBNull ? null : (string)skillIdObj;
                    if (!string.IsNullOrEmpty(skillId))
                    {
                        var skill = new Skill();
                        skill.Id = Guid.Parse(skillId);
                        skill.Name = sqlite_datareader.GetString(6);
                        workExperience.Skills.Add(skill);
                    }
 
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
                    @"  PRAGMA foreign_keys = ON; 
                        DELETE FROM SkillExperience WHERE ExpId = @id;
                        DELETE FROM WorkExperience WHERE id = @id";

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
                    "PRAGMA foreign_keys = ON; INSERT INTO WorkExperience (Id, Begin, End, WorkName, PositionName) VALUES (@id, @begin, @end, @workName, @positionName)";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", Guid.NewGuid().ToString()));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@begin", workExperience.Begin));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@end", workExperience.End));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@workName", workExperience.WorkName));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@positionName", workExperience.PositionName));
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSkillExperience(Guid id)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "PRAGMA foreign_keys = ON; DELETE FROM SkillExperience WHERE SkillId = @id";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", id.ToString()));
                sqlite_cmd.ExecuteNonQuery();
            }
        }
    }
}