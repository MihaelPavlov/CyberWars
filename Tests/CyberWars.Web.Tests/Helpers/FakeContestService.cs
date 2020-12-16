namespace CyberWars.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.CompetitiveCoding;
    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;

    public class FakeContestService : IContestService
    {
        public async Task<IEnumerable<T>> GetContests<T>()
        {
            var result = new List<ContestViewModel>
            {
               new ContestViewModel{ ContestId=1,},
               new ContestViewModel{ ContestId=1, },
               new ContestViewModel{ ContestId=1,},
            };

            return (IEnumerable<T>)await Task.FromResult(result);
        }

        public async Task<ResultContestViewModel> ResultFromContestById(int contestId, string userId)
        {
            var result = new ResultContestViewModel
            {
                ContestId = 1,
            };
            return await Task.FromResult(result);
        }
    }
}
