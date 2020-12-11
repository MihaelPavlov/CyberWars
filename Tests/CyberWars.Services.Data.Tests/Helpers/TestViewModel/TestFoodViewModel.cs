namespace CyberWars.Services.Data.Tests.Helpers.TestViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Services.Mapping;

    public class TestFoodViewModel : IMapFrom<RandomHangfireFood>
    {
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public int FoodGainHealth { get; set; }

        public int FoodGainExp { get; set; }

        public decimal FoodPrice { get; set; }

        public string FoodImageName { get; set; }

        public string FoodDescription { get; set; }
    }
}
