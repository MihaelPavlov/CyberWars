namespace CyberWars.Data.Seeding.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Job;

    public class JobRequirementSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobRequirements.Any())
            {
                return;
            }

            var requirements = dbContext.Requirements.ToList();

            var jobsLevel1 = dbContext.Jobs.Where(x => x.LevelRequirement == 1).ToList();
            var jobLevel5 = dbContext.Jobs.Where(x => x.LevelRequirement == 5).ToList();
            var jobLevel8 = dbContext.Jobs.Where(x => x.LevelRequirement == 8).ToList();

            // Job Level 8
            var listWithLanguagesLevel8 = new List<string>();
            listWithLanguagesLevel8.Add("C# C# C#");
            listWithLanguagesLevel8.Add("JS JS JS");
            listWithLanguagesLevel8.Add("Java Java Java");
            listWithLanguagesLevel8.Add("Python Python Python");

            foreach (var language in listWithLanguagesLevel8)
            {
                var systemSoftwareId = jobLevel8.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "System Software").Id;
                var programmingId = jobLevel8.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Programming Software").Id;
                var applicationId = jobLevel8.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Application Software").Id;
                var driveId = jobLevel8.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Driver Software").Id;

                var splitLanguage = language.Split(" ").ToArray();

                // Driver Software
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = driveId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"ASP.NETCore" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "JS")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = driveId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"Angular" && x.Points == 10).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = driveId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"SpringFramework" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "Python")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = driveId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"Django" && x.Points == 20).Id,
                    });
                }

                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = driveId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 50).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = driveId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"Java" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = driveId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = driveId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 35).Id,
                });

                // Application Software
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = applicationId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"ASP.NETCore" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "JS")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = applicationId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"Angular" && x.Points == 10).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = applicationId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"SpringFramework" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "Python")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = applicationId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"Django" && x.Points == 20).Id,
                    });
                }

                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = applicationId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 50).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = applicationId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"Java" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = applicationId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = applicationId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 35).Id,
                });

                // Programing Software
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = programmingId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"ASP.NETCore" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "JS")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = programmingId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"React.JS" && x.Points == 10).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = programmingId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"SpringFramework" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "Python")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = programmingId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"Django" && x.Points == 20).Id,
                    });
                }

                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = programmingId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 50).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = programmingId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"Java" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = programmingId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = programmingId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 35).Id,
                });

                // System Software
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = systemSoftwareId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"ASP.NETCore" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "JS")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = systemSoftwareId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"React.JS" && x.Points == 10).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = systemSoftwareId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"SpringFramework" && x.Points == 25).Id,
                    });
                }
                else if (splitLanguage[0] == "Python")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = systemSoftwareId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"Django" && x.Points == 20).Id,
                    });
                }

                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = systemSoftwareId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 50).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = systemSoftwareId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"Java" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = systemSoftwareId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = systemSoftwareId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 35).Id,
                });
            }

            // Job Level 5
            var listWithLanguagesLevel5 = new List<string>();
            listWithLanguagesLevel5.Add("C# C#");
            listWithLanguagesLevel5.Add("JS JS");
            listWithLanguagesLevel5.Add("Java Java");
            listWithLanguagesLevel5.Add("Python Python");

            foreach (var language in listWithLanguagesLevel5)
            {
                var fitnessId = jobLevel5.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Fitness").Id;
                var foodDeliveryId = jobLevel5.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Food Delivery").Id;
                var dateChatId = jobLevel5.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Date Chat").Id;
                var acadedmyId = jobLevel5.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Academy").Id;
                var shoesShopId = jobLevel5.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Shoes Shop").Id;
                var computerShopId = jobLevel5.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Computer Shop").Id;

                var splitLanguage = language.Split(" ").ToArray();

                // Computer Shop
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = computerShopId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = computerShopId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"JS" && x.Points == 20).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = computerShopId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 30).Id,
                });
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = computerShopId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MSSQL" && x.Points == 15).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = computerShopId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MySQL" && x.Points == 15).Id,
                    });
                }

                // ShoesShop
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = shoesShopId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 25).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = shoesShopId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"JS" && x.Points == 20).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = shoesShopId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 25).Id,
                });
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = shoesShopId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MSSQL" && x.Points == 15).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = shoesShopId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MySQL" && x.Points == 15).Id,
                    });
                }

                // Academy
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = acadedmyId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 25).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = acadedmyId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"JS" && x.Points == 20).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = acadedmyId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 25).Id,
                });
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = acadedmyId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MSSQL" && x.Points == 15).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = acadedmyId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MySQL" && x.Points == 15).Id,
                    });
                }

                // Date Chat
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = dateChatId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = dateChatId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"Java" && x.Points == 25).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = dateChatId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 25).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = dateChatId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"CSS" && x.Points == 15).Id,
                });
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = dateChatId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MSSQL" && x.Points == 15).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = dateChatId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MySQL" && x.Points == 15).Id,
                    });
                }

                // Food Delivery
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = foodDeliveryId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 35).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = foodDeliveryId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"JS" && x.Points == 25).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = foodDeliveryId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 25).Id,
                });
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = foodDeliveryId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MSSQL" && x.Points == 15).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = foodDeliveryId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MySQL" && x.Points == 15).Id,
                    });
                }

                // Fitness
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = fitnessId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{splitLanguage[0]}" && x.Points == 30).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = fitnessId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"JS" && x.Points == 20).Id,
                });
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = fitnessId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"HTML" && x.Points == 20).Id,
                });
                if (splitLanguage[0] == "C#")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = fitnessId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MSSQL" && x.Points == 20).Id,
                    });
                }
                else if (splitLanguage[0] == "Java")
                {
                    dbContext.JobRequirements.Add(new JobRequirement
                    {
                        JobId = fitnessId,
                        RequirementId = requirements.FirstOrDefault(x => x.Name == $"MySQL" && x.Points == 20).Id,
                    });
                }
            }

            // Job Level 1
            var listWithLanguagesLevel1 = new List<string>();
            listWithLanguagesLevel1.Add("C#");
            listWithLanguagesLevel1.Add("JS");
            listWithLanguagesLevel1.Add("Java");
            listWithLanguagesLevel1.Add("Python");

            foreach (var language in listWithLanguagesLevel1)
            {
                var helloWordId = jobsLevel1.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Hello World").Id;
                var chessGameId = jobsLevel1.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Chess Game").Id;
                var timerId = jobsLevel1.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Timer").Id;
                var snakeGameId = jobsLevel1.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Snake Game").Id;
                var tikToeGameId = jobsLevel1.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Tik-Toe Game").Id;
                var yuGiOhGameId = jobsLevel1.Where(x => x.RewardAbilityNames == $"{language}").FirstOrDefault(x => x.Name == "Yu-Gi-Oh Simple Card Game").Id;

                // Yu-Gi-Oh Simple Card Game
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = yuGiOhGameId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{language}" && x.Points == 30).Id,
                });

                // Tik-Toe Game
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = tikToeGameId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{language}" && x.Points == 25).Id,
                });

                // Snake Game
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = snakeGameId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{language}" && x.Points == 20).Id,
                });

                // Timer
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = timerId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{language}" && x.Points == 20).Id,
                });

                // Chess Game
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = chessGameId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{language}" && x.Points == 15).Id,
                });

                // Hello World
                dbContext.JobRequirements.Add(new JobRequirement
                {
                    JobId = helloWordId,
                    RequirementId = requirements.FirstOrDefault(x => x.Name == $"{language}" && x.Points == 5).Id,
                });
            }

            dbContext.SaveChanges();
        }
    }
}
