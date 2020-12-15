namespace CyberWars.Data.Seeding.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountsSeeder : ISeeder
    {
        public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();

            // Get PlayerService When create a user need create player ,skills, abilities , and ..... see register.page
        }
    }
}
