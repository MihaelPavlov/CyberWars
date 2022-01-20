namespace CyberWars.Services.Data.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Player;
    using CyberWars.Web.ViewModels.Academy;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A custom implementation of <see cref="IAcademyService"/>.
    /// </summary>
    public class AcademyService : IAcademyService
    {
        private readonly IDeletableEntityRepository<Course> courseRepository;
        private readonly IDeletableEntityRepository<Lecture> lectureRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<CompleteLecture> completeLectureRepository;
        private readonly IDeletableEntityRepository<PlayerCourse> playerCourseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AcademyService"/> class.
        /// </summary>
        public AcademyService(
            IDeletableEntityRepository<Course> courseRepository,
            IDeletableEntityRepository<Lecture> lectureRepository,
            IDeletableEntityRepository<PlayerAbility> playerAbilityRepository,
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<CompleteLecture> completeLectureRepository,
            IDeletableEntityRepository<PlayerCourse> playerCourseRepository)
        {
            this.courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            this.lectureRepository = lectureRepository ?? throw new ArgumentNullException(nameof(lectureRepository));
            this.playerAbilityRepository = playerAbilityRepository ?? throw new ArgumentNullException(nameof(playerAbilityRepository));
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.completeLectureRepository = completeLectureRepository ?? throw new ArgumentNullException(nameof(completeLectureRepository));
            this.playerCourseRepository = playerCourseRepository ?? throw new ArgumentNullException(nameof(playerCourseRepository));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            if (courseName.Contains("HTML"))
            {
                courseName = "HTML & CSS";
            }

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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<CompleteLecture> GetCompleteLectureById(string playerId, int lectureId)
        {
            return await this.completeLectureRepository.All().FirstOrDefaultAsync(x => x.PlayerId == playerId && x.LectureId == lectureId);
        }

        /// <inheritdoc />
        public async Task<Lecture> GetLectureById(int lectureId)
        {
            return await this.lectureRepository.All().FirstOrDefaultAsync(x => x.Id == lectureId);
        }

        /// <inheritdoc />
        public async Task<Player> GetPlayerById(string playerId)
        {
            return await this.playerRepository.All().FirstOrDefaultAsync(x => x.Id == playerId);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<PlayerCourse> GetPlayerCourseByPlayerId(string playerId)
        {
            return await this.playerCourseRepository.All().FirstOrDefaultAsync(x => x.PlayerId == playerId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PlayerAbility>> CheckPlayerAbilities(string playerId)
        {
            return await this.playerAbilityRepository.All().Where(x => x.PlayerId == playerId).ToListAsync();
        }

        /// <summary>
        /// Use this method to collect reward from completed lecture.
        /// </summary>
        /// <param name="playerId">A string that contains the player Id.To this player we will give the reward.</param>
        /// <param name="lecture">A model <see cref="Lecture"/>.</param>
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

        /// <summary>
        /// Use this method to create new CompleteLecture model.
        /// </summary>
        /// <param name="lecture">A lecture model.</param>
        /// <param name="player">A player model.</param>
        /// <returns>A CompleteLecture model.<see cref="CompleteLecture"/>.</returns>
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

        /// <summary>
        /// Use this method to verify is the course complete.
        /// One course is complete. When all lectures from the course are completed.
        /// </summary>
        /// <param name="player">A model of player <see cref="Player"/>.</param>
        /// <param name="lecture">A model of lecture <see cref="Lecture"/>.</param>
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

        /// <summary>
        /// Use this method for debug and test purpose.
        /// </summary>
        /// <param name="lectureId">A string that contains the lecture Id.</param>
        /// <returns>A string with the course name.</returns>
        public async Task<string> GetCourseNameNormaly(int lectureId)
        {
            var course = await this.courseRepository.All().FirstOrDefaultAsync(x => x.Lectures.Any(x => x.Id == lectureId));

            return course.Name;
        }
    }
}
