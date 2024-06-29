using LogBook.BusinessLogic.Interface.Data;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Service.Data
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task LogActivity(int? type, string? description, int? userId, string? userName, string? userEmail, string? path)
        {
            try
            {
                await _activityRepository.InsertAndCommit(
                    new Activity()
                    {
                        LogTypeId = type,
                        Description = description,
                        UserID = userId,
                        UserName = userName,
                        UserEmail = userEmail,
                        Path = path,
                        ProjectId = 1 //Testing
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task LogError(int? type, string? description, int? userId, string? userName, string? userEmail, string? path)
        {
            try
            {
                await _activityRepository.InsertAndCommit(
                    new Activity()
                    {
                        LogTypeId = type,
                        Description = description,
                        UserID = userId,
                        UserName = userName,
                        UserEmail = userEmail,
                        Path = path,
                        ProjectId = 1 //Testing
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetActivitiesAsTableRows(string? logTypesString)
        {
            List<int>? logTypes = !string.IsNullOrWhiteSpace(logTypesString) ? logTypesString.Split(',').Select(l => Int32.Parse(l)).ToList() : null;
            List<Activity> activities = _activityRepository.GetLogsByProjectID(1, logTypes);
            return string.Join("", activities
                .OrderByDescending(a => a.Created)
                .Select(a => $"<tr><td>{(a.LogType != null ? a.LogType.Name : "")}</td><td>{a.Description}</td><td>{a.Path}</td><td>{(a.Project != null ? a.Project.Name : "")}</td><td>{a.UserName}</td><td>{a.Created}</td></tr>")
                );
        }
    }
}
