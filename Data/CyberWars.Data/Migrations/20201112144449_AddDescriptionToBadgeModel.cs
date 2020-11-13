using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddDescriptionToBadgeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Badges",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AbilityTypeId",
                table: "Abilities",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Badges");

            migrationBuilder.AlterColumn<int>(
                name: "AbilityTypeId",
                table: "Abilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
