namespace CyberWars.Services.Data.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Player;
    using CyberWars.Web.ViewModels.Academy;

    public interface IAcademyService
    {
        public Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId);

        public Task CompleteLectureById(string userId, int lectureId);

        public Task<CompleteLecture> GetCompleteLectureById(string playerId, int lectureId);

        public Task<Lecture> GetLectureById(int lectureId);

        public Task<Player> GetPlayerById(string playerId);

        public Task<IEnumerable<PlayerAbility>> CheckPlayerAbilities(string playerId);

        public Task<string> GetCourseNameByLectureId(int lectureId);

        public Task<PlayerCourse> GetPlayerCourseByPlayerId(string playerId);
    }
}
