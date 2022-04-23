using Business.Abstract;
using DataAccess;
using DataAccess.Abstract;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ITTaskManager : IITTaskService
    {
        private IItTaskDal _ittaskDal;
        public ITTaskManager(IItTaskDal ittaskDal)
        {
            _ittaskDal = ittaskDal;
        }
        public int AddBulk()
        {
            ApiData apiData = new();
            var list = apiData.ItTasksApiGet();
            return _ittaskDal.AddBulk(list);
        }
        public IEnumerable<ItTask> GetItTasks()
        {
            return _ittaskDal.ToList();
        }
    }
}
