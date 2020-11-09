namespace CyberWars.Data.Models.Pet_Food
{
    using System.ComponentModel.DataAnnotations;

    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string Name { get; set; }

        public int GainHealth { get; set; }

        public int GainExp { get; set; }

        public int LevelRequirement { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }
    }
}
