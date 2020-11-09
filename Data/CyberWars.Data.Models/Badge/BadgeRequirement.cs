namespace CyberWars.Data.Models.Badge
{
    public class BadgeRequirement
    {
        public int BadgeId { get; set; }

        public Badge Badge { get; set; }

        public int RequirementId { get; set; }

        public Requirement Requirement { get; set; }
    }
}
