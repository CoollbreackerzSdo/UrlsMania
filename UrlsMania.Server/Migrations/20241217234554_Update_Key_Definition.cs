using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlsMania.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update_Key_Definition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortUrls",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    long_url = table.Column<string>(type: "text", nullable: false),
                    short_url = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortUrls", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_code",
                table: "ShortUrls",
                column: "code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortUrls");
        }
    }
}
