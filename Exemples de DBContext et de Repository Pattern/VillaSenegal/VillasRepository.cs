using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillaSenegal.Models;

namespace VillaSenegalDAL
{
    public class VillasRepository : GenericRepository<Villa>
    {
        public VillasRepository(DbContext context) :
            base(context) { }


    }
}
