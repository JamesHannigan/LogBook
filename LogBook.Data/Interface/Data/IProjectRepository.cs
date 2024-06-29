using LogBook.Data.Models;
using LogBook.DataLayer.Interfaces;

namespace LogBook.Data.Interface.Data
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Project? GetProjectByAPIKey(string apiKey);
    }
}
