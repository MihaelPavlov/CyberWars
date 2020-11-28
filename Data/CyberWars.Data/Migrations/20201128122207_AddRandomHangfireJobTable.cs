using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddRandomHangfireJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomHangfireJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomHangfireJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RandomHangfireJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RandomHangfireJobs_IsDeleted",
                table: "RandomHangfireJobs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RandomHangfireJobs_JobId",
                table: "RandomHangfireJobs",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomHangfireJobs");
        }
    }
}
