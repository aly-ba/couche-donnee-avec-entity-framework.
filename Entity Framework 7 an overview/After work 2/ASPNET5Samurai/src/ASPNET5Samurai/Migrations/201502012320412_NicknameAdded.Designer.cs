using ASPNET5Samurai.DataModel;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using System;

namespace ASPNET5Samurai.Migrations
{
    [ContextType(typeof(ASPNET5Samurai.DataModel.SamuraiContext))]
    public partial class NicknameAdded : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201502012320412_NicknameAdded";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta2-11909";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("ASPNET5Samurai.Models.Samurai", b =>
                    {
                        b.Property<int>("Id")
                            .GenerateValueOnAdd();
                        b.Property<bool>("Living");
                        b.Property<string>("Name");
                        b.Property<string>("NickName");
                        b.Key("Id");
                    });
                
                return builder.Model;
            }
        }
    }
}