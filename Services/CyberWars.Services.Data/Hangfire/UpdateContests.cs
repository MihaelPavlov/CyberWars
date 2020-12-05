namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.CompetitiveCoding;
    using Microsoft.EntityFrameworkCore;

    public class UpdateContests
    {
        private readonly IDeletableEntityRepository<Contest> contestReposiotry;
        private readonly IDeletableEntityRepository<RandomHangfireContest> hangfireContestReposiotry;

        public UpdateContests(IDeletableEntityRepository<Contest> contestReposiotry, IDeletableEntityRepository<RandomHangfireContest> hangfireContestReposiotry)
        {
            this.contestReposiotry = contestReposiotry;
            this.hangfireContestReposiotry = hangfireContestReposiotry;
        }

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
