namespace CyberWars.Services.Data.DarkWeb
{
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.Battle;
    using CyberWars.Web.ViewModels.HomeViews;

    /// <summary>
    /// Defines an interface for a service that will handle operations related to DarkWeb.
    /// </summary>
    public interface IDarkWebService
    {
        /// <summary>
        /// Use this method to find enemy that is near to your score.
        /// </summary>
        /// <param name="userId">A string that contains currently user Id.</param>
        /// <param name="typeFight">A string that contains the type of enemy you want. Normal, Stronger then me, And search by name.</param>
        /// <returns>A view model of player<see cref="PlayerDataView"/>.</returns>
        public Task<PlayerDataView> FindNormalEnemy(string userId, string typeFight);

        /// <summary>
        /// Use this method to find enemy that is stronger then you.
        /// </summary>
        /// <param name="userId">A string that contains currently user Id.</param>
        /// <param name="typeFight">A string that contains the type of enemy you want. Normal, Stronger then me, And search by name.</param>
        /// <returns>A view model of player<see cref="PlayerDataView"/>.</returns>
        public Task<PlayerDataView> FindStrongerEnemy(string userId, string typeFight);

        /// <summary>
        /// Use this method to find enemy by name.
        /// </summary>
        /// <param name="userId">A string that contains currently user Id.</param>
        /// <param name="searchName">A string that contains the enemey name.</param>
        /// <param name="typeFight">A string that contains the type of enemy you want. Normal, Stronger then me, And search by name.</param>
        /// <returns>A view model of player<see cref="PlayerDataView"/>.</returns>
        public Task<PlayerDataView> FindEnemyByName(string userId, string searchName, string typeFight);

        /// <summary>
        /// Use this method to get result from fight.
        /// </summary>
        /// <param name="userId">A string that contains currently user Id.</param>
        /// <param name="defencePlayerId">A string that contains defence player Id.</param>
        /// <returns>A view model <see cref="BattleRewardViewModel"/></returns>
        public Task<BattleRewardViewModel> ResultFromBattle(string userId, string defencePlayerId);
    }
}
