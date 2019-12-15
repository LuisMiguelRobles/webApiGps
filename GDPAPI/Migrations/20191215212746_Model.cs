using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDPAPI.Migrations
{
    public partial class Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Nit = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Nit);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Plaque = table.Column<string>(nullable: false),
                    InternalIdentifier = table.Column<string>(nullable: false),
                    NumberSeats = table.Column<int>(nullable: false),
                    CompanyNit = table.Column<string>(nullable: true),
                    SeatsAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Plaque);
                    table.ForeignKey(
                        name: "FK_Vehicles_Companies_CompanyNit",
                        column: x => x.CompanyNit,
                        principalTable: "Companies",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestinationsOffered",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationPrice = table.Column<double>(nullable: false),
                    Direct = table.Column<bool>(nullable: false),
                    CompanyNit = table.Column<string>(nullable: true),
                    DestinationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationsOffered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DestinationsOffered_Companies_CompanyNit",
                        column: x => x.CompanyNit,
                        principalTable: "Companies",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DestinationsOffered_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDepartures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    Plaque = table.Column<string>(nullable: true),
                    DestinationOfferedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDepartures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDepartures_DestinationsOffered_DestinationOfferedId",
                        column: x => x.DestinationOfferedId,
                        principalTable: "DestinationsOffered",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleDepartures_Vehicles_Plaque",
                        column: x => x.Plaque,
                        principalTable: "Vehicles",
                        principalColumn: "Plaque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    TicketPrice = table.Column<double>(nullable: false),
                    VehicleDepartureId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_VehicleDepartures_VehicleDepartureId",
                        column: x => x.VehicleDepartureId,
                        principalTable: "VehicleDepartures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Email",
                table: "Companies",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DestinationsOffered_CompanyNit",
                table: "DestinationsOffered",
                column: "CompanyNit");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationsOffered_DestinationId",
                table: "DestinationsOffered",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VehicleDepartureId",
                table: "Tickets",
                column: "VehicleDepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDepartures_DestinationOfferedId",
                table: "VehicleDepartures",
                column: "DestinationOfferedId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDepartures_Plaque",
                table: "VehicleDepartures",
                column: "Plaque");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyNit",
                table: "Vehicles",
                column: "CompanyNit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehicleDepartures");

            migrationBuilder.DropTable(
                name: "DestinationsOffered");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
