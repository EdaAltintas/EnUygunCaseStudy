using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ToDoContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringUrl = @"Server=DESKTOP-KO5GV60\SQLEXPRESS; Database=CaseDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(stringUrl);
        }
        public DbSet<ItTask> ItTasks { get; set; }
        public DbSet<BusinessTask> BusinessTasks { get; set; }
    }
}
