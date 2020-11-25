namespace CyberWars.Services.Data.Team
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Team;
    using CyberWars.Web.ViewModels.Team;
    using CyberWars.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class TeamService : ITeamService
    {
        private readonly IDeletableEntityRepository<Team> teamRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<TeamPlayer> teamPlayerRepository;

        public TeamService(IDeletableEntityRepository<Team> teamRepository, IDeletableEntityRepository<Player> playerRepository, IDeletableEntityRepository<TeamPlayer> teamPlayerRepository)
        {
            this.teamRepository = teamRepository;
            this.playerRepository = playerRepository;
            this.teamPlayerRepository = teamPlayerRepository;
        }

        public async Task ApplyToTeam(string userId, int teamId)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var teamPlayer = new TeamPlayer
            {
                Player = player,
                PlayerId = player.Id,
                Team = team,
                TeamId = team.Id,
            };
            team.TeamPlayers.Add(teamPlayer);
            this.teamRepository.Update(team);
            await this.teamRepository.SaveChangesAsync();
        }

        public async Task CreateTeam(string userId, string name, string motivationalMotto, string description)
        {

            var newTeam = new Team
            {
                UserId = userId,
                Name = name,
                MotivationalMotto = motivationalMotto,
                Description = description,
            };

            await this.teamRepository.AddAsync(newTeam);
            await this.teamRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get10RandomTeam<T>()
        {
            return await this.teamRepository.All().Take(10).To<T>().ToListAsync();
        }

        public async Task<TeamPageViewModel> GetTeamByName(string teamName)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Name == teamName);

            var teamPlayers = await this.teamPlayerRepository.All().Where(x => x.TeamId == team.Id).ToListAsync();

            var viewTeamPlayer = new List<TeamPlayersViewModel>();

            foreach (var teamPlayer in teamPlayers)
            {
                viewTeamPlayer.Add(new TeamPlayersViewModel
                {
                    PlayerName =this.playerRepository.All().FirstOrDefault(x=>x.Id==teamPlayer.PlayerId).Name,
                    PlayerId = teamPlayer.PlayerId,
                    TeamName = teamPlayer.Team.Name,
                    TeamId = teamPlayer.TeamId,
                });
            }

            var viewTeamPage = new TeamPageViewModel
            {
                LeaderName = this.playerRepository.All().FirstOrDefault(x => x.UserId == team.UserId).Name,
                Name = team.Name,
                Description = team.Description,
                Id = team.Id,
                MotivationalMotto = team.MotivationalMotto,
                UserId = team.UserId,
                TeamPlayers = viewTeamPlayer,
                Rank = team.Rank,
            };

            return viewTeamPage;
        }
    }
}
