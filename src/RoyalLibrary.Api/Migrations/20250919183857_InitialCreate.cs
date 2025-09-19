using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalLibrary.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    total_copies = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    copies_in_use = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    isbn = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    category = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.book_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
