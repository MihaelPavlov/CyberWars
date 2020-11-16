namespace CyberWars.Data.Models.Player
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Job;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Skills;
    using Microsoft.AspNetCore.Identity;

    public class Player : BaseDeletableModel<string>
    {
        public Player()
        {
            this.Id = Guid.NewGuid().ToString();
            this.PlayerSkills = new HashSet<PlayerSkill>();
            this.PlayerAbilities = new HashSet<PlayerAbility>();
            this.PlayerPets = new HashSet<PlayerPet>();
            this.PlayerBadges = new HashSet<PlayerBadge>();
            this.CompleteLectures = new HashSet<CompleteLecture>();
            this.PlayerCourses = new HashSet<PlayerCourse>();
            this.PlayerJobs = new HashSet<PlayerJob>();
            this.PlayerBattles = new HashSet<PlayerBattle>();
            this.AttacksPlayer = new HashSet<Battle>();
            this.DefencesPlayer = new HashSet<Battle>();
            this.PlayerFoods = new HashSet<PlayerFood>();
            this.Health = 1000;
            this.Energy = 100;
            this.Money = 1000;
            this.Level = 1;
            this.Experience = 0;
            this.LearnPoint = 0;
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Class { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int Health { get; set; }

        public int Energy { get; set; }

        public decimal Money { get; set; }

        public int LearnPoint { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public BattleRecord BattleRecord { get; set; }


        public virtual ICollection<PlayerAbility> PlayerAbilities { get; set; }

        public virtual ICollection<PlayerSkill> PlayerSkills { get; set; }

        public virtual ICollection<PlayerPet> PlayerPets { get; set; }

        public virtual ICollection<PlayerBadge> PlayerBadges { get; set; }

        public virtual ICollection<CompleteLecture> CompleteLectures { get; set; }

        public virtual ICollection<PlayerCourse> PlayerCourses { get; set; }

        public virtual ICollection<PlayerJob> PlayerJobs { get; set; }

        public virtual ICollection<PlayerBattle> PlayerBattles { get; set; }

        public virtual ICollection<PlayerFood> PlayerFoods { get; set; }

        public virtual ICollection<Battle> AttacksPlayer { get; set; }

        public virtual ICollection<Battle> DefencesPlayer { get; set; }
    }
}
