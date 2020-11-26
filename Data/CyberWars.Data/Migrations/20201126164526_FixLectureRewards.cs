using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixLectureRewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardAbilityPoints",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "RewardSkill",
                table: "Lectures");

            migrationBuilder.AddColumn<string>(
                name: "RewardAbilityName",
                table: "Lectures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RewardAbilityName",
                table: "Lectures");

            migrationBuilder.AddColumn<int>(
                name: "RewardAbilityPoints",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RewardSkill",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
