using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixStolenMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StolenМoney",
                table: "BattleRecords");

            migrationBuilder.AddColumn<int>(
                name: "StolenMoney",
                table: "BattleRecords",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StolenMoney",
                table: "BattleRecords");

            migrationBuilder.AddColumn<int>(
                name: "StolenМoney",
                table: "BattleRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
