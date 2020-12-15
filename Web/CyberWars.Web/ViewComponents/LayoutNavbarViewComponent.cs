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
    using Hangfire;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class LayoutNavbarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public LayoutNavbarViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var player = await this.dbContext.Players.FirstOrDefaultAsync(x => x.UserId == userId);
            if ((player.Health < player.MaxHealth || player.Energy < player.MaxEnergy) && !player.IsStatsResetStart)
            {
                BackgroundJob.Schedule(() => this.ResetStats(player.Id), TimeSpan.FromMinutes(59));
                player.IsStatsResetStart = true;
            }

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

            this.dbContext.Players.Update(player);

            await this.dbContext.SaveChangesAsync();

            return this.View(viewModel);
        }

        public async Task ResetStats(string playerId)
        {
            /* Here we need get the player again from the database or we get the player that wi give to the hangifre.Scedule
              function and all changes when we do in that time will return .*/
            var nowPlayer = await this.dbContext.Players.FirstOrDefaultAsync(x => x.Id == playerId);
            nowPlayer.Health = nowPlayer.MaxHealth;
            nowPlayer.Energy = nowPlayer.MaxEnergy;
            nowPlayer.IsStatsResetStart = false;
            this.dbContext.Players.Update(nowPlayer);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
