using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationBooks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInstanceStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInstanceStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    InventoryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInstances_BookInstanceStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BookInstanceStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndReservationDatePlan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BookInstanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_BookInstances_BookInstanceId",
                        column: x => x.BookInstanceId,
                        principalTable: "BookInstances",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookInstanceStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "CheckedOutToReadingRoom" },
                    { 3, "CheckedOutToHome" },
                    { 4, "WrittenOff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInstances_StatusId",
                table: "BookInstances",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BookInstanceId",
                table: "Reservations",
                column: "BookInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "BookInstances");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "BookInstanceStatuses");
        }
    }
}
