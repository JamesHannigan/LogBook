using LogBook.BusinessLogic.DTO.API;
using LogBook.BusinessLogic.Interface.API;
using LogBook.Data.Interface.Data;
using LogBook.Data.Models;

namespace LogBook.BusinessLogic.Service.API
{
    public class ClientActivityService : IClientActivityService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IActivityRepository _activityRepository;
        public ClientActivityService(
            IProjectRepository projectRepository,
            IActivityRepository activityRepository)
        {
            _projectRepository = projectRepository;
            _activityRepository = activityRepository;
        }

        public async Task LogActivity(LogModelDTO logModel)
        {
            //Get the project
            Project? project = _projectRepository.GetProjectByAPIKey(logModel.APIKey);

            //Convert the DTO to model.
            Activity activity = new()
            {
                Description = logModel.Description,
                Project = project,
            };

            await _activityRepository.InsertAndCommit(activity);
        }
    }
}
