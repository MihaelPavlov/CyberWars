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
    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// A custom implementation of <see cref="IContestService"/>.
    /// </summary>
    public class ContestService : IContestService
    {
        private readonly IDeletableEntityRepository<Contest> contestRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerContest> playerContestsRepository;
        private readonly IDeletableEntityRepository<RandomHangfireContest> randomContestRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContestService"/> class.
        /// </summary>
        public ContestService(
            IDeletableEntityRepository<Contest> contestRepository,
            IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<PlayerContest> playerContestsRepository,
            IDeletableEntityRepository<RandomHangfireContest> randomContestRepository)
        {
            this.contestRepository = contestRepository ?? throw new ArgumentNullException(nameof(contestRepository));
            this.playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            this.playerContestsRepository = playerContestsRepository ?? throw new ArgumentNullException(nameof(playerContestsRepository));
            this.randomContestRepository = randomContestRepository ?? throw new ArgumentNullException(nameof(randomContestRepository));
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetContests<T>()
        {
            return await this.randomContestRepository.All().Take(4).To<T>().ToListAsync();
        }

        // TODO: Separate the tasks in Result method. We need separate the complete, show result and reward logic.
        /// <inheritdoc />
        public async Task<ResultContestViewModel> ResultFromContestById(int contestId, string userId)
        {
            var contest = await this.contestRepository.All().FirstOrDefaultAsync(x => x.Id == contestId);
            var playerContest = await this.playerContestsRepository.All().FirstOrDefaultAsync(x => x.Player.UserId == userId && x.ContestId == contestId);
            var player = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            var playerEnergy = player.Energy;
            var contestEnergy = contest.ConsumeEnergy;

            if ((playerEnergy -= contestEnergy) < 0)
            {
                return null;
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

                return await this.playerContestsRepository.All().Where(x => x.ContestId == playerContest.ContestId && playerContest.PlayerId == x.Player.Id).To<ResultContestViewModel>().FirstAsync();
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

                    return await this.playerContestsRepository.All().Where(x => x.ContestId == newPlayerContest.ContestId && newPlayerContest.PlayerId == x.Player.Id).To<ResultContestViewModel>().FirstAsync();
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

                    return await this.playerContestsRepository.All().Where(x => x.ContestId == newPlayerContest.ContestId && newPlayerContest.PlayerId == x.Player.Id).To<ResultContestViewModel>().FirstAsync();
                }
            }
        }

        /// <summary>
        /// Use this method to calculate randomly if the player wins.
        /// </summary>
        /// <param name="percentage">Every contest have a different chanse/percentage to win.</param>
        private static bool IsWin(double percentage)
        {
            var percentNumber = percentage / 100;
            var number = new Random().NextDouble();

            if (number <= percentNumber)
            {
                return true;
            }

            return false;
        }
    }
}
