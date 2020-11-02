using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eduvanz.Migrations
{
    public partial class meetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetupEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Profession = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 500, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 500, nullable: true),
                    Country = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Pincode = table.Column<string>(maxLength: 6, nullable: false),
                    TotalGuest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetupEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetupEvents");
        }
    }
}
