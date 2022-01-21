namespace CyberWars.Data.Models.Pet_Food
{
    using System;

    using CyberWars.Data.Common.Models;
    using CyberWars.Data.Models.Player;

    public class PlayerFood : IDeletableEntity
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int FoodId { get; set; }

        public Food Food { get; set; }

        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
