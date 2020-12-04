using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixResetPlayerStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnergyResetStart",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "IsHealthResetStart",
                table: "Players");

            migrationBuilder.AddColumn<bool>(
                name: "IsStatsResetStart",
                table: "Players",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStatsResetStart",
                table: "Players");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnergyResetStart",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHealthResetStart",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
