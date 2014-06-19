using System.Data.EntityClient;
using System.Data.Objects;
using Model;

namespace DataAccess
{
  public class BreakAwayObjectContext : ObjectContext
  {
    public BreakAwayObjectContext(EntityConnection connection)
      : base(connection)
    {
      this.Destinations = this.CreateObjectSet<Destination>();
      this.Lodgings = this.CreateObjectSet<Lodging>();
      this.Trips = this.CreateObjectSet<Trip>();
      this.People = this.CreateObjectSet<Person>();
      this.PersonPhotos = this.CreateObjectSet<PersonPhoto>();
    }

    public ObjectSet<Destination> Destinations { get; private set; }
    public ObjectSet<Lodging> Lodgings { get; private set; }
    public ObjectSet<Trip> Trips { get; private set; }
    public ObjectSet<Person> People { get; private set; }
    public ObjectSet<PersonPhoto> PersonPhotos { get; private set; }
  }
}