using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class RoleRepository : BaseRepository<Roles>, IRolesRepository
    {
        public RoleRepository(DBContext context) : base(context)
        {
            
        }
    }
}