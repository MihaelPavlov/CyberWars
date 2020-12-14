namespace CyberWars.Web.Tests.HomeControllerTests
{
    using CyberWars.Data;
    using CyberWars.Data.Models;
    using CyberWars.Services.Data.Home;
    using CyberWars.Web.Controllers;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TestHomeController
    {

        [Fact]
        public async Task TestViewModelForIndex()
        {

        }


    }

    public static class MockHomeService
    {
        public static PlayerDataView GetPlayerDataView(string userId)
        {
            var list = new List<PlayerDataView>()
           {
               new PlayerDataView
               {
                   Id="TestPlayer",
                   Money=1000,
                   UserId="Test",
                   Class="Programmer",
               },
               new PlayerDataView
               {
                   Id="TestPesho",
                   Money=1000,
                   UserId="Pesho",
                   Class="Programmer",
               },
               new PlayerDataView
               {
                   Id="TestGosho",
                   Money=1000,
                   UserId="Gosho",
                   Class="Programmer",
               },
           };

            return list.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
