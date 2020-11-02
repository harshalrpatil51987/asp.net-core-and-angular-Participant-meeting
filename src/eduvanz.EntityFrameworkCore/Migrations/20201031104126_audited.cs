using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eduvanz.Migrations
{
    public partial class audited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MeetupEvents");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MeetupEvents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MeetupEvents",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MeetupEvents",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MeetupEvents",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MeetupEvents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MeetupEvents",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MeetupEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MeetupEvents");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MeetupEvents");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MeetupEvents");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MeetupEvents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MeetupEvents");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MeetupEvents");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MeetupEvents");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MeetupEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
