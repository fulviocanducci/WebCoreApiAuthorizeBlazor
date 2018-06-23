using Microsoft.EntityFrameworkCore;
using Share;

namespace Api.Models
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<References> References { get; set; }
    }
}
