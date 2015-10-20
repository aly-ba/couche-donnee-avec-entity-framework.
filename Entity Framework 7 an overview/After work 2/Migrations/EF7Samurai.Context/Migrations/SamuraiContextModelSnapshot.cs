using EF7Samurai.Context;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using System;

namespace EF7Samurai.Context.Migrations
{
    [ContextType(typeof(EF7Samurai.Context.SamuraiContext))]
    public class SamuraiContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
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