using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace makaledeneme1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.AlterColumn<string>(
        //        name: "twitter",
        //        table: "Author",
        //        type: "nvarchar(max)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(max)");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "instagram",
        //        table: "Author",
        //        type: "nvarchar(max)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(max)");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "Facebook",
        //        table: "Author",
        //        type: "nvarchar(max)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(max)");

        //    migrationBuilder.AlterColumn<string>(
        //        name: "Bio",
        //        table: "Author",
        //        type: "nvarchar(max)",
        //        nullable: true,
        //        oldClrType: typeof(string),
        //        oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "authorPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDescriptoin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImgeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDAte = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>//constraints => iliski
                {
                    table.PrimaryKey("PK_authorPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_authorPosts_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_authorPosts_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_authorPosts_AuthorId",
                table: "authorPosts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_authorPosts_CategoryId",
                table: "authorPosts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authorPosts");

            migrationBuilder.AlterColumn<string>(
                name: "twitter",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "instagram",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Facebook",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
