using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksManagementSystem.Common.Migrations
{
    public partial class UserBookRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxRentDays",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalBooks",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "userBookRents",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBookRents", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_userBookRents_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userBookRents_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userBookRents_BookId",
                table: "userBookRents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_userBookRents_UserId",
                table: "userBookRents",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userBookRents");

            migrationBuilder.DropColumn(
                name: "MaxRentDays",
                table: "books");

            migrationBuilder.DropColumn(
                name: "TotalBooks",
                table: "books");
        }
    }
}
