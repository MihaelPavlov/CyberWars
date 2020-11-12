namespace CyberWars.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models;
    using CyberWars.Data.Models.Ability;
    using CyberWars.Data.Models.Badge;
    using CyberWars.Data.Models.Battle;
    using CyberWars.Data.Models.Course;
    using CyberWars.Data.Models.Job;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }


        public DbSet<LoginHistory> LoginHistories { get; set; }

        // Players
        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerSkill> PlayerSkills { get; set; }

        public DbSet<PlayerAbility> PlayerAbilities { get; set; }

        public DbSet<PlayerPet> PlayerPets { get; set; }

        public DbSet<PlayerBadge> PlayerBadges { get; set; }

        public DbSet<PlayerJob> PlayerJobs { get; set; }

        // Battles
        public DbSet<BattleRecord> BattleRecords { get; set; }

        public DbSet<Battle> Battles { get; set; }

        public DbSet<PlayerBattle> PlayerBattles { get; set; }

        // Jobs
        public DbSet<JobType> JobTypes { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobRequirement> JobRequirements { get; set; }

        // Skills
        public DbSet<Skill> Skills { get; set; }

        // Abilities
        public DbSet<Ability> Abilities { get; set; }

        public DbSet<AbilityType> AbilityTypes { get; set; }

        // Foods
        public DbSet<Food> Foods { get; set; }

        // Levels
        public DbSet<Level> Levels { get; set; }

        // Pets
        public DbSet<Pet> Pets { get; set; }

        // Badges
        public DbSet<Badge> Badges { get; set; }

        public DbSet<BadgeType> BadgeTypes { get; set; }

        public DbSet<Requirement> Requirements { get; set; }

        public DbSet<BadgeRequirement> BadgeRequirements { get; set; }

        // Course
        public DbSet<CourseType> CourseTypes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CompleteLecture> CompleteLectures { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<PlayerCourse> PlayerCourses { get; set; }

        // Team
        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<PlayerBattle>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.BattleId });
            });

            builder.Entity<Battle>(entity =>
            {
                entity.HasOne(x => x.AttackPlayer)
                 .WithMany(x => x.AttacksPlayer)
                 .HasForeignKey(x => x.AttackPlayerId)
                 .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.DefencePlayer)
              .WithMany(x => x.DefencesPlayer)
              .HasForeignKey(x => x.DefencePlayerId)
              .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<PlayerAbility>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.AbilityId });
            });
            builder.Entity<PlayerJob>(entity =>
            {
                entity.HasKey(x => new { x.JobId, x.PlayerId });
            });

            builder.Entity<JobRequirement>(entity =>
            {
                entity.HasKey(x => new { x.JobId, x.RequirementId });
            });

            builder.Entity<CompleteLecture>(entity =>
            {
                entity.HasKey(x => new { x.LectureId, x.PlayerId });
            });

            builder.Entity<PlayerCourse>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.CourseId });
            });

            builder.Entity<BadgeRequirement>(entity =>
            {
                entity.HasKey(x => new { x.BadgeId, x.RequirementId });
            });

            builder.Entity<PlayerBadge>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.BadgeId });
            });

            builder.Entity<PlayerSkill>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.SkillId });
            });

            builder.Entity<PlayerPet>(entity =>
            {
                entity.HasKey(x => new { x.PetId, x.PlayerId });
            });

            builder.Entity<BattleRecord>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.Id });
            });
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
