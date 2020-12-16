namespace CyberWars.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;
    using CyberWars.Services.Data.Web;
    using CyberWars.Web.ViewModels.WebViews.Job;

    public class FakeWebService : IWebService
    {
        public async Task CompleteJob(int jobId, string userId)
        {

        }

        public async Task<IEnumerable<PlayerJob>> GetPlayerCompleteJobs(string userId)
        {
            var result = new List<PlayerJob>
            {
                    new PlayerJob{JobId=1,},
                    new PlayerJob{JobId=2,},
                    new PlayerJob{JobId=3,},
            };

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetRandomJobs<T>()
        {
            var result = new List<JobViewModel>
            {
                    new JobViewModel{JobId=1,},
                    new JobViewModel{JobId=1,},
                    new JobViewModel{JobId=1,},
            };

            return (IEnumerable<T>)await Task.FromResult(result);
        }
    }
}
