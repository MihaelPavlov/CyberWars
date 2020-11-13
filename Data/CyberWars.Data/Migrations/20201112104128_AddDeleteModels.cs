using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberWars.Data.Migrations
{
    public partial class AddDeleteModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BadgeRequirements_Badges_BadgeId",
                table: "BadgeRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_BadgeRequirements_Requirements_RequirementId",
                table: "BadgeRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Badges_BadgeTypes_BadgeTypeId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_CompleteLectures_Lectures_LectureId",
                table: "CompleteLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTypes_CourseTypeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirements_Jobs_JobId",
                table: "JobRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirements_Requirements_RequirementId",
                table: "JobRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerBadges_Badges_BadgeId",
                table: "PlayerBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerBattles_Battles_BattleId",
                table: "PlayerBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCourses_Courses_CourseId",
                table: "PlayerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerJobs_Jobs_JobId",
                table: "PlayerJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPets_Pets_PetId",
                table: "PlayerPets");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_BadgeTypes_BadgeTypeId",
                table: "Requirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_PlayerBattles_BattleId",
                table: "PlayerBattles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTypes",
                table: "JobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTypes",
                table: "CourseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleRecords",
                table: "BattleRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BadgeTypes",
                table: "BadgeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badges",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "RequirementId",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CourseTypeId",
                table: "CourseTypes");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "BattleRecordId",
                table: "BattleRecords");

            migrationBuilder.DropColumn(
                name: "BadgeTypeId",
                table: "BadgeTypes");

            migrationBuilder.DropColumn(
                name: "BadgeId",
                table: "Badges");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Skills",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMoney",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Requirements",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Requirements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Requirements",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Requirements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Requirements",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerPets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerPets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerJobs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerJobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerCourses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerCourses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BattleId1",
                table: "PlayerBattles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerBattles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerBattles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerBadges",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerBadges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlayerAbilities",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlayerAbilities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pets",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Pets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lectures",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Lectures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Lectures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "JobTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "JobTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "JobTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "JobTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Jobs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Jobs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Jobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "JobRequirements",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobRequirements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Foods",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Foods",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Foods",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Foods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Foods",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CourseTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CourseTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CourseTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CourseTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Courses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Courses",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CompleteLectures",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CompleteLectures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Battles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Battles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Battles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Battles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Battles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "BattleRecords",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BattleRecords",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "BattleRecords",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BattleRecords",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "BattleRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BadgeTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BadgeTypes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "BadgeTypes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BadgeTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "BadgeTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Badges",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Badges",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Badges",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Badges",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Badges",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "BadgeRequirements",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BadgeRequirements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AbilityTypeId",
                table: "Abilities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTypes",
                table: "JobTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTypes",
                table: "CourseTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleRecords",
                table: "BattleRecords",
                columns: new[] { "PlayerId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BadgeTypes",
                table: "BadgeTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badges",
                table: "Badges",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AbilityTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirements_IsDeleted",
                table: "Requirements",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPets_IsDeleted",
                table: "PlayerPets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerJobs_IsDeleted",
                table: "PlayerJobs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCourses_IsDeleted",
                table: "PlayerCourses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBattles_BattleId1",
                table: "PlayerBattles",
                column: "BattleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBattles_IsDeleted",
                table: "PlayerBattles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBadges_IsDeleted",
                table: "PlayerBadges",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAbilities_IsDeleted",
                table: "PlayerAbilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_IsDeleted",
                table: "Pets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_IsDeleted",
                table: "Lectures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_IsDeleted",
                table: "JobTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IsDeleted",
                table: "Jobs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequirements_IsDeleted",
                table: "JobRequirements",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_IsDeleted",
                table: "Foods",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTypes_IsDeleted",
                table: "CourseTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CompleteLectures_IsDeleted",
                table: "CompleteLectures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_IsDeleted",
                table: "Battles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BattleRecords_IsDeleted",
                table: "BattleRecords",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeTypes_IsDeleted",
                table: "BadgeTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_IsDeleted",
                table: "Badges",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BadgeRequirements_IsDeleted",
                table: "BadgeRequirements",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_AbilityTypeId",
                table: "Abilities",
                column: "AbilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityTypes_IsDeleted",
                table: "AbilityTypes",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_AbilityTypes_AbilityTypeId",
                table: "Abilities",
                column: "AbilityTypeId",
                principalTable: "AbilityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BadgeRequirements_Badges_BadgeId",
                table: "BadgeRequirements",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BadgeRequirements_Requirements_RequirementId",
                table: "BadgeRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_BadgeTypes_BadgeTypeId",
                table: "Badges",
                column: "BadgeTypeId",
                principalTable: "BadgeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompleteLectures_Lectures_LectureId",
                table: "CompleteLectures",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTypes_CourseTypeId",
                table: "Courses",
                column: "CourseTypeId",
                principalTable: "CourseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirements_Jobs_JobId",
                table: "JobRequirements",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirements_Requirements_RequirementId",
                table: "JobRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                table: "Jobs",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerBadges_Badges_BadgeId",
                table: "PlayerBadges",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerBattles_Battles_BattleId1",
                table: "PlayerBattles",
                column: "BattleId1",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCourses_Courses_CourseId",
                table: "PlayerCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerJobs_Jobs_JobId",
                table: "PlayerJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPets_Pets_PetId",
                table: "PlayerPets",
                column: "PetId",
                principalTable: "Pets",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_AbilityTypes_AbilityTypeId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_BadgeRequirements_Badges_BadgeId",
                table: "BadgeRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_BadgeRequirements_Requirements_RequirementId",
                table: "BadgeRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Badges_BadgeTypes_BadgeTypeId",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_CompleteLectures_Lectures_LectureId",
                table: "CompleteLectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseTypes_CourseTypeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirements_Jobs_JobId",
                table: "JobRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_JobRequirements_Requirements_RequirementId",
                table: "JobRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerBadges_Badges_BadgeId",
                table: "PlayerBadges");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerBattles_Battles_BattleId1",
                table: "PlayerBattles");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerCourses_Courses_CourseId",
                table: "PlayerCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerJobs_Jobs_JobId",
                table: "PlayerJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerPets_Pets_PetId",
                table: "PlayerPets");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirements_BadgeTypes_BadgeTypeId",
                table: "Requirements");

            migrationBuilder.DropTable(
                name: "AbilityTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_Requirements_IsDeleted",
                table: "Requirements");

            migrationBuilder.DropIndex(
                name: "IX_PlayerPets_IsDeleted",
                table: "PlayerPets");

            migrationBuilder.DropIndex(
                name: "IX_PlayerJobs_IsDeleted",
                table: "PlayerJobs");

            migrationBuilder.DropIndex(
                name: "IX_PlayerCourses_IsDeleted",
                table: "PlayerCourses");

            migrationBuilder.DropIndex(
                name: "IX_PlayerBattles_BattleId1",
                table: "PlayerBattles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerBattles_IsDeleted",
                table: "PlayerBattles");

            migrationBuilder.DropIndex(
                name: "IX_PlayerBadges_IsDeleted",
                table: "PlayerBadges");

            migrationBuilder.DropIndex(
                name: "IX_PlayerAbilities_IsDeleted",
                table: "PlayerAbilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_IsDeleted",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_IsDeleted",
                table: "Lectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTypes",
                table: "JobTypes");

            migrationBuilder.DropIndex(
                name: "IX_JobTypes_IsDeleted",
                table: "JobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_IsDeleted",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_JobRequirements_IsDeleted",
                table: "JobRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_IsDeleted",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTypes",
                table: "CourseTypes");

            migrationBuilder.DropIndex(
                name: "IX_CourseTypes_IsDeleted",
                table: "CourseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_IsDeleted",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CompleteLectures_IsDeleted",
                table: "CompleteLectures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.DropIndex(
                name: "IX_Battles_IsDeleted",
                table: "Battles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BattleRecords",
                table: "BattleRecords");

            migrationBuilder.DropIndex(
                name: "IX_BattleRecords_IsDeleted",
                table: "BattleRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BadgeTypes",
                table: "BadgeTypes");

            migrationBuilder.DropIndex(
                name: "IX_BadgeTypes_IsDeleted",
                table: "BadgeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badges",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_Badges_IsDeleted",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_BadgeRequirements_IsDeleted",
                table: "BadgeRequirements");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_AbilityTypeId",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "StartMoney",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Requirements");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerPets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerPets");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerJobs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerJobs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerCourses");

            migrationBuilder.DropColumn(
                name: "BattleId1",
                table: "PlayerBattles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerBattles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerBattles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerBadges");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerBadges");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlayerAbilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlayerAbilities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "JobRequirements");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobRequirements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CourseTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CourseTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CourseTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CourseTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CompleteLectures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CompleteLectures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BattleRecords");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BattleRecords");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "BattleRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BattleRecords");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "BattleRecords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BadgeTypes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BadgeTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "BadgeTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BadgeTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "BadgeTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Badges");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "BadgeRequirements");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BadgeRequirements");

            migrationBuilder.DropColumn(
                name: "AbilityTypeId",
                table: "Abilities");

            migrationBuilder.AddColumn<int>(
                name: "RequirementId",
                table: "Requirements",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LectureId",
                table: "Lectures",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "JobTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseTypeId",
                table: "CourseTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Battles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BattleRecordId",
                table: "BattleRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BadgeTypeId",
                table: "BadgeTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BadgeId",
                table: "Badges",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requirements",
                table: "Requirements",
                column: "RequirementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lectures",
                table: "Lectures",
                column: "LectureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTypes",
                table: "JobTypes",
                column: "JobTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "FoodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTypes",
                table: "CourseTypes",
                column: "CourseTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "BattleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BattleRecords",
                table: "BattleRecords",
                columns: new[] { "PlayerId", "BattleRecordId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BadgeTypes",
                table: "BadgeTypes",
                column: "BadgeTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badges",
                table: "Badges",
                column: "BadgeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBattles_BattleId",
                table: "PlayerBattles",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BadgeRequirements_Badges_BadgeId",
                table: "BadgeRequirements",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BadgeRequirements_Requirements_RequirementId",
                table: "BadgeRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "RequirementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_BadgeTypes_BadgeTypeId",
                table: "Badges",
                column: "BadgeTypeId",
                principalTable: "BadgeTypes",
                principalColumn: "BadgeTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompleteLectures_Lectures_LectureId",
                table: "CompleteLectures",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "LectureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseTypes_CourseTypeId",
                table: "Courses",
                column: "CourseTypeId",
                principalTable: "CourseTypes",
                principalColumn: "CourseTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirements_Jobs_JobId",
                table: "JobRequirements",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobRequirements_Requirements_RequirementId",
                table: "JobRequirements",
                column: "RequirementId",
                principalTable: "Requirements",
                principalColumn: "RequirementId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobTypes_JobTypeId",
                table: "Jobs",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "JobTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Courses_CourseId",
                table: "Lectures",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerBadges_Badges_BadgeId",
                table: "PlayerBadges",
                column: "BadgeId",
                principalTable: "Badges",
                principalColumn: "BadgeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerBattles_Battles_BattleId",
                table: "PlayerBattles",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerCourses_Courses_CourseId",
                table: "PlayerCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerJobs_Jobs_JobId",
                table: "PlayerJobs",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerPets_Pets_PetId",
                table: "PlayerPets",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirements_BadgeTypes_BadgeTypeId",
                table: "Requirements",
                column: "BadgeTypeId",
                principalTable: "BadgeTypes",
                principalColumn: "BadgeTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
