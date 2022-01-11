using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Model
{
    public class EmployeeLeaveDBContext : DbContext
    {
        public EmployeeLeaveDBContext()
        {
        }

        public EmployeeLeaveDBContext(DbContextOptions<EmployeeLeaveDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public virtual DbSet<JwtAuthenticationModel> TokenAuthentication { get; set; }
        public virtual  DbSet<LeaveRequest> LeaveRequests { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

