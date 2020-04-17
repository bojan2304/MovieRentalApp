using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentalApp.Migrations
{
    public partial class ChangeMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Customers_CustomerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CustomerId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "BorrowerId",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BorrowerId",
                table: "Movies",
                column: "BorrowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Customers_BorrowerId",
                table: "Movies",
                column: "BorrowerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Customers_BorrowerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_BorrowerId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BorrowerId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CustomerId",
                table: "Movies",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Customers_CustomerId",
                table: "Movies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
