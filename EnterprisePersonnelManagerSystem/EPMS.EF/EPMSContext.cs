using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class EPMSContext : DbContext
    {
        public EPMSContext(DbContextOptions<EPMSContext> options):base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<StaffInfo> StaffInfos { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceTimeSet> AttendanceTimeSets { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<LoginInfo> LoginInfos { get; set; }
    }
}
