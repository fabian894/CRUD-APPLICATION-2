using FintrakAcademy3._0.Models;
using Microsoft.EntityFrameworkCore;

namespace FintrakAcademy3._0.Data;

   public class ApplicationDbContext : DbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
     { 

    }

    public DbSet<Student> Students { get; set; }
}
