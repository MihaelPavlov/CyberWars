namespace CyberWars.Services.Data.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.Academy;
    using Microsoft.EntityFrameworkCore;

    public class AcademyService : IAcademyService
    {
        private readonly IDeletableEntityRepository<Course> courseRepository;
        private readonly IDeletableEntityRepository<Lecture> lectureRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<CompleteLecture> completeLectureRepository;
        private readonly IDeletableEntityRepository<PlayerCourse> playerCourseRepository;

        public AcademyService(
            IDeletableEntityRepository<Course> courseRepository,
            IDeletableEntityRepository<Lecture> lectureRepository,
            IDeletableEntityRepository<PlayerAbility> playerAbilityRepository,
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<CompleteLecture> completeLectureRepository,
            IDeletableEntityRepository<PlayerCourse> playerCourseRepository)
        {
            this.courseRepository = courseRepository;
            this.lectureRepository = lectureRepository;
            this.playerAbilityRepository = playerAbilityRepository;
            this.playerRepository = playerRepository;
            this.completeLectureRepository = completeLectureRepository;
            this.playerCourseRepository = playerCourseRepository;
        }

        public async Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            return await this.lectureRepository.All().Where(x => x.Course.Name == courseName).OrderBy(x => x.Number).Select(x => new LectureViewModel
            {
                CourseId = x.CourseId,
                CourseName = x.Course.Name,
                ExperienceToComplete = x.ExperienceToComplete,
                Name = x.Name,
                RewardAbilityName = x.RewardAbilityName,
                RewardMoney = x.RewardMoney,
                PlayerExperience = player.Experience,
                Id = x.Id,
            }).ToListAsync();
        }

        public async Task CompleteLectureById(string userId, int lectureId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var lecture = await this.lectureRepository.All().FirstOrDefaultAsync(x => x.Id == lectureId);

            var completeLecture = this.CreateCompleteLecture(lecture, player);

            await this.GetRewardFromCompleteLecture(player.Id, lecture);
            await this.completeLectureRepository.AddAsync(completeLecture);

            await this.completeLectureRepository.SaveChangesAsync();

            await this.CheckIsCourseComplete(player, lecture);
        }

        public async Task<CompleteLecture> GetCompleteLectureById(string playerId, int lectureId)
        {
            return await this.completeLectureRepository.All().FirstOrDefaultAsync(x => x.PlayerId == playerId && x.LectureId == lectureId);
        }

        public async Task<Lecture> GetLectureById(int lectureId)
        {
            return await this.lectureRepository.All().FirstOrDefaultAsync(x => x.Id == lectureId);
        }

        public async Task GetRewardFromCompleteLecture(string playerId, Lecture lecture)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.Id == playerId);
            player.Money += lecture.RewardMoney;

            var playerAbilties = await this.playerAbilityRepository.All().Where(x => x.PlayerId == player.Id).ToListAsync();

            var splitReward = lecture.RewardAbilityName.Split(" ").ToArray();

            var abilityReward = await this.playerAbilityRepository.All().FirstOrDefaultAsync(x => x.PlayerId == playerId && x.Ability.Name == splitReward[0]);

            foreach (var reward in splitReward)
            {
                if (reward == "Exam")
                {
                    // point +3;
                    abilityReward.Points += 3;
                }
                else if (reward == "End")
                {
                    // point +10;
                    abilityReward.Points += 10;
                }
                else
                {
                    // point +1;
                    abilityReward.Points += 1;
                }
            }

            this.playerRepository.Update(player);
            await this.playerRepository.SaveChangesAsync();

            this.playerAbilityRepository.Update(abilityReward);
            await this.playerAbilityRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlayerAbility>> CheckPlayerAbilities(string playerId)
        {
            return await this.playerAbilityRepository.All().Where(x => x.PlayerId == playerId).ToListAsync();
        }

        public async Task<Player> GetPlayerById(string playerId)
        {
            return await this.playerRepository.All().FirstOrDefaultAsync(x => x.Id == playerId);
        }

        public CompleteLecture CreateCompleteLecture(Lecture lecture, Player player)
        {
            var newCompleteLecture = new CompleteLecture
            {
                IsComplete = true,
                LectureId = lecture.Id,
                PlayerId = player.Id,
            };

            return newCompleteLecture;
        }

        public async Task CheckIsCourseComplete(Player player, Lecture lecture)
        {
            bool isCourseComplete = true;

            var courseName = await this.GetCourseNameNormaly(lecture.Id);
            var courseLectures = await this.lectureRepository.All().Where(x => x.Course.Name == courseName).OrderBy(x => x.Number).ToListAsync();

            var playerCompleteLecture = await this.completeLectureRepository.All().Where(x => x.PlayerId == player.Id).ToListAsync();

            foreach (var courseLecture in courseLectures)
            {
                if (!playerCompleteLecture.Any(x => x.LectureId == courseLecture.Id))
                {
                    isCourseComplete = false;
                    break;
                }
            }

            if (isCourseComplete)
            {
                var course = await this.courseRepository.All().FirstOrDefaultAsync(x => x.Name == courseName);
                var playerCourse = new PlayerCourse()
                {
                    PlayerId = player.Id,
                    CourseId = course.Id,
                    CompleteDate = DateTime.UtcNow,
                    IsComplete = true,
                };
                await this.playerCourseRepository.AddAsync(playerCourse);
                await this.playerCourseRepository.SaveChangesAsync();
            }
        }

        public async Task<PlayerCourse> GetPlayerCourseByPlayerId(string playerId)
        {
            return await this.playerCourseRepository.All().FirstOrDefaultAsync(x => x.PlayerId == playerId);
        }

        public async Task<string> GetCourseNameNormaly(int lectureId)
        {
            var course = await this.courseRepository.All().FirstOrDefaultAsync(x => x.Lectures.Any(x => x.Id == lectureId));

            return course.Name;
        }

        public async Task<string> GetCourseNameByLectureId(int lectureId)
        {
            var course = await this.courseRepository.All().FirstOrDefaultAsync(x => x.Lectures.Any(x => x.Id == lectureId));
            var courseName = string.Empty;

            if (course.Name.Contains("C#"))
            {
                var splitName = course.Name.Split(" ");
                courseName = $"C%23 {splitName[1]}";
                if (splitName.Count() == 3)
                {
                    courseName = $"C%23 {splitName[1]} {splitName[2]}";
                }
            }

            return courseName != string.Empty ? courseName : course.Name;
        }
    }
}
