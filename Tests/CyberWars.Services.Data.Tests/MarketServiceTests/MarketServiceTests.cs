namespace CyberWars.Services.Data.Tests.MarketServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Tests.Helpers;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel.MarketViewModel;
    using Xunit;

    public class MarketServiceTests
    {
        [Fact]
        public async Task TestGetAllFood()
        {
            var marketService = await TestDataHelpers.GetMarketService();

            var getAllFood = await marketService.GetAllFood<TestMarketFoodViewModel>();

            Assert.Equal(2, getAllFood.Count());
        }

        [Fact]
        public async Task TestGetAllPets()
        {
            var marketService = await TestDataHelpers.GetMarketService();

            var getAllPets = await marketService.GetAllPets<TestMarketPetViewModel>();

            Assert.Equal(2, getAllPets.Count());
        }

        [Fact]
        public async Task TestBuyPet()
        {
            var marketService = await TestDataHelpers.GetMarketService();

            await marketService.BuyPet(1, "Pesho", "TestName");

            var playerPets = await marketService.GetAllPlayerPets("TestId");

            Assert.Single(playerPets);
        }

        [Fact]
        public async Task TestBuyFood()
        {
            var marketService = await TestDataHelpers.GetMarketService();

            await marketService.BuyFood(1, "Pesho");
            await marketService.BuyFood(2, "Pesho");
            var getAllFood = await marketService.GetAllPlayerFood("TestId");

            Assert.Equal(2, getAllFood.Count());
        }
    }
}