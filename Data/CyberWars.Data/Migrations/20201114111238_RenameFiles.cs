using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class RenameFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Abilities_AbilityId",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_Badges_AbilityId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Badges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Badges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Badges_AbilityId",
                table: "Badges",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Abilities_AbilityId",
                table: "Badges",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
