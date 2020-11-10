using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class FixSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSkills_Skills_SkillId",
                table: "PlayerSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Skills",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Skills",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Skills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerSkills",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerSkills",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsDeleted",
                table: "Skills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_IsDeleted",
                table: "PlayerSkills",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSkills_Skills_SkillId",
                table: "PlayerSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSkills_Skills_SkillId",
                table: "PlayerSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_IsDeleted",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSkills_IsDeleted",
                table: "PlayerSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerSkills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerSkills");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSkills_Skills_SkillId",
                table: "PlayerSkills",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
