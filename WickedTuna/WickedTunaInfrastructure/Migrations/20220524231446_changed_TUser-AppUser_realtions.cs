using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class changed_TUserAppUser_realtions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoatOwners_AspNetUsers_ApplicationUserId1",
                table: "BoatOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_SystemAdmins_AspNetUsers_ApplicationUserId1",
                table: "SystemAdmins");

            migrationBuilder.DropIndex(
                name: "IX_SystemAdmins_ApplicationUserId1",
                table: "SystemAdmins");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_BoatOwners_ApplicationUserId1",
                table: "BoatOwners");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "SystemAdmins");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "BoatOwners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "SystemAdmins",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Clients",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "BoatOwners",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemAdmins_ApplicationUserId1",
                table: "SystemAdmins",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ApplicationUserId1",
                table: "Clients",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BoatOwners_ApplicationUserId1",
                table: "BoatOwners",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BoatOwners_AspNetUsers_ApplicationUserId1",
                table: "BoatOwners",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ApplicationUserId1",
                table: "Clients",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SystemAdmins_AspNetUsers_ApplicationUserId1",
                table: "SystemAdmins",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
