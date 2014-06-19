using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using VillaSenegal.Models;
using VillaSenegal.DAL.Configuration;

namespace VillaSenegal.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Villa> Villas { get; set; }


        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {

                    return ConfigurationManager
                        .AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }

        //tell the database to set the initializer to my CustomDatabaseInitializer
        static DataContext()
        {
            Database.SetInitializer(new CreateDatabase());
        }

        public DataContext() 
          : base(nameOrConnectionString: DataContext.ConnectionStringName) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new VillaConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            // base.OnModelCreating(modelBuilder);
        }

        private void AppliquerRules()
        {
            foreach (var entry in this.ChangeTracker.Entries()
                    .Where(
                        e => e.Entity is IAuditInfo &&
                            (e.State == EntityState.Added) ||
                            (e.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    e.DateDeCreation = DateTime.Now;

                }

                e.DateDeModification = DateTime.Now;
            }

        }

        public override int SaveChanges()
        {
            this.AppliquerRules();
            return base.SaveChanges();
        }
    }
}
