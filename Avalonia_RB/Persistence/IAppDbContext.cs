using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia_RB.Model;

namespace Avalonia_RB.Persistence
{
    public interface IAppDbContext
    {
        DbSet<Books> Books { get; set; } 
        DbSet<CheckOuts> CheckOuts { get; set; }
        DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync();

    }
}
