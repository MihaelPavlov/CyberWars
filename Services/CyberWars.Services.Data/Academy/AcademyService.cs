namespace CyberWars.Services.Data.Academy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class AcademyService : IAcademyService
    {
        private readonly IDeletableEntityRepository<Course> courseRepository;
        private readonly IDeletableEntityRepository<Lecture> lectureRepository;

        public AcademyService(IDeletableEntityRepository<Course> courseRepository
            , IDeletableEntityRepository<Lecture> lectureRepository)
        {
            this.courseRepository = courseRepository;
            this.lectureRepository = lectureRepository;
        }

        public async Task<IEnumerable<T>> GetLecturesByName<T>(string courseName)
        {
            return await this.lectureRepository.All().Where(x => x.Course.Name == courseName).To<T>().ToListAsync();
        }
    }
}
