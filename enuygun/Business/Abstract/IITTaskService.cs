using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IITTaskService
    {
        int AddBulk();
        IEnumerable<ItTask> GetItTasks();
    }
}
