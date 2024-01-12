using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetwebapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "passwd",
                table: "User",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwd",
                table: "User");
        }
    }
}
