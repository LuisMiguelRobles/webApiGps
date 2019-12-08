using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDPAPI.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Identification = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Celphone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Identification);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Nit = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Celphone = table.Column<string>(nullable: false),
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
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Identification = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Celphone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Identification);
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
                    FK_VehicleDeparture = table.Column<int>(nullable: false),
                    FK_Client = table.Column<string>(nullable: true),
                    FK_User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatsOcupation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDepartures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    FK_Vehicle = table.Column<string>(nullable: true),
                    FK_Driver = table.Column<string>(nullable: true),
                    FK_DestinationOffered = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDepartures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Plaque = table.Column<string>(nullable: false),
                    InternalIdentifier = table.Column<string>(nullable: false),
                    CompanyNit = table.Column<string>(nullable: true)
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
                    DestinationID = table.Column<int>(nullable: false)
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
                        name: "FK_DestinationsOffered_Destinations_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(nullable: false),
                    VehiclePlaque = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Vehicles_VehiclePlaque",
                        column: x => x.VehiclePlaque,
                        principalTable: "Vehicles",
                        principalColumn: "Plaque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

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
                name: "IX_DestinationsOffered_DestinationID",
                table: "DestinationsOffered",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_VehiclePlaque",
                table: "Seats",
                column: "VehiclePlaque");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CompanyNit",
                table: "Vehicles",
                column: "CompanyNit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "DestinationsOffered");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehicleDepartures");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
