using CyberWars.Data.Common.Repositories;
using CyberWars.Data.Models;
using CyberWars.Data.Models.Player;
using CyberWars.Data.Models.Skills;
using CyberWars.Services.Mapping;
using CyberWars.Web.ViewModels.HomeViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CyberWars.Services.Data.Home
{
    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillRepository;

        public HomeService(IDeletableEntityRepository<Player> playerRepository, IDeletableEntityRepository<PlayerSkill> playerSkillRepository)
        {
            this.playerRepository = playerRepository;
            this.playerSkillRepository = playerSkillRepository;
        }

        public async Task<T> GetPlayerData<T>(string userId)
        {
            // Get The Player with userId 
            return await this.playerRepository
                .All()
                .Where(x => x.UserId == userId)
                .To<T>()
                .FirstAsync();
            //  return await this.playerRepository.All().FirstOrDefault(x => x.UserId == userId);
        }

        public async Task<IEnumerable<T>> GetPlayerSkills<T>(string userId)
        {
            return await this.playerSkillRepository.All().Where(x => x.Player.UserId == userId).To<T>().ToListAsync();
        }
    }
}
