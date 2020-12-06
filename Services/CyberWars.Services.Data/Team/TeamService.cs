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
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public TeamService(IDeletableEntityRepository<Team> teamRepository,
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<TeamPlayer> teamPlayerRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.teamRepository = teamRepository;
            this.playerRepository = playerRepository;
            this.teamPlayerRepository = teamPlayerRepository;
            this.userRepository = userRepository;
        }

        public async Task ApplyToTeam(string userId, int teamId)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.PlayerId == player.Id);

            // If The Leader of the group try apply to his group
            if (team.UserId == user.Id)
            {
                return;
            }

            // If already have team and try apply to other group
            if (user.TeamId != 0)
            {
                return;
            }

            // If palyer already has apply in team
            var isPlayerAlreadyInTeam = await this.teamPlayerRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId);
            if (isPlayerAlreadyInTeam != null)
            {
                return;
            }

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

        public async Task CreateTeam(string userId, RegisterTeamInputModel input)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == userId);

            var newTeam = new Team
            {
                UserId = userId,
                Name = input.Name,
                MotivationalMotto = input.MotivationalMotto,
                Description = input.Description,
            };

            await this.teamRepository.AddAsync(newTeam);
            await this.teamRepository.SaveChangesAsync();

            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);
            user.TeamId = team.Id;
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
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
                    PlayerName = this.playerRepository.All().FirstOrDefault(x => x.Id == teamPlayer.PlayerId).Name,
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

        public async Task<string> GetTeamNameById(int teamId)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);

            return team.Name;
        }

        public async Task<string> GetTeamNameByUserId(string userId)
        {
            var team = await this.teamRepository.All().Select(x => new { x.Name, x.UserId }).FirstOrDefaultAsync(x => x.UserId == userId);

            return team.Name;
        }

        public async Task<string> GetTeamPlayerTeamNameByUserId(string userId)
        {
            var team = await this.teamPlayerRepository.All().Select(x => new { x.Team.Name, x.Player.UserId }).FirstOrDefaultAsync(x => x.UserId == userId);

            return team.Name;
        }

        public bool IsUserHaveTeam(string userId)
        {
            return this.teamRepository.All().Any(x => x.UserId == userId);
        }

        public async Task<bool> IsPlayerAlreadyApplyToTeam(string userId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            return this.teamPlayerRepository.All().Any(x => x.PlayerId == player.Id);
        }

        public async Task LeaveGroup(string userId, int teamId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var teamPlayer = await this.teamPlayerRepository.All().FirstOrDefaultAsync(x => x.TeamId == teamId && x.PlayerId == player.Id);

            this.teamPlayerRepository.HardDelete(teamPlayer);
            await this.teamPlayerRepository.SaveChangesAsync();
        }


        public async Task Abandon( int teamId)
        {
            var teamPlayers = await this.teamPlayerRepository.All().Where(x => x.TeamId == teamId).ToListAsync();

            foreach (var teamPlayer in teamPlayers)
            {
                this.teamPlayerRepository.HardDelete(teamPlayer);
            }

            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.TeamId == teamId);

            user.TeamId = 0;

            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();

            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);

            this.teamRepository.HardDelete(team);

            await this.teamRepository.SaveChangesAsync();

            await this.teamPlayerRepository.SaveChangesAsync();

        }
    }
}
