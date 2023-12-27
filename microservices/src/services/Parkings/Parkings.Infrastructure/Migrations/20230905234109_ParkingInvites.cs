using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parkings.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ParkingInvites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "ParkingLots");

            migrationBuilder.CreateTable(
                name: "ParkingMemberships",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ValetId = table.Column<string>(type: "text", nullable: true),
                    ParkingLotId = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingMemberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingMemberships_ParkingLots_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingMemberships_Users_ValetId",
                        column: x => x.ValetId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingMemberships_ParkingLotId",
                table: "ParkingMemberships",
                column: "ParkingLotId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingMemberships_ValetId",
                table: "ParkingMemberships",
                column: "ValetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingMemberships");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "ParkingLots",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
