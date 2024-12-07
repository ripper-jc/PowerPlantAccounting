using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class DBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        
    }
}