using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;

namespace MESSADIIS.Data
{
    class MessadiisMigrationConfiguration
        : DbMigrationsConfiguration<MessadiisContext>
    {

        public MessadiisMigrationConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        //called everytime that the application is restart
        protected override void Seed(MessadiisContext context)
        {
            base.Seed(context);

# if DEBUG

            if(context.Questions.Count() == 0 )
            {
                var Question = new Question () 
                {
                    Titre="Apple Quelle prétentetion  !" ,
                    Texte ="L'informatique, ça fait gagner beaucoup de temps... à condition d'en avoir beaucoup devant soi !" ,
                    Creation=DateTime.Now,
                    Reponses = new List<Reponse>
                    {
                        new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                    }
                };

                context.Questions.Add(Question);

                //an another one 
                var Question2 = new Question () 
                {
                    Titre="Apple Quelle prétentetion  !" ,
                    Texte ="L'informatique, ça fait gagner beaucoup de temps... à condition d'en avoir beaucoup devant soi !",
                    Creation=DateTime.Now,
                    Reponses = new List<Reponse>
                    {
                        new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                    }
                };

                context.Questions.Add(Question2);

                var Question3 = new Question () 
                {
                    Titre="Apple Quelle prétentetion  !" ,
                    Texte ="L'informatique, ça fait gagner beaucoup de temps... à condition d'en avoir beaucoup devant soi !" ,
                    Creation=DateTime.Now,
                    Reponses = new List<Reponse>
                    {
                        new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                    }
                };

                context.Questions.Add(Question3);

                var Question4 = new Question () 
                {
                    Titre="Apple Quelle prétentetion  !" ,
                    Texte ="L'informatique, ça fait gagner beaucoup de temps... à condition d'en avoir beaucoup devant soi !" ,
                    Creation=DateTime.Now,
                    Reponses = new List<Reponse>
                    {
                        new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                    }
                };

                context.Questions.Add(Question4);

                var Question5 = new Question () 
                {
                    Titre="Apple Quelle prétentetion  !" ,
                    Texte ="L'informatique, ça fait gagner beaucoup de temps... à condition d'en avoir beaucoup devant soi !" ,
                    Creation=DateTime.Now,
                    Reponses = new List<Reponse>
                    {
                        new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                         new Reponse()
                        {
                        Texte="Quelle prétention de prétendre que l'informatique est récente : Adam et Eve avaient déjà un Apple !",
                        Creation=DateTime.Now
                        },
                    }
                };

                context.Questions.Add(Question5);

                try {
                    context.SaveChanges();
                }
                catch(Exception ex) {
                    var msg = ex.Message;
                }
            }

#endif

        }
    }
}
