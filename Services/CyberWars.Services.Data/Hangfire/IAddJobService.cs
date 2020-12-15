namespace CyberWars.Services.Data.Hangfire
{
    using System.Threading.Tasks;

    public interface IAddJobService
    {
        public Task UpdateRandomJobs();
    }
}
