namespace CyberWars.Services.Data.Academy
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Player;
    using CyberWars.Web.ViewModels.Academy;

    /// <summary>
    /// Defines an interface for a service that will handle operations related to academy.
    /// </summary>
    public interface IAcademyService
    {
        /// <summary>
        /// Use this method to get all lectures from course.
        /// </summary>
        /// <param name="courseName">A string that contains the name of the course we want.</param>
        /// <param name="userId">A string that contains the current userId.</param>
        /// <returns>A collection of view models <see cref="LectureViewModel"/>.</returns>
        public Task<IEnumerable<LectureViewModel>> GetLecturesByName(string courseName, string userId);

        /// <summary>
        /// Use this method to complete lecture from course.
        /// </summary>
        /// <param name="userId">A string that contains the current userId.</param>
        /// <param name="lectureId">A string that contains the current lectureId that we want to complete.</param>
        public Task CompleteLectureById(string userId, int lectureId);

        /// <summary>
        /// Use this method to get one complete lecture by Id.
        /// </summary>
        /// <param name="playerId">A string that contains the current player.</param>
        /// <param name="lectureId">A string that contains the current lectureId that we want to get.</param>
        /// <returns>A view model of the complete lecture <see cref="CompleteLecture"/>.</returns>
        public Task<CompleteLecture> GetCompleteLectureById(string playerId, int lectureId);

        /// <summary>
        /// Use this method to get one lecture by Id.
        /// </summary>
        /// <param name="lectureId">A string that contains the current lectureId that we want to get.</param>
        /// <returns>A view model of the lecture <see cref="Lecture"/>.</returns>
        public Task<Lecture> GetLectureById(int lectureId);

        /// <summary>
        /// Use this method to get one player by Id;
        /// </summary>
        /// <param name="playerId">A string that contains the player Id.</param>
        /// <returns>A view model of the player <see cref="Player"/>.</returns>
        public Task<Player> GetPlayerById(string playerId);

        /// <summary>
        /// Use this method to get course name by lecture Id.
        /// </summary>
        /// <param name="lectureId">A string that contains the current lectureId.</param>
        /// <returns>A string that contains course name.</returns>
        public Task<string> GetCourseNameByLectureId(int lectureId);

        /// <summary>
        /// Use this method to get player course model by player Id.
        /// </summary>
        /// <param name="playerId">A string that contains the player Id.</param>
        /// <returns>A view model of the playerCourse <see cref="PlayerCourse"/>.</returns>
        public Task<PlayerCourse> GetPlayerCourseByPlayerId(string playerId);

        /// <summary>
        /// We use this method only in the academy service tests.
        /// </summary>
        /// <param name="playerId">A string that contains the player Id.</param>
        /// <returns>A collection of all abilities that player have.<see cref="PlayerAbility"/>.</returns>
        public Task<IEnumerable<PlayerAbility>> CheckPlayerAbilities(string playerId);
    }
}