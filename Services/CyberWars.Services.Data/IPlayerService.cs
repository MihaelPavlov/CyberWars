namespace CyberWars.Services.Data
{
    using System.Threading.Tasks;

    public interface IPlayerService
    {
        /// <summary>
        /// Use this method to create player.
        /// </summary>
        /// <param name="id">A string representing the Id.</param>
        /// <param name="typeClass">A string representing the type class player choose.</param>
        /// <param name="imageName">A string representing the name of image.</param>
        public Task CreatePlayer(string id, string typeClass, string imageName);

        /// <summary>
        /// Use this method to create skills for new player.
        /// </summary>
        /// <param name="id">A string representing the Id.</param>
        public Task CreateSkills(string id);

        /// <summary>
        /// Use this method to create abilities for new player.
        /// </summary>
        /// <param name="id">A string representing the Id.</param>
        public Task CreatePlayerAbilities(string id);

        /// <summary>
        /// Use this method to create battle record for new player.
        /// </summary>
        /// <param name="id">A string representing the Id.</param>
        public Task CreateBattleRecord(string id);
    }
}
