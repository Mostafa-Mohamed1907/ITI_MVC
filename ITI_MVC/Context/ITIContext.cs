using ITI_MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITI_MVC.Context
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        public ITIContext():base()
        {
            
        }
        public ITIContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee>? Employee { get; set; }
        public DbSet<Department>? Department { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-IOVTDI0;Database=ITI_MVC;Trusted_Connection=True;TrustServerCertificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
