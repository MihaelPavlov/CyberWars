namespace CyberWars.Web.ViewModels.HomeViews.Pet
{
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Services.Mapping;

    public class PlayerFoodViewModel : IMapFrom<PlayerFood>
    {
        public string PlayerId { get; set; }

        public int FoodId { get; set; }

        public FoodViewModel Food { get; set; }

        public int Quantity { get; set; }
    }
}
