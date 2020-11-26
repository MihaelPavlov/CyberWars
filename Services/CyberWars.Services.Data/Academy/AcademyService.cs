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
    using Microsoft.EntityFrameworkCore;

    public class AcademyService : IAcademyService
    {
        private readonly IDeletableEntityRepository<Course> courseRepository;
        private readonly IDeletableEntityRepository<Lecture> lectureRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;

        public AcademyService(IDeletableEntityRepository<Course> courseRepository
            , IDeletableEntityRepository<Lecture> lectureRepository, IDeletableEntityRepository<PlayerAbility> playerAbilityRepository)
        {
            this.courseRepository = courseRepository;
            this.lectureRepository = lectureRepository;
            this.playerAbilityRepository = playerAbilityRepository;
        }

        public async Task<IEnumerable<T>> GetLecturesByName<T>(string courseName)
        {
            return await this.lectureRepository.All().Where(x => x.Course.Name == courseName).OrderBy(x => x.Number).To<T>().ToListAsync();
        }

        public async Task GivePointToAbilityByName(string userId, string rewardAbilityName)
        {
            var courses = await this.playerAbilityRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.Ability.Name == rewardAbilityName);

            if (rewardAbilityName.Contains("Exam"))
            {
                // point +3;
            }
            else
            {
                // point +1;
            }
        }
    }
}
