public class Capture {
    /// <summary>
    /// Get and Set Capture's Unique Identifier.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Get and Set Capture's Operating System.
    /// </summary>
    public virtual OperatingSystem OperatingSystem { get; set; }
}

public class OperatingSystem {
    /// <summary>
    /// Operating System's Unique Identifier.
    /// </summary>
    public int Id { get; set; }
}

///////////////////////////////////////////////////////////////////////
internal sealed class EntityCaptureConfiguration : EntityTypeConfiguration<Capture> {
    /// <summary>
    /// Create an Entity Capture Configuration.
    /// </summary>
    public EntityCaptureConfiguration() {
        this.ToTable("Capture");
        this.HasKey(m => m.Id);

        this.Property(m => m.Id).HasColumnName("Id");

        this.HasRequired(m => m.OperatingSystem).WithRequiredDependent().Map(m => m.MapKey("OperatingSystemId"));
    }
}
///////////////////////////////////////////////////////////////////////////
public sealed class EntityDefaultContext : DbContext {    
    /// <summary>
    /// Model Creating Event Handler.
    /// </summary>
    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        var entityCaptureConfiguration = new EntityCaptureConfiguration();
        var entityOperatingSystemConfiguration = new EntityOperatingSystemConfiguration();

        modelBuilder.Configurations.Add(entityOperatingSystemConfiguration);
        modelBuilder.Configurations.Add(entityCaptureConfiguration);

        this.Configuration.LazyLoadingEnabled = false;
        this.Configuration.ProxyCreationEnabled = false;
    }
}
