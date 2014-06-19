using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillaSenegal.Models;

namespace VillaSenegalDAL
{
    public  class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(DbContext context) :
            base(context) { }

    }
}
