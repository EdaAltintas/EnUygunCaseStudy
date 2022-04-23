using Business.Abstract;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BusinessTaskManager : IBusinessTaskService
    {
        private IBusinessTaskDal _businessTaskDal;
        public BusinessTaskManager(IBusinessTaskDal businessTaskDal)
        {
            _businessTaskDal = businessTaskDal;
        }
        public int AddBulk()
        {
            ApiData apiData = new();
            var list=apiData.BusinessTasksApiGet();
            return _businessTaskDal.AddBulk(list);
        }
        public IEnumerable<BusinessTask> GetBusinessTasks()
        {
            return _businessTaskDal.ToList();
        }
    }
}
