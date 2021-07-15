using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffee_Shop.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblSales_TblProducts_ProductId",
                table: "TblSales");

            migrationBuilder.DropIndex(
                name: "IX_TblSales_ProductId",
                table: "TblSales");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "TblSales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalesTotal",
                table: "TblPays",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "TblSales");

            migrationBuilder.DropColumn(
                name: "SalesTotal",
                table: "TblPays");

            migrationBuilder.CreateIndex(
                name: "IX_TblSales_ProductId",
                table: "TblSales",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblSales_TblProducts_ProductId",
                table: "TblSales",
                column: "ProductId",
                principalTable: "TblProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
