namespace CyberWars.Web.ViewModels.HomeViews.Pet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Mapping;

    public class PlayerFoodViewModel : IMapFrom<PlayerFood>
    {
        public string PlayerId { get; set; }

        public int FoodId { get; set; }

        public FoodViewModel Food { get; set; }

        public int Quantity { get; set; }
    }
}
