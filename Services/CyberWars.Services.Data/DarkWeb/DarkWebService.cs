namespace CyberWars.Services.Data.DarkWeb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.Battle;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.EntityFrameworkCore;

    public class DarkWebService : IDarkWebService
    {
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillRepository;
        private readonly IDeletableEntityRepository<Battle> battleRepository;
        private readonly IDeletableEntityRepository<PlayerBattle> playerBattleRepository;
        private readonly IDeletableEntityRepository<BattleRecord> battleRecordRepository;


        public DarkWebService(IDeletableEntityRepository<Player> playerRepository
            , IDeletableEntityRepository<PlayerAbility> playerAbilityRepository
            , IDeletableEntityRepository<PlayerSkill> playerSkillRepository
            , IDeletableEntityRepository<Battle> battleRepository
            , IDeletableEntityRepository<PlayerBattle> playerBattleRepository
            , IDeletableEntityRepository<BattleRecord> battleRecordRepository)
        {
            this.playerRepository = playerRepository;
            this.playerAbilityRepository = playerAbilityRepository;
            this.playerSkillRepository = playerSkillRepository;
            this.battleRepository = battleRepository;
            this.playerBattleRepository = playerBattleRepository;
            this.battleRecordRepository = battleRecordRepository;
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
        }

        public async Task<PlayerDataView> FindStrongerEnemy(string type, string userId)
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
            playerWithStats.Where(x => x.Value > attackPlayerStats);
            var random = new Random().Next(0, playerWithStats.Count);

            var defencePlayer = await this.playerRepository.All().To<PlayerDataView>().FirstAsync(x => x.Id == playerWithStats.ElementAt(random).Key);
            return defencePlayer;
        }

        public async Task<PlayerDataView> FindEnemyByName(string type, string userId, string searchName)
        {
            var attackPlayer = await this.playerRepository.All().Where(x => x.UserId == userId).To<PlayerDataView>().FirstAsync();
            var defencePlayer = await this.playerRepository.All().To<PlayerDataView>().FirstOrDefaultAsync(x => x.Name == searchName);

            return defencePlayer;
        }

        public async Task<BattleRewardViewModel> ResultFromBattle(string userId, string defencePlayerId)
        {
            var attackPlayer = await this.playerRepository.All().Where(x => x.UserId == userId).To<PlayerDataView>().FirstAsync();
            var defencePlayer = await this.playerRepository.All().To<PlayerDataView>().FirstOrDefaultAsync(x => x.Id == defencePlayerId);

            var attackPlayerStats = await this.SumStats(attackPlayer);
            var defencePlayerStats = await this.SumStats(defencePlayer);

            var winner = new PlayerDataView();

            var battle = new Battle
            {
                AttackPlayerId = attackPlayer.Id,
                DefencePlayerId = defencePlayer.Id,
                BattleDate = DateTime.UtcNow,
            };


            if (attackPlayerStats > defencePlayerStats)
            {
                var battleRecordAttackPlayer = await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.PlayerId == attackPlayer.Id);
                var battleRecordDefencePlayer = await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.PlayerId == defencePlayer.Id);

                //var attackP = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);
                //var defenceP = await this.playerRepository.All().FirstOrDefaultAsync(x => x.Id == defencePlayerId);

                var playerBattle = new PlayerBattle
                {
                    PlayerId = attackPlayer.Id,
                    BattleId = battle.Id,
                };

                battleRecordAttackPlayer.Wins++;
                battleRecordDefencePlayer.Losses++;
                winner = attackPlayer;
                this.battleRecordRepository.Update(battleRecordAttackPlayer);
                this.battleRecordRepository.Update(battleRecordDefencePlayer);
                await this.playerBattleRepository.AddAsync(playerBattle);
            }
            else
            {
                var battleRecordAttackPlayer = await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.PlayerId == attackPlayer.Id);

                var battleRecordDefencePlayer = await this.battleRecordRepository.All().FirstOrDefaultAsync(x => x.PlayerId == defencePlayer.Id);

                var playerBattle = new PlayerBattle
                {
                    PlayerId = defencePlayer.Id,
                    BattleId = battle.Id,
                };

                battleRecordDefencePlayer.Wins++;
                battleRecordAttackPlayer.Losses++;
                winner = defencePlayer;
                this.battleRecordRepository.Update(battleRecordDefencePlayer);
                this.battleRecordRepository.Update(battleRecordAttackPlayer);
                await this.playerBattleRepository.AddAsync(playerBattle);
            }

            var battleReward = new BattleRewardViewModel
            {
                AttackPlayerName = attackPlayer.Name,
                DefencePlayerName = defencePlayer.Name,
                RewardMoney = 50,
                RewardExp = 4,
                WinnerPlayerName = winner.Name,
                BattleDate = battle.BattleDate,
            };

            // Winner Update
            var winnerPlayer = await this.playerRepository.All().FirstOrDefaultAsync(x => x.Id == winner.Id);
            winnerPlayer.Money += battleReward.RewardMoney;
            winnerPlayer.Experience += battleReward.RewardExp;

            this.playerRepository.Update(winnerPlayer);

            // Get Energy From AttackPlayer
            var attackPlayerGetEnergy = await this.playerRepository.All().FirstOrDefaultAsync(x => x.UserId == userId);

            attackPlayerGetEnergy.Energy -= 4;
            attackPlayerGetEnergy.Health -= defencePlayerStats;

            this.playerRepository.Update(attackPlayerGetEnergy);

            // Save Repositories

            // Save BattleRepo.
            await this.battleRepository.AddAsync(battle);
            await this.battleRepository.SaveChangesAsync();

            // Save PlayerBattleRepo
            await this.playerBattleRepository.SaveChangesAsync();

            // Save BattleRecordRepo.
            await this.battleRecordRepository.SaveChangesAsync();

            // Sava PlayerRepo.
            await this.playerRepository.SaveChangesAsync();
            return battleReward;
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
