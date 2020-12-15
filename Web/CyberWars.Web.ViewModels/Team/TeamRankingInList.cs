namespace CyberWars.Web.ViewModels.Team
{
    using CyberWars.Data.Models.Teams;
    using CyberWars.Services.Mapping;

    public class TeamRankingInList : IMapFrom<Team>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MotivationalMotto { get; set; }

        public int Rank { get; set; }
    }
}
