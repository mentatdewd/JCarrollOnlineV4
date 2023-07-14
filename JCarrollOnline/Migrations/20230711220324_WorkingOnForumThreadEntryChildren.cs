using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JCarrollOnline.Migrations
{
    /// <inheritdoc />
    public partial class WorkingOnForumThreadEntryChildren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumPostCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForumPostCount",
                table: "AspNetUsers");
        }
    }
}
