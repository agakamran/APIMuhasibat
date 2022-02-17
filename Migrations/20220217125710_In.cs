using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class In : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmdetId",
                table: "Productdetals");

            migrationBuilder.RenameColumn(
                name: "EmdetId",
                table: "Productmasters",
                newName: "OpdetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpdetId",
                table: "Productmasters",
                newName: "EmdetId");

            migrationBuilder.AddColumn<string>(
                name: "EmdetId",
                table: "Productdetals",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);
        }
    }
}
