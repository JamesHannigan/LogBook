using LogBook.BusinessLogic.DTO.API;

namespace LogBook.BusinessLogic.Interface.API
{
    public interface IClientActivityService
    {
        Task LogActivity(LogModelDTO logModel);
    }
}