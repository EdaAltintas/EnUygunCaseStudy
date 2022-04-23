using System.Collections.Generic;

namespace enuygun.Models
{
    public class Agenda
    {
        public Agenda(int week, int capacity)
        {
            Week = week;
            Capacity = capacity;
            Tasks = new List<Task>();
        }

        public int Week { get; private set; }
        public List<Task> Tasks { get; private set; }
        public int Capacity { get; private set; }
        public List<Task> AddTask(Task task)
        {
            if (!task.IsAssigned)
            {
                Tasks.Add(task);
                task.ChangeAssignStatus(true);
                Capacity -= task.Capacity;
            }
            return Tasks;
        }

    }
}
