using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class changed_cottagereservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalServices",
                table: "CottageReservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "CottageReservations",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalServices",
                table: "CottageReservations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CottageReservations");
        }
    }
}
