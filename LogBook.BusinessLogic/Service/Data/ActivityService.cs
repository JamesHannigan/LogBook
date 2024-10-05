using LogBook.BusinessLogic.Interface.Data;
using LogBook.Data.Enum;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Service.Data
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ILogTypeRepository _logTypeRepository;
        public ActivityService(
            IActivityRepository activityRepository, 
            IProjectRepository projectRepository,
            ILogTypeRepository logTypeRepository)
        {
            _activityRepository = activityRepository;
            _projectRepository = projectRepository;
            _logTypeRepository = logTypeRepository;
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

        public string GetActivitiesAsTableRows(string? startDate, string? endDate, string? projectsString, string? logTypesString)
        {
            DateTime now = DateTime.UtcNow;
            DateTime start = !string.IsNullOrWhiteSpace(startDate) ? DateTime.Parse(startDate) : new (now.Year, now.Month, now.Day, 0, 0, 0, 0);
            DateTime endTemp = !string.IsNullOrWhiteSpace(endDate) ? DateTime.Parse(endDate) : new (now.Year, now.Month, now.Day, 23, 59, 59, 999);
            DateTime end = new(endTemp.Year, endTemp.Month, endTemp.Day, 23, 59, 59, 999);

            List<TypeLevel>? logTypes = !string.IsNullOrWhiteSpace(logTypesString) ? logTypesString.Split(',').Select(l => (TypeLevel)Int32.Parse(l)).ToList() : null;
            List<Guid>? projects = !string.IsNullOrWhiteSpace(projectsString) ? projectsString.Split(',').Select(p => Guid.Parse(p)).ToList() : null;

            List<Activity> activities = _activityRepository.GetLogsByFilters(start, end, projects, logTypes);
            return string.Join("", activities
                .OrderByDescending(a => a.Created)
                .Select(a => $"<tr><td>{(a.LogType != null ? a.LogType.Name : "")}</td><td>{a.Description}</td><td>{a.Path}</td><td>{(a.Project != null ? a.Project.Name : "")}</td><td>{a.UserName}</td><td>{a.Created.ToString("dd/MM/yyyy HH:mm")}</td></tr>")
                );
        }

        public async Task<FiltersData> GetFiltersData()
        {
            //Get the data
            //TO DO - Only get projects that are assigned to the user
            List<Project> projects = await _projectRepository.GetAll();
            //TO DO - This needs to be only related to the projects assinged to the user
            //List<LogType> logTypes = await _logTypeRepository.GetAll();
            List<TypeLevel> logTypes = Enum.GetValues(typeof(TypeLevel)).Cast<TypeLevel>().ToList();
            //TO DO - Get users

            FiltersData filters = new FiltersData();
            filters.Projects = projects.Select(p => new FilterObject { Id = p.PublicId.ToString(), Name = p.Name }).ToList();
            filters.Types = logTypes.Select(t => new FilterObject { Id = ((int)t).ToString(), Name = t.ToString() }).ToList();

            return filters;
        }
    }

    public class FiltersData
    {
        public List<FilterObject>? Projects { get; set; }
        public List<FilterObject>? Types { get; set; }
        public List<FilterObject>? Users { get; set; }
    }

    public class FilterObject
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
