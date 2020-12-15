namespace CyberWars.Services.Data.Tests.WebServiceTests
{
    using System.Linq;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Tests.Helpers;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel.WebViewModel;
    using Xunit;

    public class WebServiceTests
    {
        [Fact]
        public async Task TestGetRandomJobs()
        {
            var webService = await TestDataHelpers.GetWebService();
            var result = await webService.GetRandomJobs<TestJobViewModel>();
            Assert.Equal(15, result.Count());
        }

        [Fact]
        public async Task TestCompleteJob()
        {
            var webService = await TestDataHelpers.GetWebService();
            await webService.CompleteJob(1, "Pesho");

            var result = await webService.GetPlayerCompleteJobs("Pesho");
            Assert.Single(result);
        }
    }
}
