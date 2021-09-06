using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryShop.DataAccess.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShoppingCartId",
                table: "PaymentDetails",
                newName: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "PaymentDetails",
                newName: "ShoppingCartId");
        }
    }
}
