using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebBookStore.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Publsiher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Publsiher", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NumPage = table.Column<int>(type: "int", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Writer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Book", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Tbl_Book_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Book_Tbl_Publsiher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Tbl_Publsiher",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Book_CategoryId",
                table: "Tbl_Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Book_PublisherId",
                table: "Tbl_Book",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Book");

            migrationBuilder.DropTable(
                name: "Tbl_Category");

            migrationBuilder.DropTable(
                name: "Tbl_Publsiher");
        }
    }
}
