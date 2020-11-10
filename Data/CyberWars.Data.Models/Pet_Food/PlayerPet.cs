﻿namespace CyberWars.Data.Models.Pet_Food
{
    using CyberWars.Data.Models.Player;

    public class PlayerPet
    {
        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int Level { get; set; }

        public int Health { get; set; }

        public int Mood { get; set; }

        public string NameIt { get; set; }
    }
}
