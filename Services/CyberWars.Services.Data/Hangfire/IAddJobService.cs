namespace CyberWars.Services.Data.Hangfire
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines an interface for a service that will handle hangfire operations.
    /// </summary>
    public interface IAddJobService
    {
        /// <summary>
        /// Use this method to update jobs.
        /// </summary>
        public Task UpdateRandomJobs();
    }
}
