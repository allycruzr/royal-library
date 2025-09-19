using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalLibrary.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPublisherAndOwnershipStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ownership_status",
                table: "books",
                type: "TEXT",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "publisher",
                table: "books",
                type: "TEXT",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ownership_status",
                table: "books");

            migrationBuilder.DropColumn(
                name: "publisher",
                table: "books");
        }
    }
}
