namespace enuygun.Models
{
    public class Task
    {
        public Task(string id, int level, int duration)
        {
            Id = id;
            Level = level;
            Duration = duration;
            Capacity = level*duration;
        }

        public string Id { get; private set; }
        public int Level { get; private set; }
        public int Duration { get; private set; }
        public int Capacity { get; private set; }
        public bool IsAssigned { get; private set; } = false;

        public void ChangeAssignStatus(bool status)
        {
            IsAssigned = status;
        }
    }
}
