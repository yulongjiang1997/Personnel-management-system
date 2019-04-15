using EPMS.Model.Model;
using Microsoft.EntityFrameworkCore;

namespace EPMSEF
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
        public DbSet<CompanySchedule> CompanySchedules { get; set; }
        public DbSet<PersonalSchedule> PersonalSchedules { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<InAndOutStockDetailed> InAndOutStockDetaileds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockOperationRecords> StockOperationRecordss { get; set; }
    }
}
