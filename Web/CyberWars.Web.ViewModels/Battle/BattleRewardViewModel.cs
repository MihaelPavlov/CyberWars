namespace CyberWars.Web.ViewModels.Battle
{
    using System;

    public class BattleRewardViewModel
    {
        public string AttackPlayerName { get; set; }

        public string DefencePlayerName { get; set; }

        public string WinnerPlayerName { get; set; }

        public int RewardMoney { get; set; }

        public int RewardExp { get; set; }

        public DateTime BattleDate { get; set; }
    }
}
