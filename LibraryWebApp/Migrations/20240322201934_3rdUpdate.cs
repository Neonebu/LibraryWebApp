using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryWebApp.Migrations
{
    /// <inheritdoc />
    public partial class _3rdUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BookCount",
                table: "Books",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookCount",
                table: "Books");
        }
    }
}
