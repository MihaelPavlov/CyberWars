using CyberWars.Data.Common.Models;
using System;
using System.Data.Common;

namespace CyberWars.Data.Models.Badge
{
    public class BadgeRequirement : IDeletableEntity
    {
        public virtual int BadgeId { get; set; }

        public Badge Badge { get; set; }

        public virtual int RequirementId { get; set; }

        public Requirement Requirement { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
