using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixAbilitiesAndBadges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_BadgeTypes_BadgeTypeId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_BadgeTypes_BadgeTypeId",
                table: "Requirements");

            migrationBuilder.DropTable(
                name: "BadgeTypes");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_BadgeTypeId",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Badges_BadgeTypeId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "BadgeTypeId",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "BadgeTypeId",
                table: "Badges");

            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Requirements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Badges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_AbilityId",
                table: "Requirements",
                column: "AbilityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_Abilities_AbilityId",
                table: "Requirements",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Abilities_AbilityId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_Abilities_AbilityId",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_AbilityId",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Badges_AbilityId",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Badges");

            migrationBuilder.AddColumn<int>(
                name: "BadgeTypeId",
                table: "Requirements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BadgeTypeId",
                table: "Badges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BadgeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BadgeTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_BadgeTypeId",
                table: "Requirements",
                column: "BadgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_BadgeTypeId",
                table: "Badges",
                column: "BadgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeTypes_IsDeleted",
                table: "BadgeTypes",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_BadgeTypes_BadgeTypeId",
                table: "Badges",
                column: "BadgeTypeId",
                principalTable: "BadgeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_BadgeTypes_BadgeTypeId",
                table: "Requirements",
                column: "BadgeTypeId",
                principalTable: "BadgeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
