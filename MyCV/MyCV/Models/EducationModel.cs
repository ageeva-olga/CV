using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class EducationModel
    {

        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public string SchoolName { get; set; }

        public EducationModel(DateTime begin, DateTime end, string schoolName)
        {
            Begin = begin;
            End = end;
            SchoolName = schoolName;
        }
    }
}