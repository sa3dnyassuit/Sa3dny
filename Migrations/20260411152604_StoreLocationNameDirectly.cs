
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sa3dny.Migrations
{
    /// <inheritdoc />
    public partial class StoreLocationNameDirectly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_LocationId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LocationId_Location",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId_Location",
                table: "Customers",
                column: "LocationId_Location");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Locations_LocationId_Location",
                table: "Customers",
                column: "LocationId_Location",
                principalTable: "Locations",
                principalColumn: "Id_Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Locations_LocationId_Location",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocationId_Location",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LocationId_Location",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_LocationId",
                table: "Providers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocationId",
                table: "Customers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Locations_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id_Location",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id_Location",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
