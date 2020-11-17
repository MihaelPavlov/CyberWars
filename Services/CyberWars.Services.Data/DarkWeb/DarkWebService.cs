namespace CyberWars.Services.Data.DarkWeb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.EntityFrameworkCore;

    public class DarkWebService : IDarkWebService
    {
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillRepository;


        public DarkWebService(IDeletableEntityRepository<Player> playerRepository
            , IDeletableEntityRepository<PlayerAbility> playerAbilityRepository
            , IDeletableEntityRepository<PlayerSkill> playerSkillRepository)
        {
            this.playerRepository = playerRepository;
            this.playerAbilityRepository = playerAbilityRepository;
            this.playerSkillRepository = playerSkillRepository;
        }

        public async Task<PlayerDataView> FindNormalEnemy(string type, string userId)
        {

            var attackPlayer = await this.playerRepository.All().Where(x => x.UserId == userId).To<PlayerDataView>().FirstAsync();
            var players = await this.playerRepository.All().Where(x => x.UserId != userId).To<PlayerDataView>().ToListAsync();

            Dictionary<string, int> playerWithStats = new Dictionary<string, int>();

            foreach (var player in players)
            {
                int statsSum = await this.SumStats(player);
                playerWithStats.Add(player.Id, statsSum);
            }
            var attackPlayerStats = await this.SumStats(attackPlayer);
            playerWithStats.Where(x => x.Value < attackPlayerStats);
            var random = new Random().Next(0, playerWithStats.Count);




            var defencePlayer = await this.playerRepository.All().To<PlayerDataView>().FirstAsync(x => x.Id == playerWithStats.ElementAt(random).Key);
            return defencePlayer;
            //var attackPlayer = await this.playerRepository.All().Where(x => x.UserId == userId).To<PlayerDataView>().FirstAsync();

            //var allPlayers = await this.playerRepository.All().To<PlayerDataView>().ToListAsync();
            //var random = new Random().Next(allPlayers.Count);
            //var defencePlayer = await this.playerRepository.All().Take(1).To<PlayerDataView>().FirstAsync();

            //for (int i = 0; i < allPlayers.Count; i++)
            //{
            //    if (i == random)
            //    {
            //        defencePlayer = allPlayers[i];

            //        if (defencePlayer.Id != attackPlayer.Id)
            //        {
            //            break;
            //        }
            //    }
            //}

            //var attackPlayerStats = this.SumStats(attackPlayer);
            //var defencePlayerStats = this.SumStats(defencePlayer);

            //return defencePlayer;
        }

        public async Task<int> SumStats(PlayerDataView player)
        {
            var playerSkills = await this.playerSkillRepository.All().Where(x => x.PlayerId == player.Id).ToListAsync();
            var playerAbilties = await this.playerAbilityRepository.All().Where(x => x.PlayerId == player.Id).ToListAsync();

            var sumSkills = 0;
            var sumAbilities = 0;
            foreach (var skill in playerSkills)
            {
                sumSkills += skill.Points;
            }

            foreach (var ability in playerAbilties)
            {
                sumAbilities += ability.Points;
            }

            return sumAbilities + sumSkills;
        }
    }
}
