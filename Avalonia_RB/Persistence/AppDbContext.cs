using System.Data.Entity;
using System.Threading.Tasks;
using Avalonia_RB.Model;

namespace Avalonia_RB.Persistence
{
    class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<CheckOuts> CheckOuts { get; set; }
        public DbSet<User> Users { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
