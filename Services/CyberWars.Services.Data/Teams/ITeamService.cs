namespace CyberWars.Services.Data.Teams
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Teams;
    using CyberWars.Web.ViewModels.Team;

    public interface ITeamService
    {
        /// <summary>
        /// Use this method to create team.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <param name="input">Information about the new team <see cref="RegisterTeamInputModel"/>.</param>
        /// <param name="imageName">A string representing the image.</param>
        /// <returns>A bool that tell us. Was the creation of the Team successful?.</returns>
        public Task<bool> CreateTeam(string userId, RegisterTeamInputModel input, string imageName);

        /// <summary>
        /// Use this method to check is the name already used.
        /// </summary>
        /// <param name="name">A string representing the name.</param>
        /// <returns>A bool that tell us, if the name is already used.</returns>
        public Task<bool> IsTeamUsernameAlreadyUse(string name);

        /// <summary>
        /// Use this method to apply for team.
        /// </summary>
        /// <param name="userId">A string representing the user Id.</param>
        /// <param name="teamId">A integer representing Id of the team in which we want to apply.</param>
        public Task ApplyToTeam(string userId, int teamId);

        /// <summary>
        /// Use this method to get collection of the ten most stronger teams.
        /// </summary>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> Get10StrongerTeam<T>();

        /// <summary>
        /// Use this method to get team page by Id.
        /// </summary>
        /// <param name="teamId">A integer representing Id of the team that we want to see.</param>
        /// <returns>A view model <see cref="TeamPageViewModel"/>.</returns>
        public Task<TeamPageViewModel> GetTeamPageById(int teamId);

        /// <summary>
        /// Use this method to get team name by Id.
        /// </summary>
        /// <param name="teamId">A integer representing Id of the team.</param>
        /// <returns>A string with team name.</returns>
        public Task<string> GetTeamNameById(int teamId);

        /// <summary>
        /// Use this method to get team Id by user Id.
        /// It will only return teamId if the user have team.
        /// </summary>
        /// <param name="userId">A string representing user Id.</param>
        /// <returns>A integer that contains the team Id.</returns>
        public Task<int> GetTeamIdByUserId(string userId);

        /// <summary>
        /// Use this method to get TeamPlayer team Id by user Id.
        /// </summary>
        /// <param name="userId">A string representing user Id.</param>
        /// <returns>A integer that contains the team Id.</returns>
        public Task<int> GetTeamPlayerTeamIdByUserId(string userId);

        /// <summary>
        /// Use this method to check is user have team.
        /// </summary>
        /// <param name="userId">A string representing user Id.</param>
        /// <returns>A boolean that returns whether the user has a team.</returns>
        public bool IsUserHaveTeam(string userId);

        /// <summary>
        /// Use this method to check is the player already apply for a team.
        /// </summary>
        /// <param name="userId">A string representing user Id.</param>
        /// <returns>A boolean which shows us whether the player has applied to the team.</returns>
        public Task<bool> IsPlayerAlreadyApplyToTeam(string userId);

        /// <summary>
        /// Use this method to leave a team.
        /// </summary>
        /// <param name="userId">A string representing user Id.</param>
        /// <param name="teamId">A integer representing team Id.</param>
        public Task LeaveGroup(string userId, int teamId);

        /// <summary>
        /// Use this method to abandon team.
        /// You can abandon team only if u are the creator.
        /// </summary>
        /// <param name="teamId">A integer representing team Id.</param>
        /// <param name="imagePath">A string representing image path.</param>
        public Task Abandon(int teamId, string imagePath);

        /// <summary>
        /// Use this method to delete a image.
        /// </summary>
        /// <param name="imagePath">A string representing image path that we want to delete.</param>
        public Task RemoveImage(string imagePath);

        /// <summary>
        /// Use this method to get teams order by rank.
        /// </summary>
        /// <param name="page">A integer representing the number of the page.</param>
        /// <param name="itemsPetPage">A integer representing the number of items we want per page.</param>
        /// <returns>A collection of T.</returns>
        public Task<IEnumerable<T>> GetTeamRankingList<T>(int page, int itemsPetPage = 6);

        /// <summary>
        /// Use this method to get the count of all teams.
        /// </summary>
        /// <returns>A integer that contains the count of all teams.</returns>
        public Task<int> GetTeamCount();

        /// <summary>
        /// Use this method to search for a team by name.
        /// </summary>
        /// <param name="name">A string representing the name of team that we want.</param>
        /// <returns>A model <see cref="Team"/>.</returns>
        public Task<Team> SearchTeamByName(string name);
    }
}
