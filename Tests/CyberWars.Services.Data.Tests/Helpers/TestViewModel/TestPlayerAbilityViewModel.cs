namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Ability;
    using CyberWars.Services.Mapping;

    public class TestPlayerAbilityViewModel : IMapFrom<PlayerAbility>
    {
        public string PlayerId { get; set; }

        public int AbilityId { get; set; }

        public string AbilityName { get; set; }

        public string AbilityDescription { get; set; }

        public string AbilityType { get; set; }

        public string AbilityImageName { get; set; }

        public int Points { get; set; }
    }

}
