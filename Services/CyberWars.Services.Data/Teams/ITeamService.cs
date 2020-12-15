namespace CyberWars.Services.Data.Teams
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Teams;
    using CyberWars.Web.ViewModels.Team;

    public interface ITeamService
    {
        public Task<bool> CreateTeam(string userId, RegisterTeamInputModel input, string imageName);

        public Task<bool> IsTeamUsernameAlreadyUse(string name);

        public Task ApplyToTeam(string userId, int teamId);

        public Task<IEnumerable<T>> Get10RandomTeam<T>();

        public Task<TeamPageViewModel> GetTeamPageById(int teamId);

        public Task<string> GetTeamNameById(int teamId);

        public Task<int> GetTeamIdByUserId(string userId);

        public Task<int> GetTeamPlayerTeamIdByUserId(string userId);

        public bool IsUserHaveTeam(string userId);

        public Task<bool> IsPlayerAlreadyApplyToTeam(string userId);

        public Task LeaveGroup(string userId, int teamId);

        public Task Abandon(int teamId, string imagePath);

        public Task RemoveImage(string imagePath);

        public Task<IEnumerable<T>> GetTeamRankingList<T>(int page, int itemsPetPage = 6);

        public Task<int> GetTeamCount();

        public Task<Team> SearchTeamByName(string name);
    }
}
