namespace CyberWars.Services.Data.DarkWeb
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.Battle;
    using CyberWars.Web.ViewModels.HomeViews;

    public interface IDarkWebService
    {
        public Task<PlayerDataView> FindNormalEnemy(string userId, string typeFight);

        public Task<PlayerDataView> FindStrongerEnemy(string userId, string typeFight);

        public Task<PlayerDataView> FindEnemyByName(string userId, string searchName , string typeFight);

        public Task<BattleRewardViewModel> ResultFromBattle(string userId, string defencePlayerId);
    }
}
