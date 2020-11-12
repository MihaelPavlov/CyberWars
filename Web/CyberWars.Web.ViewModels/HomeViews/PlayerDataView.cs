namespace CyberWars.Web.ViewModels.HomeViews
{
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
    using CyberWars.Web.ViewModels.HomeViews.Pet;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class PlayerDataView : IMapFrom<Player>
    {
        public string UserId { get; set; }

        public string PlayerId { get; set; }

        public int Experience { get; set; }

        public string Class { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int Health { get; set; }

        public int Energy { get; set; }

        public int Money { get; set; }

        public int LearnPoint { get; set; }

        public int Level { get; set; }

        public ICollection<Level> Levels { get; set; }
        public BattleRecord BattleRecord { get; set; }

        public virtual ICollection<PlayerAbility> PlayerAbilities { get; set; }

        public virtual ICollection<PlayerSkill> PlayerSkills { get; set; }

        public virtual ICollection<PlayerPet> PlayerPets { get; set; }

        public virtual ICollection<PlayerBadge> PlayerBadges { get; set; }

        public virtual ICollection<CompleteLecture> CompleteLectures { get; set; }

        public virtual ICollection<PlayerCourse> PlayerCourses { get; set; }

        public virtual ICollection<PlayerJob> PlayerJobs { get; set; }

        public virtual ICollection<PlayerBattle> PlayerBattles { get; set; }

        public virtual ICollection<Battle> AttacksPlayer { get; set; }

        public virtual ICollection<Battle> DefencesPlayer { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}
