namespace CyberWars.Services.Data.CompetitiveCoding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;

    public interface IContestService
    {
        public Task<IEnumerable<T>> GetContests<T>();

        public Task<T> ResultFromContestById<T>(int contestId , string userId);
    }
}
