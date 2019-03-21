using Microsoft.EntityFrameworkCore.Migrations;

namespace Kcs.DataAccess.Migrations
{
    public partial class dbcreatefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Persons",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Persons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);
        }
    }
}
