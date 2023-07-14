using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JCarrollOnline.Migrations
{
    /// <inheritdoc />
    public partial class AdjustMicropost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MicroPost_AspNetUsers_AuthorId",
                table: "MicroPost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MicroPost",
                table: "MicroPost");

            migrationBuilder.RenameTable(
                name: "MicroPost",
                newName: "Microposts");

            migrationBuilder.RenameIndex(
                name: "IX_MicroPost_AuthorId",
                table: "Microposts",
                newName: "IX_Microposts_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Microposts",
                table: "Microposts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Microposts_AspNetUsers_AuthorId",
                table: "Microposts",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Microposts_AspNetUsers_AuthorId",
                table: "Microposts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Microposts",
                table: "Microposts");

            migrationBuilder.RenameTable(
                name: "Microposts",
                newName: "MicroPost");

            migrationBuilder.RenameIndex(
                name: "IX_Microposts_AuthorId",
                table: "MicroPost",
                newName: "IX_MicroPost_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MicroPost",
                table: "MicroPost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MicroPost_AspNetUsers_AuthorId",
                table: "MicroPost",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
