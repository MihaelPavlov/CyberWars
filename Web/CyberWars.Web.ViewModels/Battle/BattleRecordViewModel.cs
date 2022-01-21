namespace CyberWars.Web.ViewModels.Battle
{
    using CyberWars.Data.Models.Battle;
    using CyberWars.Services.Mapping;

    public class BattleRecordViewModel : IMapFrom<BattleRecord>
    {
        public int Wins { get; set; }

        public int Losses { get; set; }

        public int StolenMoney { get; set; }

        public int StealPerBattle { get; set; }

        public string PlayerId { get; set; }
    }
}
