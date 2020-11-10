namespace CyberWars.Services.Data.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Data.Models.Player;
    using CyberWars.Data.Models.Skills;
    using CyberWars.Web.ViewModels.HomeViews;

    public interface IHomeService
    {
        public Task<T> GetPlayerData<T>(string userId);

        public Task<IEnumerable<T>> GetPlayerSkills<T>(string userId);
    }
}
