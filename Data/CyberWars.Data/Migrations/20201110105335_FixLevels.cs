using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Levels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Levels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Levels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Levels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Levels_IsDeleted",
                table: "Levels",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Levels_IsDeleted",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Levels");
        }
    }
}
