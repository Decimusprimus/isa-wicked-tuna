using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class added_reservationtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationStatus",
                table: "CottageReservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationType",
                table: "CottageReservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationStatus",
                table: "BoatReservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationType",
                table: "BoatReservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "CottageReservations");

            migrationBuilder.DropColumn(
                name: "ReservationType",
                table: "CottageReservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatus",
                table: "BoatReservations");

            migrationBuilder.DropColumn(
                name: "ReservationType",
                table: "BoatReservations");
        }
    }
}
