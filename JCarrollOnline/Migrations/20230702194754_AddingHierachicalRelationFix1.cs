using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JCarrollOnline.Migrations
{
    /// <inheritdoc />
    public partial class AddingHierachicalRelationFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads");

            migrationBuilder.RenameColumn(
                name: "ForumThreadEntryId",
                table: "ForumThreads",
                newName: "Parent_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads",
                newName: "IX_ForumThreads_Parent_Id");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ForumThreads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_ForumThreads_Parent_Id",
                table: "ForumThreads",
                column: "Parent_Id",
                principalTable: "ForumThreads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumThreads_ForumThreads_Parent_Id",
                table: "ForumThreads");

            migrationBuilder.RenameColumn(
                name: "Parent_Id",
                table: "ForumThreads",
                newName: "ForumThreadEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_ForumThreads_Parent_Id",
                table: "ForumThreads",
                newName: "IX_ForumThreads_ForumThreadEntryId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ForumThreads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumThreads_ForumThreads_ForumThreadEntryId",
                table: "ForumThreads",
                column: "ForumThreadEntryId",
                principalTable: "ForumThreads",
                principalColumn: "Id");
        }
    }
}
