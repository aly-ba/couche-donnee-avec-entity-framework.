using System;
using System.Linq;
using EF7Samurai.Domain;
using EF7Samurai.Context;

namespace EF7Samurai.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
             TrackingGraphChangesWhileConnected();
        }

        private static void TrackingGraphChangesWhileConnected()
        {
            using (var context = new SamuraiContext())
            {
                var samurai= new Samurai { Name = "Kikuchiyo" };
                context.Samurais.Add(samurai);
                samurai.Quotes.Add(new Quote { Text = "I can't kill a lot with 1 sword!" });
                Console.WriteLine("How many quotes before saving:" + samurai.Quotes.Count());

                context.SaveChanges();
                Console.WriteLine("How many quotes after saving:" + samurai.Quotes.Count());
           
                Console.ReadLine();
            }
        }

   
   
    



    }
}
