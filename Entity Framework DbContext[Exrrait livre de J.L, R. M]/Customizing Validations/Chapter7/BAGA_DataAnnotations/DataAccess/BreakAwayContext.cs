using System.Data.Entity;
using Model;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
  public class BreakAwayContext : DbContext
  {
    public BreakAwayContext()
    { }

    public BreakAwayContext(string databaseName)
      : base(databaseName)
    { }

    public BreakAwayContext(DbConnection connection)
      : base(connection, contextOwnsConnection: false)
    { }

    public BreakAwayContext(DbConnection connection, DbCompiledModel model)
      : base(connection, model, contextOwnsConnection: false)
    { }

    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Lodging> Lodgings { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      Console.WriteLine("OnModelCreating called!");
    }
  }
}