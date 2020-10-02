using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class PersonalInfoModel
    {
        public string Name => "Olga";
        public string Surname => "Ageeva";
        public string Phone => "+79200513315";
        public string Email => "olga.ageeva.999@mail.ru";

        public string FullName => $"{Name} {Surname}";
    }
}