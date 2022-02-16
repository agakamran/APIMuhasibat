using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class k : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Aksizderecesi",
                table: "Emeliyyatdets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Barkod",
                table: "Emeliyyatdets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maladi",
                table: "Emeliyyatdets",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Yolvergisi",
                table: "Emeliyyatdets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aksizderecesi",
                table: "Emeliyyatdets");

            migrationBuilder.DropColumn(
                name: "Barkod",
                table: "Emeliyyatdets");

            migrationBuilder.DropColumn(
                name: "Maladi",
                table: "Emeliyyatdets");

            migrationBuilder.DropColumn(
                name: "Yolvergisi",
                table: "Emeliyyatdets");
        }
    }
}
