using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class removed_unnecessary_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "SystemAdmins");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "SystemAdmins");

            migrationBuilder.DropColumn(
                name: "StreetNubmer",
                table: "SystemAdmins");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "StreetNubmer",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "BoatOwners");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "BoatOwners");

            migrationBuilder.DropColumn(
                name: "StreetNubmer",
                table: "BoatOwners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "SystemAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "SystemAdmins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreetNubmer",
                table: "SystemAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreetNubmer",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "BoatOwners",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "BoatOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StreetNubmer",
                table: "BoatOwners",
                type: "text",
                nullable: true);
        }
    }
}
