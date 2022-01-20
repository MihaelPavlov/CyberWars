namespace CyberWars.Services.Data.CompetitiveCoding
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.WebViews.CompetitiveCoding;

    /// <summary>
    /// Defines an interface for a service that will handle operations related to competitiveCoding.
    /// </summary>
    public interface IContestService
    {
        /// <summary>
        /// Use this method to get collection of four contests/challenges.
        /// </summary>
        /// <typeparam name="T">A type that can be <see cref="ContestViewModel"/>.</typeparam>
        /// <returns>A collection with contests.</returns>
        public Task<IEnumerable<T>> GetContests<T>();

        /// <summary>
        /// Use this method to complete and get the result and reward from contest.
        /// </summary>
        /// <param name="contestId">The completed contest Id.</param>
        /// <param name="userId">A string that contains the current user Id.</param>
        /// <returns>A view model <see cref="ResultContestViewModel"/>.</returns>
        public Task<ResultContestViewModel> ResultFromContestById(int contestId, string userId);
    }
}
