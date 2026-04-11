using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sa3dny.Migrations
{
    /// <inheritdoc />
    public partial class AddProvider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Services_Providers_provider_id",
                table: "Provider_Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Services_Services_service_id",
                table: "Provider_Services");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_Providers_Provider_Id",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Address_Customer",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "name_Provider",
                table: "Providers",
                newName: "ProfessionalLicensePath");

            migrationBuilder.RenameColumn(
                name: "address_Provider",
                table: "Providers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "phone_Customer",
                table: "Customers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Name_Customer",
                table: "Customers",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ServiceCategoryId_Category",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "national_id_Provider",
                table: "Providers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalIdImagePath",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServiceCategoryId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId_Governorate",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Governorates",
                columns: table => new
                {
                    Id_Governorate = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Governorate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id_Governorate);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    Id_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.Id_Category);
                });

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "Id_Governorate", "Name_Governorate" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Giza" },
                    { 3, "Alexandria" },
                    { 4, "Assiut" },
                    { 5, "Aswan" },
                    { 6, "Luxor" },
                    { 7, "Sohag" },
                    { 8, "Qena" },
                    { 9, "Minya" },
                    { 10, "Beni Suef" },
                    { 11, "Fayoum" },
                    { 12, "Dakahlia" },
                    { 13, "Sharqia" },
                    { 14, "Gharbia" },
                    { 15, "Monufia" },
                    { 16, "Qalyubia" },
                    { 17, "Kafr El Sheikh" },
                    { 18, "Beheira" },
                    { 19, "Damietta" },
                    { 20, "Port Said" },
                    { 21, "Ismailia" },
                    { 22, "Suez" },
                    { 23, "North Sinai" },
                    { 24, "South Sinai" },
                    { 25, "Red Sea" },
                    { 26, "New Valley" },
                    { 27, "Matruh" }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 1,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 2,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 3,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 4,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 5,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 6,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 7,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id_Location",
                keyValue: 8,
                column: "GovernorateId_Governorate",
                value: null);

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "Id_Category", "Name_Category" },
                values: new object[,]
                {
                    { 1, "Home Services" },
                    { 2, "Educational Services" },
                    { 3, "Healthcare Services" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "service_id", "Description", "Min_price", "ServiceCategoryId_Category", "service_name" },
                values: new object[,]
                {
                    { 1, "Home cleaning service", 0m, null, "Cleaning" },
                    { 2, "Plumbing service", 0m, null, "Plumbing" },
                    { 3, "Electrical service", 0m, null, "Electricity" },
                    { 4, "Carpentry service", 0m, null, "Carpentry" },
                    { 5, "Word and report writing", 0m, null, "Word / Report" },
                    { 6, "Presentation design", 0m, null, "Presentation" },
                    { 7, "Excel sheets service", 0m, null, "Excel" },
                    { 8, "CV writing service", 0m, null, "CV Creation" },
                    { 9, "Nursing at home", 0m, null, "Home Nursing" },
                    { 10, "Doctor home visit", 0m, null, "Doctor Visit" },
                    { 11, "Injection at home", 0m, null, "Injection Service" },
                    { 12, "Medical follow-up", 0m, null, "Follow-up" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceCategoryId_Category",
                table: "Services",
                column: "ServiceCategoryId_Category");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_GovernorateId",
                table: "Providers",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_LocationId",
                table: "Providers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ServiceCategoryId",
                table: "Providers",
                column: "ServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ServiceId",
                table: "Providers",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_GovernorateId_Governorate",
                table: "Locations",
                column: "GovernorateId_Governorate");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Governorates_GovernorateId_Governorate",
                table: "Locations",
                column: "GovernorateId_Governorate",
                principalTable: "Governorates",
                principalColumn: "Id_Governorate");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Services_Providers_provider_id",
                table: "Provider_Services",
                column: "provider_id",
                principalTable: "Providers",
                principalColumn: "provider_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Services_Services_service_id",
                table: "Provider_Services",
                column: "service_id",
                principalTable: "Services",
                principalColumn: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Governorates_GovernorateId",
                table: "Providers",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id_Governorate",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id_Location",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_ServiceCategories_ServiceCategoryId",
                table: "Providers",
                column: "ServiceCategoryId",
                principalTable: "ServiceCategories",
                principalColumn: "Id_Category",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Services_ServiceId",
                table: "Providers",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "service_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_Providers_Provider_Id",
                table: "reviews",
                column: "Provider_Id",
                principalTable: "Providers",
                principalColumn: "provider_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceCategories_ServiceCategoryId_Category",
                table: "Services",
                column: "ServiceCategoryId_Category",
                principalTable: "ServiceCategories",
                principalColumn: "Id_Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Governorates_GovernorateId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Governorates_GovernorateId_Governorate",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Services_Providers_provider_id",
                table: "Provider_Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Provider_Services_Services_service_id",
                table: "Provider_Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Governorates_GovernorateId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Locations_LocationId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_ServiceCategories_ServiceCategoryId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Services_ServiceId",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_Providers_Provider_Id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceCategories_ServiceCategoryId_Category",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Governorates");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceCategoryId_Category",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Providers_GovernorateId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_LocationId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ServiceCategoryId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ServiceId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Locations_GovernorateId_Governorate",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GovernorateId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "service_id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId_Category",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "NationalIdImagePath",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ServiceCategoryId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "GovernorateId_Governorate",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ProfessionalLicensePath",
                table: "Providers",
                newName: "name_Provider");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Providers",
                newName: "address_Provider");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Customers",
                newName: "phone_Customer");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Name_Customer");

            migrationBuilder.AlterColumn<int>(
                name: "national_id_Provider",
                table: "Providers",
                type: "int",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "Providers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Customer",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Services_Providers_provider_id",
                table: "Provider_Services",
                column: "provider_id",
                principalTable: "Providers",
                principalColumn: "provider_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Provider_Services_Services_service_id",
                table: "Provider_Services",
                column: "service_id",
                principalTable: "Services",
                principalColumn: "service_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_Providers_Provider_Id",
                table: "reviews",
                column: "Provider_Id",
                principalTable: "Providers",
                principalColumn: "provider_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
