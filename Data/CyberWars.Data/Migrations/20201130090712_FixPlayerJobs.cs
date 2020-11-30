using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixPlayerJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfComplete",
                table: "PlayerJobs");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "PlayerJobs");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDatePlayed",
                table: "PlayerJobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimesComplete",
                table: "PlayerJobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDatePlayed",
                table: "PlayerJobs");

            migrationBuilder.DropColumn(
                name: "TimesComplete",
                table: "PlayerJobs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfComplete",
                table: "PlayerJobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "PlayerJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
