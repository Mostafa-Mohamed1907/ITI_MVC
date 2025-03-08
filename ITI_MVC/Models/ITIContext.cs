using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Models
{
    public class ITIContext:DbContext
    {
        public ITIContext():base()
        {
            
        }

        public DbSet<Employee>? Employee { get; set; }
        public DbSet<Department>? Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-IOVTDI0;Database=ITI_MVC;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
