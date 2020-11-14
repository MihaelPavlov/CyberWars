using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixAbility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Abilities_AbilityId",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_AbilityId",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Requirements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Requirements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_AbilityId",
                table: "Requirements",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Abilities_AbilityId",
                table: "Requirements",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
