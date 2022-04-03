using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class so : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "create",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "reade",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "update",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "delete",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "reade",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "update",
                table: "AspNetRoles");
        }
    }
}
