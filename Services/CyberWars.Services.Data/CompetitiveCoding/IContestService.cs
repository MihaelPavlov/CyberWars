namespace CyberWars.Services.Data.CompetitiveCoding
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContestService
    {
        public Task<IEnumerable<T>> GetContests<T>();

        public Task<T> ResultFromContestById<T>(int contestId , string userId);
    }
}
