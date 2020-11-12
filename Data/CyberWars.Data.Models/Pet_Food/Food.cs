namespace CyberWars.Data.Models.Pet_Food
{
    using System.ComponentModel.DataAnnotations;

    using CyberWars.Data.Common.Models;

    public class Food : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int GainHealth { get; set; }

        public int GainExp { get; set; }

        public int LevelRequirement { get; set; }

        public decimal Price { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }
    }
}
