using EF7Samurai.Domain;
using Microsoft.Data.Entity;

using System;

namespace EF7Samurai.Context
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptions options)
        {
            //options.UseInMemoryStore();
            options
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database=EF7Samurai; Trusted_Connection=True; MultipleActiveResultSets = True;")
                .MaxBatchSize(40);
     
            //base.OnConfiguring(options); <-- a reminder that this does nothing, so unneeded (no-op)
        }

#if false
        //alternate to hard coding options, pass them in from calling app
        //this would be the constructor
        //do not set options in OnConfiguring

        public SamuraiContext(DbContextOptions options) :base(options)
        { }
#endif
    }

}
