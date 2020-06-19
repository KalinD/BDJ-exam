using Microsoft.EntityFrameworkCore.Migrations;

namespace BDJ.Migrations
{
    public partial class TrainFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Trains",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Trains");
        }
    }
}
