using Microsoft.EntityFrameworkCore.Migrations;

namespace GDPAPI.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Drivers_DriverIdentification",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_DriverIdentification",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DriverIdentification",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Celphone",
                table: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Drivers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "vehicleIdentification",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_vehicleIdentification",
                table: "Drivers",
                column: "vehicleIdentification",
                unique: true,
                filter: "[vehicleIdentification] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Vehicles_vehicleIdentification",
                table: "Drivers",
                column: "vehicleIdentification",
                principalTable: "Vehicles",
                principalColumn: "Plaque",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Vehicles_vehicleIdentification",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_vehicleIdentification",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "vehicleIdentification",
                table: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "DriverIdentification",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celphone",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverIdentification",
                table: "Vehicles",
                column: "DriverIdentification");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Drivers_DriverIdentification",
                table: "Vehicles",
                column: "DriverIdentification",
                principalTable: "Drivers",
                principalColumn: "Identification",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
