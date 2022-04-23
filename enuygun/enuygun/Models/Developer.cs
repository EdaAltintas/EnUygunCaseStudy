using System.Collections.Generic;
using System.Linq;

namespace enuygun.Models
{
    public class Developer
    {
        private static int WORKING_HOUR = 45;

        public Developer(string name, int effort)
        {
            this.Name = name;
            this.Capacity = WORKING_HOUR * effort;
            this.Effort = effort;
            Agendas = new List<Agenda>();
        }
        
        public string Name { get;private set; }
        public int Effort { get; private set; }
        public int Capacity { get; private set; }
        public List<Agenda> Agendas { get; private set; } 
        public bool IsAvailable(int week, int _capacity)
        {
            var agenda = Agendas.FirstOrDefault(x => x.Week == week);
            if (agenda == default)
            {
                var newAgenda = new Agenda(week, Capacity);
                Agendas.Add(newAgenda);
                agenda = newAgenda;
            }
            return agenda.Capacity >= _capacity;
        }
        public void AssignTask(int week,Task task)
        {
            Agendas.First(x => x.Week == week).AddTask(task);
        }

    }
}
