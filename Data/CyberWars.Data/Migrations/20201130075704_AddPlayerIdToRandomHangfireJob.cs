using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddPlayerIdToRandomHangfireJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "RandomHangfireJobs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RandomHangfireJobs_PlayerId",
                table: "RandomHangfireJobs",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RandomHangfireJobs_Players_PlayerId",
                table: "RandomHangfireJobs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RandomHangfireJobs_Players_PlayerId",
                table: "RandomHangfireJobs");

            migrationBuilder.DropIndex(
                name: "IX_RandomHangfireJobs_PlayerId",
                table: "RandomHangfireJobs");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "RandomHangfireJobs");
        }
    }
}
