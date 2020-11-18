using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class CreateContest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    Percentage = table.Column<int>(nullable: false),
                    RewardMoney = table.Column<int>(nullable: false),
                    RewardExp = table.Column<int>(nullable: false),
                    ConsumeEnergy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerContests",
                columns: table => new
                {
                    PlayerId = table.Column<string>(nullable: false),
                    ContestId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerContests", x => new { x.PlayerId, x.ContestId });
                    table.ForeignKey(
                        name: "FK_PlayerContests_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerContests_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contests_IsDeleted",
                table: "Contests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerContests_ContestId",
                table: "PlayerContests",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerContests_IsDeleted",
                table: "PlayerContests",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerContests");

            migrationBuilder.DropTable(
                name: "Contests");
        }
    }
}
