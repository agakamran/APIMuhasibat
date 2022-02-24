using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class Kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShId",
                table: "Productmasters",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShId",
                table: "Productmasters");
        }
    }
}
