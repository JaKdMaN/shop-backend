using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_backend.Database.Migrations
{
    public partial class fix_address_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HouseAndPpartmentNumber",
                table: "userAddresses",
                newName: "HouseAndApartmentNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HouseAndApartmentNumber",
                table: "userAddresses",
                newName: "HouseAndPpartmentNumber");
        }
    }
}
