namespace CyberWars.Services.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWebService
    {
        public Task CompleteJob(int jobId, string userId);

        public Task<IEnumerable<T>> GetRandomJobs<T>();
    }
}
