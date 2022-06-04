using Microsoft.EntityFrameworkCore.Migrations;

namespace WickedTunaInfrastructure.Migrations
{
    public partial class addboatnumberofengines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEngines",
                table: "Boats",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEngines",
                table: "Boats");
        }
    }
}
