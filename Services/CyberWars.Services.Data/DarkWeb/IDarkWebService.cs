namespace CyberWars.Services.Data.DarkWeb
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Web.ViewModels.HomeViews;

    public interface IDarkWebService
    {
        public Task<PlayerDataView> FindNormalEnemy(string type, string userId);
    }
}
