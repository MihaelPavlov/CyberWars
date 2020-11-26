namespace CyberWars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Battle;
    using System.Security.Claims;

    public class PlayerService : IPlayerService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<Skill> skillsRepository;
        private readonly IDeletableEntityRepository<PlayerSkill> playerSkillRepository;
        private readonly IDeletableEntityRepository<Ability> abilityRepository;
        private readonly IDeletableEntityRepository<PlayerAbility> playerAbilityRepository;
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<BattleRecord> battleRecordRepository;

        public PlayerService(IDeletableEntityRepository<ApplicationUser> userRepository
            , IDeletableEntityRepository<Player> playerRepository
            , IDeletableEntityRepository<Skill> skillsRepository
            , IDeletableEntityRepository<PlayerSkill> playerSkillRepository
            , IDeletableEntityRepository<Ability> abilityRepository
            , IDeletableEntityRepository<PlayerAbility> playerAbilityRepository
            , IDeletableEntityRepository<Food> foodRepository
            , IDeletableEntityRepository<BattleRecord> battleRecordRepository)
        {
            this.playerRepository = playerRepository;
            this.userRepository = userRepository;
            this.skillsRepository = skillsRepository;
            this.playerSkillRepository = playerSkillRepository;
            this.abilityRepository = abilityRepository;
            this.playerAbilityRepository = playerAbilityRepository;
            this.foodRepository = foodRepository;
            this.battleRecordRepository = battleRecordRepository;
        }

        public async Task CreatePlayer(string id, string typeClass, string imageName)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            var player = new Player()
            {
                UserId = user.Id,
                Class = typeClass,
                ImageName = imageName,
                Name = user.UserName,
            };
            user.PlayerId = player.Id;
            await this.playerRepository.AddAsync(player);
            await this.userRepository.SaveChangesAsync();
            await this.playerRepository.SaveChangesAsync();
        }

        public async Task CreateSkills(string id)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            var skills = await this.skillsRepository.All().ToListAsync();

            foreach (var skill in skills)
            {
                var playerSkill = new PlayerSkill()
                {
                    PlayerId = user.PlayerId,
                    Points = 0,
                    SkillId = skill.Id,
                    Money = skill.StartMoney,
                };

                await this.playerSkillRepository.AddAsync(playerSkill);
            }

            await this.playerSkillRepository.SaveChangesAsync();
        }

        public async Task CreatePlayerAbilities(string id)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            var abilities = await this.abilityRepository.All().ToListAsync();

            foreach (var ability in abilities)
            {
                var playerAbility = new PlayerAbility
                {
                    PlayerId = user.PlayerId,
                    Points = 0,
                    AbilityId = ability.Id,
                };
                await this.playerAbilityRepository.AddAsync(playerAbility);
            }

            await this.playerAbilityRepository.SaveChangesAsync();
        }

        public async Task CreateBattleRecord(string id)
        {
            var user = await this.userRepository.All().FirstOrDefaultAsync(x => x.Id == id);

            var battleRecords = await this.battleRecordRepository.All().ToListAsync();
            var battleRecord = new BattleRecord
            {
                PlayerId = user.PlayerId,
                Wins = 0,
                Losses = 0,
                StealPerBattle = 50,
            };

            await this.battleRecordRepository.AddAsync(battleRecord);

            await this.battleRecordRepository.SaveChangesAsync();
        }
    }
}
