using CyberWars.Data.Models;
using CyberWars.Data.Models.Player;
using CyberWars.Data.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberWars.Services.Data.Tests.Helpers
{
    public static class TestDataHelpers
    {

        public static List<PlayerSkill> GetTestPlayerSkill()
        {
            return new List<PlayerSkill>
            {
                new PlayerSkill
                {
                    PlayerId = "PlayerTest1",
                    SkillId = 1,
                    Points = 0,
                },
            };
        }
        public static List<Skill> GetTestSkills()
        {
            return new List<Skill>
            {
               new Skill
                 {
                     Name = "Firewall Defence",
                     Description = "Increase the chanse to defence from attacks",
                     StartMoney = 120,
                 },
               new Skill
                 {
                    Name = "Motivation",
                    Description = "Motivation is the reason for people's action",
                    StartMoney = 120,
                 },
               new Skill
                 {
                    Name = "Knowledge",
                    Description = "Enhances the money of perBattle + 5",
                    StartMoney = 120,
                 },
               new Skill
                 {
                    Name = "Staying Power",
                    Description = "Increase the energy + 5",
                    StartMoney = 120,
                 },
               new Skill
                 {
                    Id = 1,
                    Name = "Health",
                    Description = "Affects the amount of life + 10",
                    StartMoney = 120,
                 },
            };
        }

        public static List<Player> GetTestPlayers()
        {
            return new List<Player>
            {
                new Player
                {
                    Id = "PlayerTest1",
                    Name = "PlayerTest1",
                    UserId = "Test1",
                    Class = "Programmer",
                    Energy = 100,
                    MaxEnergy = 100,
                    Health = 1000,
                    MaxHealth = 1000,
                    LearnPoint = 0,
                    Level = 1,
                    Experience = 0,
                    IsStatsResetStart = false,
                    ImageName = "TestImage",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                },
                new Player
                {
                    Id = "PlayerTest2",
                    Name = "PlayerTest2",
                    UserId = "Test2",
                    Class = "Hacker",
                    Energy = 100,
                    MaxEnergy = 100,
                    Health = 1000,
                    MaxHealth = 1000,
                    LearnPoint = 0,
                    Level = 1,
                    Experience = 0,
                    IsStatsResetStart = false,
                    ImageName = "TestImage",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                },
            };
        }

        public static List<ApplicationUser> GetTestUsers()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = "Test1",
                    UserName = "A",
                    Email = "a@a.a",
                    PlayerId = "PlayerTest1",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = "Test2",
                    UserName = "B",
                    Email = "b@b.b",
                    PlayerId = "PlayerTest2",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                },
            };
        }
    }
}
