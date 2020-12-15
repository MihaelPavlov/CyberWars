namespace CyberWars.Services.Data.Hangfire
{
    using System.Threading.Tasks;

    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Pet_Food;
    using Microsoft.EntityFrameworkCore;

    public class PetStatsService
    {
        private readonly IDeletableEntityRepository<PlayerPet> playerPetRepository;

        public PetStatsService(IDeletableEntityRepository<PlayerPet> playerPetRepository)
        {
            this.playerPetRepository = playerPetRepository;
        }

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
