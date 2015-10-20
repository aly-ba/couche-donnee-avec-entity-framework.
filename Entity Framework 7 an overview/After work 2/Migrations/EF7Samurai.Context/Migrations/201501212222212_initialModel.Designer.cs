using EF7Samurai.Context;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;

namespace EF7Samurai.Context.Migrations
{
    [ContextType(typeof(EF7Samurai.Context.SamuraiContext))]
    public partial class initialModel : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201501212222212_initialModel";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12013";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("EF7Samurai.Domain.Battle", b =>
                    {
                        b.Property<DateTime>("EndDate");
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Property<DateTime>("StartDate");
                        b.Key("Id");
                    });
                
                builder.Entity("EF7Samurai.Domain.Quote", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<int>("SamuraiId");
                        b.Property<string>("Text");
                        b.Key("Id");
                    });
                
                builder.Entity("EF7Samurai.Domain.Samurai", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("EF7Samurai.Domain.Quote", b =>
                    {
                        b.ForeignKey("EF7Samurai.Domain.Samurai", "SamuraiId");
                    });
                
                return builder.Model;
            }
        }
    }
}