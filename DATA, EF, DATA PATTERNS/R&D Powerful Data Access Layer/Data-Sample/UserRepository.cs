using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RibbitMvc.Models;

namespace RibbitMvc.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context, bool sharedContext) : base(context, sharedContext)
        {
        }

        public User GetBy(int id)
        {
            return Find(u => u.Id == id);
        }


        public User GetBy(string username)
        {
            return Find(u => u.Username == username);
        }

        public IQueryable<User> All(bool includeProfile)
        {
            throw new NotImplementedException();
        }

        public void CreateFollower(string username, User follower)
        {

            throw new NotImplementedException();
        }

        public void DeleteFollower(string username, User follower)
        {
            throw new NotImplementedException();
        }

        public User GetBy(int id, bool includeProfile = false, bool includeRibbits = false, bool includeFollowers = false, bool includeFollowing = false)
        {
            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

            return query.SingleOrDefault(u => u.Id == id);
        }

       

        public User GetBy(string username, bool includeProfile = false, bool includeRibbits = false, bool includeFollowers = false, bool includeFollowing= false)
        {
            var query = BuildUserQuery(includeProfile, includeRibbits, includeFollowers, includeFollowing);

           return query.SingleOrDefault(u => u.Username == username);
        }


        private IQueryable<User> BuildUserQuery(bool includeProfile, bool includeRibbits, bool includeFollowers,bool includeFollowing)
        {
            var query = DbSet.AsQueryable();

            if (includeProfile)
            {
                query = query.Include(u => u.Profile);
            }

            if (includeRibbits)
            {
                query = DbSet.Include(u => u.Ribbits);
            }

            if (includeFollowers)
            {
                query = DbSet.Include(u => u.Followers);
            }

            if (includeFollowing)
            {
                query = DbSet.Include(u => u.Followings);
            }

            return query;
        }
    }
}