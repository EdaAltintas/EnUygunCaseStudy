using Business.Abstract;
using enuygun.Models;
using System.Collections.Generic;
using System.Linq;

namespace enuygun.Helper
{
    public class SchedulePlan
    {
        private readonly IBusinessTaskService _businessTaskService;
        private readonly IITTaskService _itTaskService;
        public SchedulePlan(IBusinessTaskService businessTaskService, IITTaskService itTaskService)
        {
            _businessTaskService = businessTaskService;
            _itTaskService = itTaskService;
        }
        List<Models.Task> Tasks = new();
        void SetListByDBData()
        {

            var businessTasks = _businessTaskService.GetBusinessTasks();
            var itTasks = _itTaskService.GetItTasks();

            // Transform api datas to common Task Model
            foreach (var item in itTasks)
            {
                Models.Task task = new Models.Task(item.id, item.zorluk, item.sure);
                Tasks.Add(task);
            }
            foreach (var item in businessTasks)
            {
                Models.Task task = new Models.Task(item.BusinessId, item.Level, item.Estimated_Duration);
                Tasks.Add(task);
            }
        }

        public List<Developer> GeneratePlan()
        {
            SetListByDBData();
            Developer dev1 = new("Developer 1", 1);
            Developer dev2 = new("Developer 2", 2);
            Developer dev3 = new("Developer 3", 3);
            Developer dev4 = new("Developer 4", 4);
            Developer dev5 = new("Developer 5", 5);

            List<Developer> developers = new List<Developer> { dev1, dev2, dev3, dev4, dev5 }.OrderByDescending(d => d.Effort).ToList();
            var levelOrderedTasks = Tasks.OrderByDescending(x => x.Level);
            int week = 0;
            while (levelOrderedTasks.Any(x => !x.IsAssigned))
            {
                week++;
                foreach (var developer in developers)
                {
                    foreach (var task in levelOrderedTasks.Where(task => !task.IsAssigned))
                    {
                        if (developer.IsAvailable(week, task.Capacity))
                        {
                            developer.AssignTask(week, task);
                        }
                    }
                }
            }
            return developers;
        }
    }
}
