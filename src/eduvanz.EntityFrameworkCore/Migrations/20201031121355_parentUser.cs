using Microsoft.EntityFrameworkCore.Migrations;

namespace eduvanz.Migrations
{
    public partial class parentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ParentUser",
                table: "MeetupEvents",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentUser",
                table: "MeetupEvents");
        }
    }
}
