namespace CyberWars.Services.Data.CompetitiveCoding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.CompetitiveCoding;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ContestService : IContestService
    {
        private readonly IDeletableEntityRepository<Contest> contestRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerContest> playerContestsRepository;
        private readonly IDeletableEntityRepository<RandomHangfireContest> randomContestRepository;

        public ContestService(
            IDeletableEntityRepository<Contest> contestRepository,
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<PlayerContest> playerContestsRepository,
            IDeletableEntityRepository<RandomHangfireContest> randomContestRepository)
        {
            this.contestRepository = contestRepository;
            this.playerRepository = playerRepository;
            this.playerContestsRepository = playerContestsRepository;
            this.randomContestRepository = randomContestRepository;
        }

        public async Task<IEnumerable<T>> GetContests<T>()
        {
            return await this.randomContestRepository.All().Take(4).To<T>().ToListAsync();
        }

        public async Task<T> ResultFromContestById<T>(int contestId, string userId)
        {
            var contest = await this.contestRepository.All().FirstOrDefaultAsync(x => x.Id == contestId);
            var playerContest = await this.playerContestsRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.ContestId == contestId);
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var playerEnergy = player.Energy;
            var contestEnergy = contest.ConsumeEnergy;

            if ((playerEnergy -= contestEnergy) < 0)
            {
                return default(T);
            }

            if (playerContest != null)
            {
                if (IsWin(contest.Percentage))
                {
                    playerContest.IsWin = true;

                    // Give Player Reward
                    player.Money += contest.RewardMoney;
                    player.Experience += contest.RewardExp;
                    player.Energy -= contest.ConsumeEnergy;
                    this.playerRepository.Update(player);
                    await this.playerRepository.SaveChangesAsync();
                }
                else
                {
                    playerContest.IsWin = false;
                    player.Energy -= contest.ConsumeEnergy;
                    this.playerRepository.Update(player);
                    await this.playerRepository.SaveChangesAsync();
                }

                playerContest.TimePlayed++;
                this.playerContestsRepository.Update(playerContest);
                await this.playerContestsRepository.SaveChangesAsync();

                return await this.playerContestsRepository.All().Where(x => x.ContestId == playerContest.ContestId && playerContest.PlayerId == x.Player.Id).To<T>().FirstAsync();
            }
            else
            {
                if (IsWin(contest.Percentage))
                {
                    // save the new Player Contest
                    var newPlayerContest = new PlayerContest
                    {
                        ContestId = contest.Id,
                        PlayerId = player.Id,
                        DateCompleteContext = DateTime.UtcNow,
                        IsWin = true,
                    };

                    await this.playerContestsRepository.AddAsync(newPlayerContest);

                    await this.playerContestsRepository.SaveChangesAsync();

                    // Give Player Reward
                    player.Money += contest.RewardMoney;
                    player.Experience += contest.RewardExp;
                    player.Energy -= contest.ConsumeEnergy;
                    this.playerRepository.Update(player);
                    await this.playerRepository.SaveChangesAsync();

                    return await this.playerContestsRepository.All().Where(x => x.ContestId == newPlayerContest.ContestId && newPlayerContest.PlayerId == x.Player.Id).To<T>().FirstAsync();
                }
                else
                {
                    var newPlayerContest = new PlayerContest
                    {
                        ContestId = contest.Id,
                        PlayerId = player.Id,
                        DateCompleteContext = DateTime.UtcNow,
                        IsWin = false,
                    };
                    await this.playerContestsRepository.AddAsync(newPlayerContest);

                    await this.playerContestsRepository.SaveChangesAsync();

                    player.Energy -= contest.ConsumeEnergy;
                    this.playerRepository.Update(player);
                    await this.playerRepository.SaveChangesAsync();

                    return await this.playerContestsRepository.All().Where(x => x.ContestId == newPlayerContest.ContestId && newPlayerContest.PlayerId == x.Player.Id).To<T>().FirstAsync();
                }
            }
        }

        private static bool IsWin(double percentage)
        {
            var percentNumber = percentage / 100;
            var number = new Random().NextDouble();

            if (number <= percentNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
