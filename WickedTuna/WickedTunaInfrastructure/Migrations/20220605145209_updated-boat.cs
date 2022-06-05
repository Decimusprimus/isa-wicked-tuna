using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class updatedboat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "BoatReservations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "BoatReservationOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    BoatReservationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatReservationOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoatReservationOptions_BoatReservations_BoatReservationId",
                        column: x => x.BoatReservationId,
                        principalTable: "BoatReservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoatReservationOptions_BoatReservationId",
                table: "BoatReservationOptions",
                column: "BoatReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoatReservationOptions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BoatReservations");
        }
    }
}
