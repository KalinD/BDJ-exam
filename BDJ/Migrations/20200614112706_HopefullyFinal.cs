using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDJ.Migrations
{
    public partial class HopefullyFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Trains_TrainId",
                table: "Lines");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainId",
                table: "Lines",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Lines",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Trains_TrainId",
                table: "Lines",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lines_Trains_TrainId",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Lines");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainId",
                table: "Lines",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Lines_Trains_TrainId",
                table: "Lines",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
