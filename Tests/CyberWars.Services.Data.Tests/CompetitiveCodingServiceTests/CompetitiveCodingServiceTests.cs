namespace CyberWars.Services.Data.Tests.CompetitiveCodingServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using CyberWars.Services.Data.Tests.Helpers;
    using CyberWars.Services.Data.Tests.Helpers.TestViewModel.ContestViewModel;
    using Xunit;

    public class CompetitiveCodingServiceTests
    {
        [Fact]
        public async Task TestGetContest()
        {
            var contestService = await TestDataHelpers.GetContestService();

            var getContest = await contestService.GetContests<TestContestViewModel>();

            Assert.Equal(4, getContest.Count());
        }

        //[Fact]
        //public async Task TestResultFromContestById()
        //{
        //    var contestService = await TestDataHelpers.GetContestService();

        //    var resultContest = await contestService.ResultFromContestById(1, "Pesho");

        //    Assert.Equal(1, resultContest.ContestId);
        //}

        //[Fact]
        //public async Task TestResultFromContestByIdReturnNull()
        //{
        //    var contestService = await TestDataHelpers.GetContestService();

        //    var resultContest = await contestService.ResultFromContestById(4, "Pesho");
        //    var resultContest1 = await contestService.ResultFromContestById(4, "Pesho");
        //    var resultContest2 = await contestService.ResultFromContestById(4, "Pesho");
        //    var resultContest3 = await contestService.ResultFromContestById(4, "Pesho");
        //    var resultContest4 = await contestService.ResultFromContestById(4, "Pesho");

        //    Assert.Equal(4, resultContest.ContestId);
        //    var resultContest5 = await contestService.ResultFromContestById(4, "Pesho");
        //    Assert.Null(resultContest5);
        //}
    }
}
