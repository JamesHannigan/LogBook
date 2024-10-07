using Bogus;
using LogBook;
using LogBook.BusinessLogic.Interface.Data;
using Microsoft.Extensions.DependencyInjection;
using Activity = LogBook.Data.Models.Activity;

namespace Tests
{
    [TestClass]
    public class BogusData
    {
        readonly IServiceProvider _services = Program.CreateHostBuilder(new string[] { }).Build().Services;
        private IActivityService _activityService;

        public BogusData()
        {
            _activityService = _services.GetRequiredService<IActivityService>();
        }

        [TestMethod]
        public async Task GenerateLogAsync()
        {
            //Get project ID

            Faker<Activity> activity = new Faker<Activity>(locale: "en")
                .RuleFor(p => p.ProjectId, f => 1)
                .RuleFor(p => p.LogTypeId, f => f.Random.Number(0,4))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Path, f => f.Internet.Url())
                .RuleFor(p => p.Timestamp, f => f.Date.Between(DateTime.Today, DateTime.Today.AddDays(1)));
            List<Activity> activities = activity.Generate(20);

            await _activityService.GetFiltersData();

            //var lorem = new Bogus.DataSets.Lorem(locale: "en");
            //Console.WriteLine(lorem.Sentence(25));

            

        }
    }
}