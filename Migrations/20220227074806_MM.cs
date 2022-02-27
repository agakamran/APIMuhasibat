using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMuhasibat.Migrations
{
    public partial class MM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hesabs_Productmasters_ProductmasterPmasId",
                table: "Hesabs");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesabs_Productmasters_ProductmasterPmasId1",
                table: "Hesabs");

            migrationBuilder.DropIndex(
                name: "IX_Hesabs_ProductmasterPmasId",
                table: "Hesabs");

            migrationBuilder.DropIndex(
                name: "IX_Hesabs_ProductmasterPmasId1",
                table: "Hesabs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Qrups");

            migrationBuilder.DropColumn(
                name: "DhesId",
                table: "Productmasters");

            migrationBuilder.DropColumn(
                name: "ProductmasterPmasId",
                table: "Hesabs");

            migrationBuilder.DropColumn(
                name: "ProductmasterPmasId1",
                table: "Hesabs");

            migrationBuilder.RenameColumn(
                name: "KhesId",
                table: "Productmasters",
                newName: "AnbId");

            migrationBuilder.AddColumn<string>(
                name: "DhesId",
                table: "Qrups",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KhesId",
                table: "Qrups",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "anbars",
                columns: table => new
                {
                    AnbId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Anbarname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductmasterPmasId = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anbars", x => x.AnbId);
                    table.ForeignKey(
                        name: "FK_anbars_Productmasters_ProductmasterPmasId",
                        column: x => x.ProductmasterPmasId,
                        principalTable: "Productmasters",
                        principalColumn: "PmasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_anbars_ProductmasterPmasId",
                table: "anbars",
                column: "ProductmasterPmasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anbars");

            migrationBuilder.DropColumn(
                name: "DhesId",
                table: "Qrups");

            migrationBuilder.DropColumn(
                name: "KhesId",
                table: "Qrups");

            migrationBuilder.RenameColumn(
                name: "AnbId",
                table: "Productmasters",
                newName: "KhesId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Qrups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DhesId",
                table: "Productmasters",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductmasterPmasId",
                table: "Hesabs",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductmasterPmasId1",
                table: "Hesabs",
                type: "nvarchar(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hesabs_ProductmasterPmasId",
                table: "Hesabs",
                column: "ProductmasterPmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesabs_ProductmasterPmasId1",
                table: "Hesabs",
                column: "ProductmasterPmasId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Hesabs_Productmasters_ProductmasterPmasId",
                table: "Hesabs",
                column: "ProductmasterPmasId",
                principalTable: "Productmasters",
                principalColumn: "PmasId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hesabs_Productmasters_ProductmasterPmasId1",
                table: "Hesabs",
                column: "ProductmasterPmasId1",
                principalTable: "Productmasters",
                principalColumn: "PmasId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
