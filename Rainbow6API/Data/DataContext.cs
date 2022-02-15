using Microsoft.EntityFrameworkCore;

namespace Rainbow6API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Operator> Operators { get; set; }
    }
}
