using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixPlayerFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "PlayerFoods",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    FoodId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerFoods", x => new { x.PlayerId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_PlayerFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerFoods_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFoods_FoodId",
                table: "PlayerFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerFoods_IsDeleted",
                table: "PlayerFoods",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerFoods");

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "Foods",
                type: "nvarchar(450)",
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
    }
}
