using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class EducationModel
    {

        public string Begin { get; set; }
        public string End { get; set; }
        public string SchoolName { get; set; }
        public Guid Id { get; set; }

        public EducationModel(string begin, string end, string schoolName)
            :this()
        {
            Begin = begin;
            End = end;
            SchoolName = schoolName;
        }

        public EducationModel()
        {
            Id = Guid.NewGuid();
        }
    }
}