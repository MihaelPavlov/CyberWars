namespace CyberWars.Services.Data.Academy
{
    using CyberWars.Web.ViewModels.Academy;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAcademyService
    {
        public Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId);
    }
}
