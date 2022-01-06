using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Model
{
    public class EmployeeLeaveDBContext : DbContext
    {

        public EmployeeLeaveDBContext(DbContextOptions<EmployeeLeaveDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LeaveDetails> LeaveDetails { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<UserLogin> Registrationtab { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Company>()
            .HasMany(c => c.Employee)
             .WithOne(e => e.Company);

            builder.Entity<Employee>()
            .HasMany(c => c.Projects)
             .WithOne(e => e.Emp);

            builder.Entity<LeaveDetails>().HasNoKey();

        }
    }
}

