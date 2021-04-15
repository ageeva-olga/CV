using MyCV.Logic.Models;

namespace MyCV.Logic.Constracts
{
    internal interface IPersonalInfoRepository
    {
        PersonalInfo GetPersonalInfo();
        void SavePersonalInfo(PersonalInfo model);
    }
}