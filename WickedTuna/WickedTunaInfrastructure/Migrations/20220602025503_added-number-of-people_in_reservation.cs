using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class addednumberofpeople_in_reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CottageAvailablePeriod_Cottages_CottageId",
                table: "CottageAvailablePeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_CottageReservation_Clients_ClientId",
                table: "CottageReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_CottageReservation_Cottages_CottageId",
                table: "CottageReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CottageReservation",
                table: "CottageReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CottageAvailablePeriod",
                table: "CottageAvailablePeriod");

            migrationBuilder.RenameTable(
                name: "CottageReservation",
                newName: "CottageReservations");

            migrationBuilder.RenameTable(
                name: "CottageAvailablePeriod",
                newName: "CottageAvailablePeriods");

            migrationBuilder.RenameIndex(
                name: "IX_CottageReservation_CottageId",
                table: "CottageReservations",
                newName: "IX_CottageReservations_CottageId");

            migrationBuilder.RenameIndex(
                name: "IX_CottageReservation_ClientId",
                table: "CottageReservations",
                newName: "IX_CottageReservations_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_CottageAvailablePeriod_CottageId",
                table: "CottageAvailablePeriods",
                newName: "IX_CottageAvailablePeriods_CottageId");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cottages",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CottageReservations",
                table: "CottageReservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CottageAvailablePeriods",
                table: "CottageAvailablePeriods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CottageAvailablePeriods_Cottages_CottageId",
                table: "CottageAvailablePeriods",
                column: "CottageId",
                principalTable: "Cottages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CottageReservations_Clients_ClientId",
                table: "CottageReservations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CottageReservations_Cottages_CottageId",
                table: "CottageReservations",
                column: "CottageId",
                principalTable: "Cottages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CottageAvailablePeriods_Cottages_CottageId",
                table: "CottageAvailablePeriods");

            migrationBuilder.DropForeignKey(
                name: "FK_CottageReservations_Clients_ClientId",
                table: "CottageReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_CottageReservations_Cottages_CottageId",
                table: "CottageReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CottageReservations",
                table: "CottageReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CottageAvailablePeriods",
                table: "CottageAvailablePeriods");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cottages");

            migrationBuilder.RenameTable(
                name: "CottageReservations",
                newName: "CottageReservation");

            migrationBuilder.RenameTable(
                name: "CottageAvailablePeriods",
                newName: "CottageAvailablePeriod");

            migrationBuilder.RenameIndex(
                name: "IX_CottageReservations_CottageId",
                table: "CottageReservation",
                newName: "IX_CottageReservation_CottageId");

            migrationBuilder.RenameIndex(
                name: "IX_CottageReservations_ClientId",
                table: "CottageReservation",
                newName: "IX_CottageReservation_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_CottageAvailablePeriods_CottageId",
                table: "CottageAvailablePeriod",
                newName: "IX_CottageAvailablePeriod_CottageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CottageReservation",
                table: "CottageReservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CottageAvailablePeriod",
                table: "CottageAvailablePeriod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CottageAvailablePeriod_Cottages_CottageId",
                table: "CottageAvailablePeriod",
                column: "CottageId",
                principalTable: "Cottages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CottageReservation_Clients_ClientId",
                table: "CottageReservation",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CottageReservation_Cottages_CottageId",
                table: "CottageReservation",
                column: "CottageId",
                principalTable: "Cottages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
