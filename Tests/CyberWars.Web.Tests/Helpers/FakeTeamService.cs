namespace CyberWars.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Data.Teams;
    using CyberWars.Web.ViewModels.Team;


    public class FakeTeamService : ITeamService
    {
        public async Task Abandon(int teamId, string imagePath)
        {
        }

        public async Task ApplyToTeam(string userId, int teamId)
        {
        }

        public async Task<bool> CreateTeam(string userId, RegisterTeamInputModel input, string imageName)
        {
            return true;
        }

        public Task<IEnumerable<T>> Get10RandomTeam<T>()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTeamCount()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTeamIdByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTeamNameById(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<TeamPageViewModel> GetTeamPageById(int teamId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTeamPlayerTeamIdByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetTeamRankingList<T>(int page, int itemsPetPage = 6)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsPlayerAlreadyApplyToTeam(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsTeamUsernameAlreadyUse(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsUserHaveTeam(string userId)
        {
            throw new NotImplementedException();
        }

        public Task LeaveGroup(string userId, int teamId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveImage(string imagePath)
        {
            throw new NotImplementedException();
        }

        public Task<Team> SearchTeamByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
