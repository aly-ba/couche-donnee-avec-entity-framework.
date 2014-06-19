using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DataAccess;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlServerCe;

namespace BreakAwayConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<BreakAwayContext>());

      InsertDestination();
    }

    private static void InsertDestination()
    {
      var destination = new Destination
      {
        Country = "Indonesia",
        Description = "EcoTourism at its best in exquisite Bali",
        Name = "Bali"
      };

      using (var context = new BreakAwayContext())
      {
        context.Destinations.Add(destination);
        context.SaveChanges();
      }
    }

    private static void InsertTrip()
    {
      var trip = new Trip
      {
        CostUSD = 800,
        StartDate = new DateTime(2011, 9, 1),
        EndDate = new DateTime(2011, 9, 14)
      };

      using (var context = new BreakAwayContext())
      {
        context.Trips.Add(trip);
        context.SaveChanges();
      }
    }

    private static void InsertPerson()
    {
      var person = new Person
      {
        FirstName = "Rowan",
        LastName = "Miller",
        SocialSecurityNumber = 12345678,
        Photo = new PersonPhoto { Photo = new Byte[] { 0 } }
      };

      using (var context = new BreakAwayContext())
      {
        context.People.Add(person);
        context.SaveChanges();
      }
    }

    private static void UpdateTrip()
    {
      using (var context = new BreakAwayContext())
      {
        var trip = context.Trips.FirstOrDefault();
        trip.CostUSD = 750;
        context.SaveChanges();
      }
    }

    private static void UpdatePerson()
    {
      using (var context = new BreakAwayContext())
      {
        var person = context.People.Include("Photo").FirstOrDefault();
        person.FirstName = "Rowena";
        if (person.Photo == null)
        {
          person.Photo = new PersonPhoto { Photo = new Byte[] { 0 } };
        }

        context.SaveChanges();
      }
    }

    private static void DeleteDestinationInMemoryAndDbCascade()
    {
      int destinationId;
      using (var context = new BreakAwayContext())
      {
        var destination = new Destination
        {
          Name = "Sample Destination",
          Lodgings = new List<Lodging>
          {
            new Lodging { Name = "Lodging One" },
            new Lodging { Name = "Lodging Two" }
          }
        };

        context.Destinations.Add(destination);
        context.SaveChanges();
        destinationId = destination.DestinationId;
      }

      using (var context = new BreakAwayContext())
      {
        var destination = context.Destinations
          .Single(d => d.DestinationId == destinationId);

        context.Destinations.Remove(destination);
        context.SaveChanges();
      }

      using (var context = new BreakAwayContext())
      {
        var lodgings = context.Lodgings
          .Where(l => l.DestinationId == destinationId).ToList();

        Console.WriteLine("Lodgings: {0}", lodgings.Count);
      }
    }

    private static void InsertLodging()
    {
      var lodging = new Lodging
      {
        Name = "Rainy Day Motel",
        Destination = new Destination
        {
          Name = "Seattle, Washington",
          Country = "USA"
        }
      };

      using (var context = new BreakAwayContext())
      {
        context.Lodgings.Add(lodging);
        context.SaveChanges();
      }
    }

    private static void InsertResort()
    {
      var resort = new Resort
      {
        Name = "Top Notch Resort and Spa",
        MilesFromNearestAirport = 30,
        Activities = "Spa, Hiking, Skiing, Ballooning",
        Destination = new Destination
        {
          Name = "Stowe, Vermont",
          Country = "USA"
        }
      };

      using (var context = new BreakAwayContext())
      {
        context.Lodgings.Add(resort);
        context.SaveChanges();
      }
    }

    private static void InsertHostel()
    {
      var hostel = new Hostel
      {
        Name = "AAA Budget Youth Hostel",
        MilesFromNearestAirport = 25,
        PrivateRoomsAvailable = false,
        Destination = new Destination
        {
          Name = "Hanksville, Vermont",
          Country = "USA"
        }
      };
      using (var context = new BreakAwayContext())
      {
        context.Lodgings.Add(hostel);
        context.SaveChanges();
      }
    }

    private static void GetAllLodgings()
    {
      var context = new BreakAwayContext();
      var lodgings = context.Lodgings.ToList();

      foreach (var lodging in lodgings)
      {
        Console.WriteLine("Name: {0} Type: {1}",
        lodging.Name, lodging.GetType().ToString());
      }
    }

    private static void SpecifyDatabaseName()
    {
      using (var context = new BreakAwayContext("BreakAwayStringConstructor"))
      {
        context.Destinations.Add(new Destination { Name = "Tasmania" });
        context.SaveChanges();
      }
    }

    private static void ReuseDbConnection()
    {
      var cstr = @"Server=.\SQLEXPRESS;
        Database=BreakAwayDbConnectionConstructor;
        Trusted_Connection=true";

      using (var connection = new SqlConnection(cstr))
      {
        using (var context = new BreakAwayContext(connection))
        {
          context.Destinations.Add(new Destination { Name = "Hawaii" });
          context.SaveChanges();
        }

        using (var context = new BreakAwayContext(connection))
        {
          foreach (var destination in context.Destinations)
          {
            Console.WriteLine(destination.Name);
          }
        }
      }
    }

    static void RunTest()
    {
      using (var context = new BreakAwayContext())
      {
        context.Database.Initialize(force: true);

        context.Destinations.Add(new Destination { Name = "Fiji" });
        context.SaveChanges();
      }
      using (var context = new BreakAwayContext())
      {
        if (context.Destinations.Count() == 1)
        {
          Console.WriteLine(
          "Test Passed: 1 destination saved to database");
        }
        else
        {
          Console.WriteLine(
          "Test Failed: {0} destinations saved to database",
          context.Destinations.Count());
        }
      }
    }

    static void GreatBarrierReefTest()
    {
      using (var context = new BreakAwayContext())
      {
        var reef = from destination in context.Destinations
                   where destination.Name == "Great Barrier Reef"
                   select destination;
        if (reef.Count() == 1)
        {
          Console.WriteLine("Test Passed: 1 'Great Barrier Reef' destination found");
        }
        else
        {
          Console.WriteLine(
          "Test Failed: {0} 'Great Barrier Reef' destinations found",
          context.Destinations.Count());
        }
      }
    }

    private static void TargetMultipleProviders()
    {
      // To run this method you will need to remove the
      // configuration in TripConfiguration that configures
      // Trip.Identifier as database generated. This is required
      // because SQL Compact does not support generating GUIDs

      var sql_model = GetBuilder().Build(
        new DbProviderInfo("System.Data.SqlClient", "2008"))
        .Compile();

      var ce_model = GetBuilder().Build(
        new DbProviderInfo("System.Data.SqlServerCe.4.0", "4.0"))
        .Compile();

      var sql_cstr = @"Server=.\SQLEXPRESS;
        Database=DataAccess.BreakAwayContext;
        Trusted_Connection=true";

      using (var connection = new SqlConnection(sql_cstr))
      {
        using (var context =
          new BreakAwayContext(connection, sql_model))
        {
          context.Destinations.Add(new Destination { Name = "Hawaii" });
          context.SaveChanges();
        }
      }

      var ce_cstr = @"Data Source=|DataDirectory|\DataAccess.BreakAwayContext.sdf";
      using (var connection = new SqlCeConnection(ce_cstr))
      {
        using (var context = new BreakAwayContext(connection, ce_model))
        {
          context.Database.Initialize(force: true);
          context.Destinations.Add(new Destination { Name = "Hawaii" });
          context.SaveChanges();
        }
      }
    }

    private static DbModelBuilder GetBuilder()
    {
      var modelBuilder = new DbModelBuilder();
      modelBuilder.Entity<EdmMetadata>().ToTable("EdmMetadata");

      // Entity Type Configuration
      modelBuilder.Configurations.Add(new DestinationConfiguration());
      modelBuilder.Configurations.Add(new LodgingConfiguration());
      modelBuilder.Configurations.Add(new TripConfiguration());
      modelBuilder.Configurations.Add(new PersonConfiguration());
      modelBuilder.Configurations.Add(new InternetSpecialConfiguration());
      modelBuilder.Configurations.Add(new ActivityConfiguration());
      modelBuilder.Configurations.Add(new PersonPhotoConfiguration());
      modelBuilder.Configurations.Add(new ReservationConfiguration());

      // Complex Type Configuration
      modelBuilder.Configurations.Add(new AddressConfiguration());
      modelBuilder.ComplexType<PersonalInfo>();

      return modelBuilder;
    }

    private static void UseEdmMetadataTable()
    {
      using (var context = new BreakAwayContext())
      {
        var modelHash = EdmMetadata.TryGetModelHash(context);
        Console.WriteLine("Current Model Hash: {0}", modelHash);

        var databaseHash = context.Set<EdmMetadata>().Single().ModelHash;
        Console.WriteLine("Current Database Hash: {0}", databaseHash);

        var compatible = context.Database.CompatibleWithModel(throwIfNoMetadata: true);
        Console.WriteLine("Model Compatible With Database?: {0}", compatible);
      }
    }

    private static void UseObjectContext()
    {
      var builder = GetBuilder();

      var cstr = @"Server=.\SQLEXPRESS;
        Database=BreakAwayObjectContext;
        Trusted_Connection=true";

      using (var connection = new SqlConnection(cstr))
      {
        var model = builder.Build(connection).Compile();
        using (var context =
        model.CreateObjectContext<BreakAwayObjectContext>(connection))
        {
          if (!context.DatabaseExists())
          {
            context.CreateDatabase();
          }
          context.Destinations.AddObject(
          new Destination { Name = "Ayers Rock" });
          context.SaveChanges();
        }
      }
    }
  }
}
