using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class EducationListViewModel
    {
        public List<EducationViewModel> EducationList { get; set; }
        public EducationViewModel NewEducation { get; set; }
    }
}