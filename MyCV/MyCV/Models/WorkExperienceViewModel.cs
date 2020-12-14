using MyCV.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class WorkExperienceViewModel
    {
        [Required(ErrorMessage = "*")]
        [Range(0, int.MaxValue, ErrorMessage = Consts.NumberRequired)]
        public string Begin { get; set; }

        [Required(ErrorMessage = "*")]
        [Range(0, int.MaxValue, ErrorMessage = Consts.NumberRequired)]
        public string End { get; set; }

        [Required(ErrorMessage = "*")]
        public string WorkName { get; set; }

        [Required(ErrorMessage ="*")]
        public string PositionName { get; set; }
        public Guid Id { get; set; }

        public List<SkillViewModel> Skills { get; set; }


        public WorkExperienceViewModel()
        {
        }

        public WorkExperienceViewModel(string begin, string end, string workName, string positionName)
        {
            Begin = begin;
            End = end;
            WorkName = workName;
            PositionName = positionName;
            Id = Guid.NewGuid();
        }

        public WorkExperienceViewModel(WorkExperience workExperience)
        {
            Id = workExperience.Id;
            Begin = workExperience.Begin.ToString();
            End = workExperience.End.ToString();
            WorkName = workExperience.WorkName;
            PositionName = workExperience.PositionName;
            Skills = workExperience.Skills.Select(skill => new SkillViewModel("DeleteSkillExperience",skill)).ToList();
        }

        public void FillModel(WorkExperience model)
        {
            model.WorkName = WorkName;
            model.PositionName = PositionName;
            model.Begin = int.Parse(Begin);
            model.End = int.Parse(End);
        }
    }
}