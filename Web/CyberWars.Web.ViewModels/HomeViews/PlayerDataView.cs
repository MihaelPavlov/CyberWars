namespace CyberWars.Web.ViewModels.HomeViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    using AutoMapper;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Job;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Services.Mapping;
    using CyberWars.Web.ViewModels.Battle;
    using CyberWars.Web.ViewModels.HomeViews.Pet;

    public class PlayerDataView : IMapFrom<Player>
    {
        public PlayerDataView()
        {
            this.PlayerFoods = new HashSet<PlayerFoodViewModel>();
            this.PlayerAbilities = new HashSet<PlayerAbilitiesViewModel>();
            this.PlayerSkills = new HashSet<PlayerSkillViewModel>();
        }

        public string UserId { get; set; }

        public string Id { get; set; }

        public int Experience { get; set; }

        public string Class { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int Health { get; set; }

        public int MaxHealth { get; set; }

        public int Energy { get; set; }

        public int MaxEnergy { get; set; }

        public decimal Money { get; set; }

        public int LearnPoint { get; set; }

        public int Level { get; set; }

        public ICollection<Level> Levels { get; set; }

        public BattleRecordViewModel BattleRecord { get; set; }

        public virtual ICollection<PlayerAbilitiesViewModel> PlayerAbilities { get; set; }

        public virtual ICollection<PlayerSkillViewModel> PlayerSkills { get; set; }

        public virtual ICollection<PlayerPet> PlayerPets { get; set; }

        public virtual ICollection<PlayerBadge> PlayerBadges { get; set; }

        public virtual ICollection<CompleteLecture> CompleteLectures { get; set; }

        public virtual ICollection<PlayerCourse> PlayerCourses { get; set; }

        public virtual ICollection<PlayerJob> PlayerJobs { get; set; }

        public virtual ICollection<PlayerBattle> PlayerBattles { get; set; }

        public virtual ICollection<Battle> AttacksPlayer { get; set; }

        public virtual ICollection<Battle> DefencesPlayer { get; set; }

        public virtual IEnumerable<PlayerFoodViewModel> PlayerFoods { get; set; }
    }
}
