using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace EF7Samurai.Context.Migrations
{
    public partial class initialModel : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Battle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EndDate = c.DateTime(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false)
                    })
                .PrimaryKey("PK_Battle", t => t.Id);
            
            migrationBuilder.CreateTable("Quote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        SamuraiId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Quote", t => t.Id);
            
            migrationBuilder.CreateTable("Samurai",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Samurai", t => t.Id);
            
            migrationBuilder.AddForeignKey(
                "Quote",
                "FK_Quote_Samurai_SamuraiId",
                new[] { "SamuraiId" },
                "Samurai",
                new[] { "Id" },
                cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("Quote", "FK_Quote_Samurai_SamuraiId");
            
            migrationBuilder.DropTable("Battle");
            
            migrationBuilder.DropTable("Quote");
            
            migrationBuilder.DropTable("Samurai");
        }
    }
}