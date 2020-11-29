namespace CyberWars.Web.ViewModels.HomeViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CyberWars.Data.Models.Badge;
    using CyberWars.Services.Mapping;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

        public ICollection<BadgeRequirementsViewModel> BadgeRequirements { get; set; }

        public bool IsAllBadgeRequirementsComplete { get; set; }

        // TODO: Property bool IsAllBadgeRequirement are complete  

    }

}
