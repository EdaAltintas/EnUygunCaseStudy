using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class BusinessTask
    {
        [Key]
        public string BusinessId { get; set; }
        public int Level { get; set; }
        public int Estimated_Duration { get; set; }
    }
}
