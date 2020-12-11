namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Mapping;

    public class TestPlayerSkillViewModel : IMapFrom<PlayerSkill>
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int SkillId { get; set; }

        public string SkillName { get; set; }

        public int Points { get; set; }

        public string SkillDescription { get; set; }

        public int SkillStartMoney { get; set; }

        public int Money { get; set; }
    }

}
