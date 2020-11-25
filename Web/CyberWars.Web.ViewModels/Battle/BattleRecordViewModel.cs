﻿namespace CyberWars.Web.ViewModels.Battle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Battle;
    using CyberWars.Services.Mapping;

    public class BattleRecordViewModel : IMapFrom<BattleRecord>
    {
        public int Wins { get; set; }

        public int Losses { get; set; }

        public string PlayerId { get; set; }
    }
}
