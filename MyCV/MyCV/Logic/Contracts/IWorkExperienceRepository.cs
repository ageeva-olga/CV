using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCV.Logic.Contracts
{
    interface IWorkExperienceRepository
    {
        public List<WorkExperience> GetWorkExperience();
        public void DeleteWorkExperience(Guid id);
        public void AddWorkExperience(WorkExperience workExperience);
        public void DeleteSkillExperience(Guid id);
    }
}
