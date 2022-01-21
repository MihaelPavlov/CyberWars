namespace CyberWars.Data.Models.Pet_Food
{
    using CyberWars.Data.Common.Models;

    public class RandomHangfireFood : BaseDeletableModel<int>
    {
        public int FoodId { get; set; }

        public Food Food { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }
    }
}
