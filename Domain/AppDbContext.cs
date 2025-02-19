using Lab4_2.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4_2.Domain
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }   


        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<ClassEnrollment> ClassEnrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=universitydb;Username=postgres;Password=postgrespassword");

        }

    }
}
