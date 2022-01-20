namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.CompetitiveCoding;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Use this class to update contests on every n hour.
    /// </summary>
    public class UpdateContests
    {
        private readonly IDeletableEntityRepository<Contest> contestReposiotry;
        private readonly IDeletableEntityRepository<RandomHangfireContest> hangfireContestReposiotry;

        /// <summary>
        /// Constructor that instantiates UpdateContests.
        /// </summary>
        public UpdateContests(IDeletableEntityRepository<Contest> contestReposiotry, IDeletableEntityRepository<RandomHangfireContest> hangfireContestReposiotry)
        {
            this.contestReposiotry = contestReposiotry ?? throw new ArgumentNullException(nameof(contestReposiotry));
            this.hangfireContestReposiotry = hangfireContestReposiotry ?? throw new ArgumentNullException(nameof(hangfireContestReposiotry));
        }

        /// <summary>
        /// Use this method to change every n hours the contests.
        /// </summary>
        public async Task UpdateRandomContests()
        {
            var randomContests = await this.contestReposiotry.All().ToListAsync();

            while (randomContests.Count() != 4)
            {
                int index = new Random().Next(0, randomContests.Count());
                randomContests.RemoveAt(index);
            }

            var hangfireContests = await this.hangfireContestReposiotry.All().ToListAsync();

            foreach (var hangfireContest in hangfireContests)
            {
                this.hangfireContestReposiotry.Delete(hangfireContest);
            }

            foreach (var contest in randomContests)
            {
                await this.hangfireContestReposiotry.AddAsync(new RandomHangfireContest
                {
                    Contest = contest,
                    ContestId = contest.Id,
                });
            }

            await this.hangfireContestReposiotry.SaveChangesAsync();
        }
    }
}
