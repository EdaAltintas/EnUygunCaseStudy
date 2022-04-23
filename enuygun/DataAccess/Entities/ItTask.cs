using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class ItTask
    {
        [Key]
        public string id { get; set; }
        public int zorluk { get; set; }
        public int sure { get; set; }
    }
}
