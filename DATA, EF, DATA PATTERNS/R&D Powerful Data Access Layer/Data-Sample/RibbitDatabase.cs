using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RibbitMvc.Models;

namespace RibbitMvc.Data
{
    public class RibbitDatabase : DbContext
    {
        public DbSet<User> Users { get; set;  }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Ribbit> Ribbits { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Followings)
                .Map(map =>
                 {
                    map.MapLeftKey("FollowgId");
                    map.MapRightKey("FolllowerId");
                    map.ToTable("Follow");
                 });

            modelBuilder.Entity<User>().HasMany(u => u.Ribbits);


            base.OnModelCreating(modelBuilder);

        }
    }
}