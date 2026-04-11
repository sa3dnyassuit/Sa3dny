using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sa3dny.Migrations
{
    /// <inheritdoc />
    public partial class AddAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Governorates_GovernorateId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GovernorateId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId_Governorate",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GovernorateId_Governorate",
                table: "Customers",
                column: "GovernorateId_Governorate");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Governorates_GovernorateId_Governorate",
                table: "Customers",
                column: "GovernorateId_Governorate",
                principalTable: "Governorates",
                principalColumn: "Id_Governorate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Governorates_GovernorateId_Governorate",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GovernorateId_Governorate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GovernorateId_Governorate",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GovernorateId",
                table: "Customers",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Governorates_GovernorateId",
                table: "Customers",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id_Governorate",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
