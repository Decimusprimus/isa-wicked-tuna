using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class added_boatreservation_and_availableperiod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EngineNumger",
                table: "Boats",
                newName: "NumberOfEngines");

            migrationBuilder.AlterColumn<float>(
                name: "CancellationFee",
                table: "Boats",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "BoatAvailablePeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BoatId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatAvailablePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatAvailablePeriods_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoatReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BoatId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatReservations_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoatReservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatAvailablePeriods_BoatId",
                table: "BoatAvailablePeriods",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatReservations_BoatId",
                table: "BoatReservations",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatReservations_ClientId",
                table: "BoatReservations",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatAvailablePeriods");

            migrationBuilder.DropTable(
                name: "BoatReservations");

            migrationBuilder.RenameColumn(
                name: "NumberOfEngines",
                table: "Boats",
                newName: "EngineNumger");

            migrationBuilder.AlterColumn<int>(
                name: "CancellationFee",
                table: "Boats",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
