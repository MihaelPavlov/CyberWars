namespace CyberWars.Services.Data.Web
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IWebService
    {
        public Task<IEnumerable<T>> GetRandomJobs<T>();
    }
}
