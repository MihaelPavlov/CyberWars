namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel.MarketViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Services.Mapping;

    public class TestMarketFoodViewModel : IMapFrom<Food>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GainHealth { get; set; }

        public int GainExp { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }
    }
}
