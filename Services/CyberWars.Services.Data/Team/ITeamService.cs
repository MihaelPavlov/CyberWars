namespace CyberWars.Services.Data.Team
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.Team;

    public interface ITeamService
    {
        public Task CreateTeam(string userId, RegisterTeamInputModel input);

        public Task ApplyToTeam(string userId, int teamId);

        public Task<IEnumerable<T>> Get10RandomTeam<T>();

        public Task<TeamPageViewModel> GetTeamPageById(int teamId);

        public Task<string> GetTeamNameById(int teamId);

        public Task<int> GetTeamIdByUserId(string userId);

        public Task<int> GetTeamPlayerTeamIdByUserId(string userId);

        public bool IsUserHaveTeam(string userId);

        public Task<bool> IsPlayerAlreadyApplyToTeam(string userId);

        public Task LeaveGroup(string userId, int teamId);

        public Task Abandon(int teamId);

        public Task<IEnumerable<T>> GetTeamRankingList<T>(int page, int itemsPetPage = 6);

        public Task<int> GetTeamCount();

        public Task<bool> IsGroupNameAlreadyTaken(string name);
    }
}
