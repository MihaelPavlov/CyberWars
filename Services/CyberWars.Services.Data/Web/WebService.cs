namespace CyberWars.Services.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Job;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.WebViews.Job;
    using Microsoft.EntityFrameworkCore;

    public class WebService : IWebService
    {
        private readonly IDeletableEntityRepository<Job> jobsReposiotry;
        private readonly IDeletableEntityRepository<RandomHangfireJob> hangfireJobsReposiotry;
        private readonly IDeletableEntityRepository<Player> playerReposiotry;
        private readonly IDeletableEntityRepository<PlayerJob> playerJobReposiotry;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityJobReposiotry;

        public WebService(IDeletableEntityRepository<Job> jobsReposiotry, IDeletableEntityRepository<RandomHangfireJob> hangfireJobsReposiotry
            , IDeletableEntityRepository<Player> playerReposiotry, IDeletableEntityRepository<PlayerJob> playerJobReposiotry, IDeletableEntityRepository<PlayerAbility> playerAbilityJobReposiotry)
        {
            this.jobsReposiotry = jobsReposiotry;
            this.hangfireJobsReposiotry = hangfireJobsReposiotry;
            this.playerReposiotry = playerReposiotry;
            this.playerJobReposiotry = playerJobReposiotry;
            this.playerAbilityJobReposiotry = playerAbilityJobReposiotry;
        }

        public async Task<IEnumerable<T>> GetRandomJobs<T>()
        {

            return await this.hangfireJobsReposiotry.All().Take(15).OrderBy(x => x.Job.JobRequirements.Count).To<T>().ToListAsync();
        }

        public async Task CompleteJob(int jobId, string userId)
        {
            var player = await this.playerReposiotry.All().FirstOrDefaultAsync(x => x.UserId == userId);
            var job = await this.jobsReposiotry.All().FirstOrDefaultAsync(x => x.Id == jobId);

            var playerJobs = await this.playerJobReposiotry.All().Where(x => x.PlayerId == player.Id).ToListAsync();

            if (playerJobs.Any(x => x.JobId == job.Id))
            {
                var playerJob = playerJobs.FirstOrDefault(x => x.JobId == jobId);
                playerJob.TimesComplete++;
                playerJob.LastDatePlayed = DateTime.Today;
                this.playerJobReposiotry.Update(playerJob);
            }
            else
            {
                var playerJob = new PlayerJob
                {
                    Player = player,
                    PlayerId = player.Id,
                    LastDatePlayed = DateTime.Today,
                    Job = job,
                    JobId = job.Id,
                    TimesComplete = 1,
                };
                await this.playerJobReposiotry.AddAsync(playerJob);
            }

            player.Money += job.RewardMoney;
            player.Experience += job.RewardExp;

            var splitAbilityReward = job.RewardAbilityNames.Split(" ").ToArray();

            foreach (var abilityReward in splitAbilityReward)
            {
                var ability = await this.playerAbilityJobReposiotry.All().FirstOrDefaultAsync(x => x.PlayerId == player.Id && x.Ability.Name == $"{abilityReward}");
                ability.Points++;
                this.playerAbilityJobReposiotry.Update(ability);
            }

            this.playerReposiotry.Update(player);

            await this.playerAbilityJobReposiotry.SaveChangesAsync();
            await this.playerJobReposiotry.SaveChangesAsync();
            await this.playerReposiotry.SaveChangesAsync();
        }
    }
}
