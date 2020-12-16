namespace CyberWars.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Data.Academy;
    using CyberWars.Web.ViewModels.Academy;

    public class FakeAcademyService : IAcademyService
    {
        public async Task<IEnumerable<PlayerAbility>> CheckPlayerAbilities(string playerId)
        {
            var result = new List<PlayerAbility>
            {
               new PlayerAbility{PlayerId="Test", AbilityId=1, },
               new PlayerAbility{ PlayerId="Test", AbilityId=2, },
               new PlayerAbility{ PlayerId="Test", AbilityId=3, },
            };

            return await Task.FromResult(result);
        }

        public async Task CompleteLectureById(string userId, int lectureId)
        {

        }

        public async Task<CompleteLecture> GetCompleteLectureById(string playerId, int lectureId)
        {
            var result = new CompleteLecture
            {
                LectureId = 1,
                PlayerId = "Test",
            };

            return await Task.FromResult(result);
        }

        public async Task<string> GetCourseNameByLectureId(int lectureId)
        {
            return "Test";

        }

        public async Task<Lecture> GetLectureById(int lectureId)
        {
            var result = new Lecture
            {
                Id = 1,
            };

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId)
        {
            var result = new List<LectureViewModel>
            {
               new LectureViewModel{ CourseId =1,Id=1,},
               new LectureViewModel{ CourseId =1,Id=1,},
               new LectureViewModel{ CourseId =1,Id=1,},
            };

            return await Task.FromResult(result);
        }

        public async Task<Player> GetPlayerById(string playerId)
        {
            var result = new Player
            {
                Id = "Test",
                UserId = "TestUser",
            };

            return await Task.FromResult(result);
        }

        public async Task<PlayerCourse> GetPlayerCourseByPlayerId(string playerId)
        {

            var result = new PlayerCourse
            {
                CourseId = 1,
                PlayerId = "Test",
            };

            return await Task.FromResult(result);

        }
    }
}
