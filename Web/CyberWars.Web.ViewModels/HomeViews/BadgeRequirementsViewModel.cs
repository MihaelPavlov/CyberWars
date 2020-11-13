namespace CyberWars.Web.ViewModels.HomeViews
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Badge;
    using CyberWars.Services.Mapping;

    public class BadgeRequirementsViewModel : IMapFrom<BadgeRequirement>
    {
        public int BadgeId { get; set; }

        public Badge Badge { get; set; }

        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }
    }
}
