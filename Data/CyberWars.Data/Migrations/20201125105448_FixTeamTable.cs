using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_TeamsT_TeamId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamsT_AspNetUsers_UserId1",
                table: "TeamsT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamsT",
                table: "TeamsT");

            migrationBuilder.RenameTable(
                name: "TeamsT",
                newName: "Teams");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsT_UserId1",
                table: "Teams",
                newName: "IX_Teams_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_TeamsT_IsDeleted",
                table: "Teams",
                newName: "IX_Teams_IsDeleted");

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_Teams_TeamId",
                table: "TeamPlayers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_AspNetUsers_UserId1",
                table: "Teams",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamPlayers_Teams_TeamId",
                table: "TeamPlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_AspNetUsers_UserId1",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamsT");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_UserId1",
                table: "TeamsT",
                newName: "IX_TeamsT_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_IsDeleted",
                table: "TeamsT",
                newName: "IX_TeamsT_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamsT",
                table: "TeamsT",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamPlayers_TeamsT_TeamId",
                table: "TeamPlayers",
                column: "TeamId",
                principalTable: "TeamsT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamsT_AspNetUsers_UserId1",
                table: "TeamsT",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
