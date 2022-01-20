namespace CyberWars.Services.Data.Hangfire
{
    using System;
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Pet_Food;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Use this class to update pet stats on every n hour.
    /// </summary>
    public class PetStatsService
    {
        private readonly IDeletableEntityRepository<PlayerPet> playerPetRepository;

        /// <summary>
        /// Constructor that instantiates PetStatsService.
        /// </summary>
        /// <param name="playerPetRepository"></param>
        public PetStatsService(IDeletableEntityRepository<PlayerPet> playerPetRepository)
        {
            this.playerPetRepository = playerPetRepository ?? throw new ArgumentNullException(nameof(playerPetRepository));
        }

        /// <summary>
        /// Use this method to downscale the pet stats on every hour.
        /// </summary>
        public async Task PetStatsDownEveryHour()
        {
            int minusHealthEveryHour = 20;

            int minusMoodEveryHour = 10;

            foreach (var playerPet in await this.playerPetRepository.All().ToListAsync())
            {
                playerPet.Health -= minusHealthEveryHour;

                // Validation for pet Health
                if (playerPet.Health < 0)
                {
                    playerPet.Health = 0;
                }

                playerPet.Mood -= minusMoodEveryHour;

                // Validation for pet Mood
                if (playerPet.Mood < 0)
                {
                    playerPet.Mood = 0;
                }

                this.playerPetRepository.Update(playerPet);
            }

            await this.playerPetRepository.SaveChangesAsync();
        }
    }
}
