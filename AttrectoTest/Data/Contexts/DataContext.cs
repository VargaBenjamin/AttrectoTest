using AttrectoTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttrectoTest.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
