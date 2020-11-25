using Microsoft.EntityFrameworkCore;

namespace CyberWars.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using CyberWars.Data;
    using CyberWars.Data.Models.Player;
    using CyberWars.Services.Data.Home;
    using CyberWars.Web.ViewModels.HomeViews;
    using Microsoft.AspNetCore.Mvc;

    public class LayoutNavbarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public LayoutNavbarViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke(string userId)
        {
            var player = this.dbContext.Players.FirstOrDefault(x => x.UserId == userId);
            var viewModel = new PlayerDataView
            {
                UserId = player.UserId,
                Id = player.Id,
                Experience = player.Experience,
                Class = player.Class,
                ImageName = player.ImageName,
                Health = player.Health,
                MaxHealth = player.MaxHealth,
                MaxEnergy = player.MaxEnergy,
                Energy = player.Energy,
                LearnPoint = player.LearnPoint,
                Level = player.Level,
                Money = player.Money,
                Levels = this.dbContext.Levels.ToList(),
            };
            return this.View(viewModel);
        }
    }
}
