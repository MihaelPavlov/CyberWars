namespace CyberWars.Services.Data
{
    using System.Threading.Tasks;

    public interface IPlayerService
    {
        public Task CreatePlayer(string id, string typeClass, string imageName);

        public Task CreateSkills(string id);

        public Task CreatePlayerAbilities(string id);

        public Task CreateBattleRecord(string id);
    }
}
