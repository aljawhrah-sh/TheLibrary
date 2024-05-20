using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheLibrary.Migrations
{
    public partial class updatefristNameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FistName",
                table: "Authors",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "FistName");
        }
    }
}
