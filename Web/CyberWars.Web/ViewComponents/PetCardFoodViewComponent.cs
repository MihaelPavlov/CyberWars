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

        public PetCardFoodViewComponent(IDeletableEntityRepository<Food> foodRepository, IDeletableEntityRepository<Player> playerRepository)
        {
            this.foodRepository = foodRepository;
            this.playerRepository = playerRepository;
        }

        public IViewComponentResult Invoke(string userId)
        {
            var player = this.playerRepository.All().FirstOrDefault(x => x.UserId == userId);
            var foods = this.foodRepository.All().ToList();
            
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
                Foods = player.Foods.Select(x=> new Food 
                {
                   ImageName=x.ImageName
                }).ToList()
            };
            return this.View(viewModel);
        }

    }
}
