using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddPlayerMaxHealthAndEnergy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerBattles");

            migrationBuilder.AddColumn<int>(
                name: "MaxEnergy",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealth",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxEnergy",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MaxHealth",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PlayerBattles",
                columns: table => new
                {
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BattleId = table.Column<int>(type: "int", nullable: false),
                    BattleId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBattles", x => new { x.PlayerId, x.BattleId });
                    table.ForeignKey(
                        name: "FK_PlayerBattles_Battles_BattleId1",
                        column: x => x.BattleId1,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerBattles_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBattles_BattleId1",
                table: "PlayerBattles",
                column: "BattleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBattles_IsDeleted",
                table: "PlayerBattles",
                column: "IsDeleted");
        }
    }
}
