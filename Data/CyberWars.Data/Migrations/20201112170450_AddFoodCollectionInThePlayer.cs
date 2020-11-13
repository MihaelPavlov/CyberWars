using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddFoodCollectionInThePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "Foods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PlayerId",
                table: "Foods",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Players_PlayerId",
                table: "Foods",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Players_PlayerId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_PlayerId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Foods");
        }
    }
}
