using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CyberWars.Services.Data
{
    public interface IPlayerService
    {
        public Task CreatePlayer(string id, string typeClass, string imageName);

        public Task CreateSkills(string id);

        public Task CreatePlayerAbilities(string id);

        public Task CreateBattleRecord(string id);

        //public Task<string> GetUserId(string username, string password);
    }
}
