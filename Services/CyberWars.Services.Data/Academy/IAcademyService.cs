namespace CyberWars.Services.Data.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.Academy;

    public interface IAcademyService
    {
        public Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId);

        public Task CompleteLectureById(string userId, int lectureId);

        public Task<string> GetCourseNameByLectureId(int lectureId);
    }
}
