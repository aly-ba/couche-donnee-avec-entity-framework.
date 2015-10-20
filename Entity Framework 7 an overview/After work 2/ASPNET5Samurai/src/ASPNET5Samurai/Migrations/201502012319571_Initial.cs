using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace ASPNET5Samurai.Migrations
{
    public partial class Initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Samurai",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Living = c.Boolean(nullable: false),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Samurai", t => t.Id);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Samurai");
        }
    }
}