using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixLectureAndCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeMinutes",
                table: "Lectures");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceToComplete",
                table: "Lectures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelToUnlock",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExperienceToComplete",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "LevelToUnlock",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TimeMinutes",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
