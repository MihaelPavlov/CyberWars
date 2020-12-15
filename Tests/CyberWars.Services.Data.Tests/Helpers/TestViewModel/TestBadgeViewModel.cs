namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel
{
    using System.Collections.Generic;

    using CyberWars.Data.Models.Badge;
    using CyberWars.Services.Mapping;

    public class TestBadgeViewModel : IMapFrom<Badge>
    {
        public TestBadgeViewModel()
        {
            this.BadgeRequirements = new HashSet<TestBagdeRequirementsViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BadgeTypeId { get; set; }

        public string BadgeTypeName { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TestBagdeRequirementsViewModel> BadgeRequirements { get; set; }
    }
}
