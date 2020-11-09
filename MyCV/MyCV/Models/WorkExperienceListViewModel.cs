using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class WorkExperienceListViewModel
    {
        public List<WorkExperienceViewModel> WorkExperienceList { get; set; }
        public WorkExperienceViewModel NewWorkExpirience { get; set; }
    }
}