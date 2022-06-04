using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class adv_lessonreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "CancellationFee",
                table: "AdventrueLessons",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "AdventureLessonReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdventureLessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdventureLessonReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdventureLessonReservations_AdventrueLessons_AdventureLesso~",
                        column: x => x.AdventureLessonId,
                        principalTable: "AdventrueLessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdventureLessonReservations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorAvailablePeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InstructorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorAvailablePeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorAvailablePeriods_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdventureLessonReservations_AdventureLessonId",
                table: "AdventureLessonReservations",
                column: "AdventureLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_AdventureLessonReservations_ClientId",
                table: "AdventureLessonReservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorAvailablePeriods_InstructorId",
                table: "InstructorAvailablePeriods",
                column: "InstructorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdventureLessonReservations");

            migrationBuilder.DropTable(
                name: "InstructorAvailablePeriods");

            migrationBuilder.AlterColumn<int>(
                name: "CancellationFee",
                table: "AdventrueLessons",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
