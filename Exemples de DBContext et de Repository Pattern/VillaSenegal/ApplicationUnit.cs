using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillaSenegal.DAL;
using VillaSenegal.Models;

namespace VillaSenegalDAL
{
    public  class ApplicationUnit : IDisposable
    {
        private DataContext _context = new DataContext();

        private IRepository<Villa> _villas = null;
        private IRepository<User> _users = null;


        public IRepository<Villa> Villas
        {
            get
            {
                if (this.Villas == null)
                {

                    this._villas = new GenericRepository<Villa>(this._context);
                }
                return this._villas;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if(this._users== null)
                {
                    this._users = new GenericRepository<User>(this._context);
                }
                return this._users;
            }
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
    }
}
