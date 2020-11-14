namespace CyberWars.Data.Seeding.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Player;

    public class LevelSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Levels.Any())
            {
                return;
            }

            //21

            // 20
            dbContext.Levels.Add(new Level
            {
                LevelName = 20,
                Exp = 4470,
                ExpDifference = 497,
            });
            // 19
            dbContext.Levels.Add(new Level
            {
                LevelName = 19,
                Exp = 3973,
                ExpDifference = 450,
            });

            // 18
            dbContext.Levels.Add(new Level
            {
                LevelName = 18,
                Exp = 3523,
                ExpDifference = 408,
            });

            // 17
            dbContext.Levels.Add(new Level
            {
                LevelName = 17,
                Exp = 3115,
                ExpDifference = 369,
            });

            // 16
            dbContext.Levels.Add(new Level
            {
                LevelName = 16,
                Exp = 2746,
                ExpDifference = 335,
            });

            // 15
            dbContext.Levels.Add(new Level
            {
                LevelName = 15,
                Exp = 2411,
                ExpDifference = 304,
            });

            // 14
            dbContext.Levels.Add(new Level
            {
                LevelName = 14,
                Exp = 2107,
                ExpDifference = 274,
            });

            // 13
            dbContext.Levels.Add(new Level
            {
                LevelName = 13,
                Exp = 1833,
                ExpDifference = 249,
            });

            // 12
            dbContext.Levels.Add(new Level
            {
                LevelName = 12,
                Exp = 1584,
                ExpDifference = 226,
            });

            // 11
            dbContext.Levels.Add(new Level
            {
                LevelName = 11,
                Exp = 1358,
                ExpDifference = 204,
            });

            // 10
            dbContext.Levels.Add(new Level
            {
                LevelName = 10,
                Exp = 1154,
                ExpDifference = 185,
            });

            // 9
            dbContext.Levels.Add(new Level
            {
                LevelName = 9,
                Exp = 969,
                ExpDifference = 168,
            });

            // 8
            dbContext.Levels.Add(new Level
            {
                LevelName = 8,
                Exp = 801,
                ExpDifference = 151,
            });

            // 7
            dbContext.Levels.Add(new Level
            {
                LevelName = 7,
                Exp = 650,
                ExpDifference = 138,
            });

            // 6
            dbContext.Levels.Add(new Level
            {
                LevelName = 6,
                Exp = 510,
                ExpDifference = 124,
            });

            // 5
            dbContext.Levels.Add(new Level
            {
                LevelName = 5,
                Exp = 388,
                ExpDifference = 112,
            });

            // 4
            dbContext.Levels.Add(new Level
            {
                LevelName = 4,
                Exp = 276,
                ExpDifference = 102,
            });

            // 3
            dbContext.Levels.Add(new Level
            {
                LevelName = 3,
                Exp = 174,
                ExpDifference = 91,
            });

            // 2
            dbContext.Levels.Add(new Level
            {
                LevelName = 2,
                Exp = 83,
                ExpDifference = 83,
            });

            // 1
            dbContext.Levels.Add(new Level
            {
                LevelName = 1,
                Exp = 0,
                ExpDifference = 0,
            });

            dbContext.SaveChanges();
        }
    }
}
