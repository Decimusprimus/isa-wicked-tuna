using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class changedboat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfEngines",
                table: "Boats",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Boats",
                newName: "NumberOfEngines");
        }
    }
}
