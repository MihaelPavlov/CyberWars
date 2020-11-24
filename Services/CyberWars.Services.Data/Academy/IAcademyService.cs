namespace CyberWars.Services.Data.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAcademyService
    {
        public Task<IEnumerable<T>> GetLecturesByName<T>(string courseName);
    }
}
