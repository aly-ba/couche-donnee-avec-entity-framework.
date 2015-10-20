using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace ASPNET5Samurai.Migrations
{
    public partial class NicknameAdded : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn("Samurai", "NickName", c => c.String());
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Samurai", "NickName");
        }
    }
}