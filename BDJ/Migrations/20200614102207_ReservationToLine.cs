using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BDJ.Migrations
{
    public partial class ReservationToLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LineId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LineId",
                table: "Reservations",
                column: "LineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Lines_LineId",
                table: "Reservations",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Lines_LineId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_LineId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Reservations");
        }
    }
}
