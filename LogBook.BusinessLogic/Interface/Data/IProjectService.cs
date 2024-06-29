using LogBook.Data.Interface.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.BusinessLogic.Interface.Data
{
    public interface IProjectService
    {
        Task CreateProject(string name);
        Task<string> GetProjectsHTML();
    }
}
