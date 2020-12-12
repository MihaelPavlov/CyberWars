﻿using CyberWars.Data.Models.Course;
using CyberWars.Services.Data.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CyberWars.Services.Data.Tests.AcademyServiceTests
{
    public class AcademyServiceTests
    {
        [Fact]
        public async Task TestGetLecturesByName()
        {
            var academyService = await TestDataHelpers.GetAcademyService();
            var result = await academyService.GetLecturesByName("Python OOP", "Pesho");
            Assert.Equal(1, result.Count());
        }

        [Fact]
        public async Task TestCompleteLecture()
        {
            var academyService = await TestDataHelpers.GetAcademyService();

            await academyService.CompleteLectureById("Pesho", 1);


            var result = await academyService.GetCompleteLectureById("TestId", 1);
            Assert.Equal(1, result.LectureId);
            Assert.True(result.IsComplete);
        }

        [Fact]
        public async Task TestGetRewardCorrectFromCompleteLecture()
        {
            var academyService = await TestDataHelpers.GetAcademyService();

            var lecture = await academyService.GetLectureById(1);

            await academyService.GetRewardFromCompleteLecture("TestId", lecture);

            var playerAbilities = await academyService.CheckPlayerAbilities("TestId");

            Assert.Contains(playerAbilities, x => x.Points == 1);
        }

        [Fact]
        public async Task TestCompleteLectureCreated()
        {
            var academyService = await TestDataHelpers.GetAcademyService();

            var lecture = await academyService.GetLectureById(1);
            var player = await academyService.GetPlayerById("TestId");
            var result = academyService.CreateCompleteLecture(lecture, player);

            Assert.IsType<CompleteLecture>(result);
        }
    }
}
