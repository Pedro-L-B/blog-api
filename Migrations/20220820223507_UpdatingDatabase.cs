using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog_api.Migrations
{
    public partial class UpdatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "tb_publication",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(400)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "commentLimit",
                table: "tb_publication",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicationId",
                table: "tb_comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_comment_PublicationId",
                table: "tb_comment",
                column: "PublicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_comment_tb_publication_PublicationId",
                table: "tb_comment",
                column: "PublicationId",
                principalTable: "tb_publication",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_comment_tb_publication_PublicationId",
                table: "tb_comment");

            migrationBuilder.DropIndex(
                name: "IX_tb_comment_PublicationId",
                table: "tb_comment");

            migrationBuilder.DropColumn(
                name: "commentLimit",
                table: "tb_publication");

            migrationBuilder.DropColumn(
                name: "PublicationId",
                table: "tb_comment");

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "tb_publication",
                type: "varchar(400)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
