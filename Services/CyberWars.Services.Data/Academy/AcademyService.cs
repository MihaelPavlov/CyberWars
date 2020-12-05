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

        public AcademyService(IDeletableEntityRepository<Course> courseRepository
            , IDeletableEntityRepository<Lecture> lectureRepository, IDeletableEntityRepository<PlayerAbility> playerAbilityRepository
            , IDeletableEntityRepository<Player> playerRepository)
        {
            this.courseRepository = courseRepository;
            this.lectureRepository = lectureRepository;
            this.playerAbilityRepository = playerAbilityRepository;
            this.playerRepository = playerRepository;
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
            }).ToListAsync();
        }

        public async Task GivePointToAbilityByName(string userId, string rewardAbilityName)
        {
            var courses = await this.playerAbilityRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.Ability.Name == rewardAbilityName);

            if (rewardAbilityName.Contains("Exam"))
            {
                // point +3;
            }
            else if (rewardAbilityName.Contains("End"))
            {
                // point +10;
            }
            else
            {
                // point +1;
            }
        }


    }
}
