using Attendance_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Attendance_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; } 
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}