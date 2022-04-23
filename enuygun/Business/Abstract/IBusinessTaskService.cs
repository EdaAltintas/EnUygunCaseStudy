using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBusinessTaskService
    {
        int AddBulk();
        IEnumerable<BusinessTask> GetBusinessTasks();
    }
}
