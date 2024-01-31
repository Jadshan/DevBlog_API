using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class BlogDateChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createAt",
                table: "Blogs",
                newName: "createdAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Blogs",
                newName: "createAt");
        }
    }
}
