using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.DAL
{
    public class SkillsRepository : BaseRepository
    {
        public List<SkillCategory> GetSkills()
        {
            var skillList = new List<SkillCategory>();
            using (var sqlite_conn = CreateConnection())
            {
                var sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText =
@"SELECT sc.Id as CatgoryId, sc.Name as CategoryName, s.Id as SkillId, s.Name as SkillName
FROM SkillCategory sc
INNER JOIN Skills s ON sc.Id = s.SkillCategory;";

                var sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    var id = Guid.Parse(sqlite_datareader.GetString(0));
                    var skillCategory = skillList.FirstOrDefault(x => x.Id == id);
                    if (skillCategory == null)
                    {
                        skillCategory = new SkillCategory();
                        skillCategory.Id = id;
                        skillCategory.Name = sqlite_datareader.GetString(1);
                        skillList.Add(skillCategory);
                    }

                    var skill = new Skill();
                    skill.Id = Guid.Parse(sqlite_datareader.GetString(2));
                    skill.Name = sqlite_datareader.GetString(3);
                    skillCategory.Skills.Add(skill);
                }
            }

            return skillList;
        }
    }
}