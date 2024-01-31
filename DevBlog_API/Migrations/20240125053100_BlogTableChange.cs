using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBlogAPI.Migrations
{
    /// <inheritdoc />
    public partial class BlogTableChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermaLink",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "except",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Blogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermaLink",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "except",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
