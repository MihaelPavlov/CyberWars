namespace CyberWars.Web.ViewModels.HomeViews
{
    using System.Collections.Generic;

    using CyberWars.Data.Models.Badge;
    using CyberWars.Services.Mapping;

    public class BadgesViewModel : IMapFrom<Badge>
    {
        public BadgesViewModel()
        {
            this.BadgeRequirements = new HashSet<BadgeRequirementsViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BadgeTypeId { get; set; }

        public string BadgeTypeName { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<BadgeRequirementsViewModel> BadgeRequirements { get; set; }

        public bool IsAllBadgeRequirementsComplete { get; set; }
    }
}
