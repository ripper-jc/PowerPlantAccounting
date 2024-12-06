using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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