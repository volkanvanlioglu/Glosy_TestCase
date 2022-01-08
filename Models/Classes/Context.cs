using System.Data.Entity;

namespace Glosy_TestCase.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}