using JanBatchCodeFirstApprochImpl.Models;
using Microsoft.EntityFrameworkCore;

namespace JanBatchCodeFirstApprochImpl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Emp> emps { get; set; }
        public DbSet<Employees> employee { get; set; }
        public DbSet<Managers> manager { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Student> students { get; set; }
    }
}
