using EF7Samurai.Domain;
using Microsoft.Data.Entity;

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
           options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database=EF7Samurai; Trusted_Connection=True;");
            base.OnConfiguring(options);
        }
  
     
    }
  
}
