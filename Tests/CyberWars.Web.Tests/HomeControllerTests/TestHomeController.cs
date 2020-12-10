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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TestHomeController
    {
       
        //[Fact]
        //public async Task TestViewModelForIndex()
        //{
        //    var mockController = new Mock<IHomeService>();
        //    mockController.Setup(x => x.GetPlayerData("Test")).ReturnsAsync(MockHomeService.GetPlayerDataView("Test"));

        //    var controller = new HomeController(mockController.Object);
        //    var result = controller.Index();
        //    Assert.IsType<ViewResult>(result);

        //    var viewResult =  result as ViewResult;

        //    Assert.IsType<PlayerDataView>(viewResult.Model);

        //    var viewModel = viewResult.Model as PlayerDataView;

        //    Assert.Equal("Test", viewModel.UserId);
        //}


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
