namespace CyberWars.Services.Data.Team
{
    using CyberWars.Web.ViewModels.Team;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITeamService
    {
        public Task CreateTeam(string userId, string name, string motivationalMotto, string description);

        public Task ApplyToTeam(string userId, int teamId);

        public Task<IEnumerable<T>> Get10RandomTeam<T>();

        public Task<TeamPageViewModel> GetTeamByName(string teamName);
    }
}
