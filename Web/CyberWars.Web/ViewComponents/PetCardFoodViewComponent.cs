namespace CyberWars.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Data;
    using CyberWars.Data.Common.Repositories;
    using CyberWars.Data.Models.Pet_Food;
    using CyberWars.Data.Models.Player;
    using CyberWars.Web.ViewModels.HomeViews;
    using CyberWars.Web.ViewModels.HomeViews.Pet;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class PetCardFoodViewComponent : ViewComponent
    {
        private readonly IDeletableEntityRepository<Food> foodRepository;
        private readonly IDeletableEntityRepository<Player> playerRepository;
        private readonly IDeletableEntityRepository<PlayerFood> playerFoodRepository;

        public PetCardFoodViewComponent(IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<Player> playerRepository,
            IDeletableEntityRepository<PlayerFood> playerFoodRepository)
        {
            this.foodRepository = foodRepository;
            this.playerRepository = playerRepository;
            this.playerFoodRepository = playerFoodRepository;
        }

        public IViewComponentResult Invoke(string userId)
        {
            var player = this.playerRepository.All().FirstOrDefault(x => x.UserId == userId);

            var playerFood = this.playerFoodRepository.All().ToList();

            var viewModel = new PlayerDataView
            {
                UserId = player.UserId,
                PlayerId = player.Id,
                Experience = player.Experience,
                Class = player.Class,
                ImageName = player.ImageName,
                Health = player.Health,
                Energy = player.Energy,
                LearnPoint = player.LearnPoint,
                Level = player.Level,
                Money = player.Money,
                PlayerFoods = playerFood.Where(x => x.PlayerId == player.Id).Select(x => new PlayerFoodViewModel
                {
                    Food = new FoodViewModel
                    {
                        Description = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).Description,
                        GainExp = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).GainExp,
                        GainHealth = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).GainHealth,
                        Id = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).Id,
                        Name = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).Name,
                        Price = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).Price,
                        ImageName = this.foodRepository.All().FirstOrDefault(fr => fr.Id == x.FoodId).ImageName,
                    },
                    PlayerId = player.Id,
                    FoodId = x.FoodId,
                    Quantity = x.Quantity,
                }).ToList(),
            };
            return this.View(viewModel);
        }
    }
}
