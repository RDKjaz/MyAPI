using MyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasKey(u => new { u.StudentId, u.CourseId });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = 127.0.0.1; UserId = postgres; Password = ****; Port = ****; Database = dbWebApi;");
        }

    }
}