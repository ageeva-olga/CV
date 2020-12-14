using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace MyCV.DAL
{
    public class SkillsRepository : BaseRepository
    {
        public List<SkillCategory> GetSkills()
        {
            var categoryList = new List<SkillCategory>();
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
@"SELECT sc.Id as CatgoryId, sc.Name as CategoryName, s.Id as SkillId, s.Name as SkillName
FROM SkillCategory sc
LEFT JOIN Skills s ON sc.Id = s.SkillCategory;";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var id = Guid.Parse(sqlite_datareader.GetString(0));
                    var skillCategory = categoryList.FirstOrDefault(x => x.Id == id);
                    if (skillCategory == null)
                    {
                        skillCategory = new SkillCategory();
                        skillCategory.Id = id;
                        skillCategory.Name = sqlite_datareader.GetString(1);
                        categoryList.Add(skillCategory);
                    }

                    var skillIdObj = sqlite_datareader.GetValue(2);
                    var skillId = skillIdObj is DBNull ? null : (string)skillIdObj;
                    if (!string.IsNullOrEmpty(skillId))
                    {
                        var skill = new Skill();
                        skill.Id = Guid.Parse(skillId);
                        skill.Name = sqlite_datareader.GetString(3);
                        skillCategory.Skills.Add(skill);
                    }
                }
            }

            return categoryList;
        }

        public void DeleteSkill(Guid id)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "PRAGMA foreign_keys = ON; DELETE FROM Skills WHERE id = @id";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", id.ToString()));
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSkillCategory(Guid id)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var deleteSkills_cmd = sqlite_conn.CreateCommand();
                deleteSkills_cmd.CommandText =
                    "PRAGMA foreign_keys = ON; DELETE FROM Skills WHERE SkillCategory = @id";
                deleteSkills_cmd.Parameters.Add(new SQLiteParameter("@id", id.ToString()));
                deleteSkills_cmd.ExecuteNonQuery();

                var deleteCategory_cmd = sqlite_conn.CreateCommand();
                deleteCategory_cmd.CommandText =
                    "PRAGMA foreign_keys = ON; DELETE FROM SkillCategory WHERE id = @id";
                deleteCategory_cmd.Parameters.Add(new SQLiteParameter("@id", id.ToString()));
                deleteCategory_cmd.ExecuteNonQuery();
            }
        }

        public void AddSkillCategory(SkillCategory skillCategory)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "PRAGMA foreign_keys = ON; INSERT INTO SkillCategory (Id, Name) VALUES (@id, @Name)";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", Guid.NewGuid().ToString()));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@Name", skillCategory.Name));
                sqlite_cmd.ExecuteNonQuery();
            }
        }

        public void AddSkill(Skill skill, Guid skillCategory)
        {
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
                    "PRAGMA foreign_keys = ON; INSERT INTO Skills (Id, Name, SkillCategory) VALUES (@id, @Name, @SkillCategory)";

                sqlite_cmd.Parameters.Add(new SQLiteParameter("@id", Guid.NewGuid().ToString()));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@Name", skill.Name));
                sqlite_cmd.Parameters.Add(new SQLiteParameter("@SkillCategory", skillCategory.ToString()));
                sqlite_cmd.ExecuteNonQuery();
            }
        }
    }
}