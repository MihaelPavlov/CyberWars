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
        public Task<PlayerDataView> FindNormalEnemy(string userId);

        public Task<PlayerDataView> FindStrongerEnemy(string userId);

        public Task<PlayerDataView> FindEnemyByName(string userId, string searchName);

        public Task<BattleRewardViewModel> ResultFromBattle(string userId, string defencePlayerId);
    }
}
