using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCV.Logic.Contracts
{
    interface IEducationRepository
    {
        public List<Education> GetEducations();
        public void AddEducation(Education education);
        public void DeleteEducation(Guid id);
    }
}
