namespace CyberWars.Web.ViewModels.Academy
{
    using CyberWars.Data.Models.Course;
    using CyberWars.Services.Mapping;

    public class LanguageViewModel : IMapFrom<Course>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LevelToUnlock { get; set; }

        public int PlayerLevel { get; set; }

        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }
    }
}
