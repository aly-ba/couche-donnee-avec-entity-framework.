using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MESSADIIS.Data
{
        public class MessadiisContext : DbContext
        {
            //we use simply defaultConnectin vs express
            public MessadiisContext() 
                    : base("DefaultConnection")
                    
            {
                this.Configuration.LazyLoadingEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;


                Database.SetInitializer(
                    new MigrateDatabaseToLatestVersion<MessadiisContext,MessadiisMigrationConfiguration>()
                    );

            }

            public DbSet<Question> Questions{ get; set;  }
            public DbSet<Reponse>  Reponses { get; set;  }

        }
}