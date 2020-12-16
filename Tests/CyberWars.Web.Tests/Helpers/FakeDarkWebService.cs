namespace CyberWars.Web.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.DarkWeb;
    using CyberWars.Web.ViewModels.Battle;
    using CyberWars.Web.ViewModels.HomeViews;

    public class FakeDarkWebService : IDarkWebService
    {
        public async Task<PlayerDataView> FindEnemyByName(string userId, string searchName, string typeFight)
        {
            var result = new PlayerDataView
            {
                Id = "Test",
                UserId = "TestUser",
            };
            return await Task.FromResult(result);

        }

        public async Task<PlayerDataView> FindNormalEnemy(string userId, string typeFight)
        {
            var result = new PlayerDataView
            {
                Id = "Test",
                UserId = "TestUser",
            };
            return await Task.FromResult(result);
        }

        public async Task<PlayerDataView> FindStrongerEnemy(string userId, string typeFight)
        {
            var result = new PlayerDataView
            {
                Id = "Test",
                UserId = "TestUser",
            };
            return await Task.FromResult(result);
        }

        public async Task<BattleRewardViewModel> ResultFromBattle(string userId, string defencePlayerId)
        {
            var result = new BattleRewardViewModel
            {
                AttackPlayerName = "Test",
                DefencePlayerName = "Test",
            };
            return await Task.FromResult(result);
        }
    }
}
