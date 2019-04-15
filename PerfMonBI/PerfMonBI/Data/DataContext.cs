
using Microsoft.EntityFrameworkCore;

namespace ElGuerre.PowerBI.PerformanceCounters.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PerfCounter> Counters { get; set; }
        public DbSet<AverageCounter> AverageCounters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=localhost;Database=DemoPerformanceCounter;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=tcp:perfmonbi.database.windows.net,1433;Initial Catalog=DemoPerformanceCounters;Persist Security Info=False;User ID=### SQL USER ###;Password=### SQL DATABASE PWD ###;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}

