using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JCarrollOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddingHierachicalRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumThreadEntryId",
                table: "ForumThreads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads",
                column: "ForumThreadEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads",
                column: "ForumThreadEntryId",
                principalTable: "ForumThreads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads");

            migrationBuilder.DropIndex(
                name: "IX_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads");

            migrationBuilder.DropColumn(
                name: "ForumThreadEntryId",
                table: "ForumThreads");
        }
    }
}
