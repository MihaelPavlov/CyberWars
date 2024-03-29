﻿namespace CyberWars.Services.Data.Teams
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.Team;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A custom implementation of <see cref="ITeamService"/>.
    /// </summary>
    public class TeamService : ITeamService
    {
        private readonly IDeletableEntityRepository<Team> teamRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<TeamPlayer> teamPlayerRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamService"/> class.
        /// </summary>
        public TeamService(
            IDeletableEntityRepository<Team> teamRepository,
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<TeamPlayer> teamPlayerRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IDeletableEntityRepository<PlayerSkill> playerSkillsRepository)
        {
            this.teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.teamPlayerRepository = teamPlayerRepository ?? throw new ArgumentNullException(nameof(teamPlayerRepository));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.playerSkillsRepository = playerSkillsRepository ?? throw new ArgumentNullException(nameof(playerSkillsRepository));
        }

        /// <inheritdoc />
        public async Task<bool> CreateTeam(string userId, RegisterTeamInputModel input, string imageName)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == userId);
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            if (player.Money < 9999)
            {
                return false;
            }

            var newTeam = new Team
            {
                UserId = userId,
                Name = input.Name,
                MotivationalMotto = input.MotivationalMotto,
                Description = input.Description,
                Rank = await this.CalculateRank(user.PlayerId),
                Image = imageName,
            };

            await this.teamRepository.AddAsync(newTeam);
            await this.teamRepository.SaveChangesAsync();

            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);
            user.TeamId = team.Id;
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();

            player.Money -= 9999;
            this.playerRepository.Update(player);
            await this.playerRepository.SaveChangesAsync();
            return true;
        }

        /// <inheritdoc />
        public async Task<bool> IsTeamUsernameAlreadyUse(string name)
        {
            return await this.teamRepository.All().AnyAsync(x => x.Name == name);
        }

        /// <inheritdoc />
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
                PlayerId = player.Id,
                TeamId = team.Id,
            };
            team.Rank += await this.CalculateRank(player.Id);
            team.TeamPlayers.Add(teamPlayer);
            this.teamRepository.Update(team);
            await this.teamRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> Get10StrongerTeam<T>()
        {
            return await this.teamRepository.All().OrderByDescending(x => x.Rank).Take(10).To<T>().ToListAsync();
        }

        /// <inheritdoc />
        public async Task<TeamPageViewModel> GetTeamPageById(int teamId)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);

            var teamPlayers = await this.teamPlayerRepository.All().Where(x => x.TeamId == team.Id).ToListAsync();

            var viewTeamPlayer = new List<TeamPlayersViewModel>();

            foreach (var teamPlayer in teamPlayers)
            {
                viewTeamPlayer.Add(new TeamPlayersViewModel
                {
                    PlayerName = this.playerRepository.All().FirstOrDefault(x => x.Id == teamPlayer.PlayerId).Name,
                    PlayerId = teamPlayer.PlayerId,
                    TeamName = team.Name,
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
                Image = team.Image,
            };

            return viewTeamPage;
        }

        /// <inheritdoc />
        public async Task<string> GetTeamNameById(int teamId)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);

            return team.Name;
        }

        /// <inheritdoc />
        public async Task<int> GetTeamIdByUserId(string userId)
        {
            var team = await this.teamRepository.All().Select(x => new { x.Id, x.Name, x.UserId }).FirstOrDefaultAsync(x => x.UserId == userId);

            return team.Id;
        }

        /// <inheritdoc />
        public async Task<int> GetTeamPlayerTeamIdByUserId(string userId)
        {
            var team = await this.teamPlayerRepository.All().Select(x => new { x.TeamId, x.Team.Name, x.Player.UserId }).FirstOrDefaultAsync(x => x.UserId == userId);

            return team.TeamId;
        }

        /// <inheritdoc />
        public bool IsUserHaveTeam(string userId)
        {
            return this.teamRepository.All().Any(x => x.UserId == userId);
        }

        /// <inheritdoc />
        public async Task<bool> IsPlayerAlreadyApplyToTeam(string userId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            return this.teamPlayerRepository.All().Any(x => x.PlayerId == player.Id);
        }

        /// <inheritdoc />
        public async Task LeaveGroup(string userId, int teamId)
        {
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var teamPlayer = await this.teamPlayerRepository.All().FirstOrDefaultAsync(x => x.TeamId == teamId && x.PlayerId == player.Id);
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Id == teamId);

            team.Rank -= await this.CalculateRank(player.Id);

            this.teamPlayerRepository.HardDelete(teamPlayer);
            await this.teamPlayerRepository.SaveChangesAsync();

            this.teamRepository.Update(team);
            await this.teamRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task Abandon(int teamId, string imagePath)
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

            File.Delete(imagePath);

            this.teamRepository.HardDelete(team);

            await this.teamRepository.SaveChangesAsync();

            await this.teamPlayerRepository.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task RemoveImage(string imagePath)
        {
            File.Delete(imagePath);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetTeamRankingList<T>(int page, int itemsPetPage = 6)
        {
            return await this.teamRepository
                .AllAsNoTracking()
                .OrderByDescending(x => x.Rank)
                .Skip((page - 1) * itemsPetPage)
                .Take(itemsPetPage)
                .To<T>()
                .ToListAsync();

            // 1-6 - page 1  Skip 0
            // 7-12 - page 2  sKIP 6
            // 13- 18 - page 3 SKIP 12
        }

        /// <inheritdoc />
        public async Task<int> GetTeamCount()
        {
            return await this.teamRepository.All().CountAsync();
        }

        /// <inheritdoc />
        public async Task<Team> SearchTeamByName(string name)
        {
            var team = await this.teamRepository.All().FirstOrDefaultAsync(x => x.Name == name);

            return team;
        }

        /// <summary>
        /// Use this method to calculate the rank of team.That come from all player from a team.
        /// </summary>
        /// <param name="playerId">A string representing player Id.</param>
        /// <returns>A integer representing the rank.</returns>
        public async Task<int> CalculateRank(string playerId)
        {
            var sumSkills = await this.playerSkillsRepository.All().Where(x => x.PlayerId == playerId).SumAsync(x => x.Points);

            return sumSkills;
        }
    }
}
