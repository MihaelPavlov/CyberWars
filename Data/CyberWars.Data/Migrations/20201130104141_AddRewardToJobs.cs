using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddRewardToJobs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RewardAbilityNames",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RewardExp",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RewardMoney",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardAbilityNames",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "RewardExp",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "RewardMoney",
                table: "Jobs");
        }
    }
}
