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
        private readonly IServiceProvider _services = Program.CreateHostBuilder(new string[] { }).Build().Services;
        private readonly IActivityService _activityService;

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
                .RuleFor(p => p.LogTypeId, f => f.Random.Number(1,6))
                .RuleFor(p => p.Description, f => f.Lorem.Sentence())
                .RuleFor(p => p.Path, f => f.Internet.Url())
                .RuleFor(p => p.Timestamp, f => f.Date.Between(DateTime.Today, DateTime.Today.AddDays(1)));
            List<Activity> activities = activity.Generate(35);

            await _activityService.LogActivities(activities);
        }
    }
}