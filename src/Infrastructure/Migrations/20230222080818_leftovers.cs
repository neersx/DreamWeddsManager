using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamWeddsManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class leftovers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlazorHeroUserId",
                schema: "Identity",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KeyValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_BlazorHeroUserId",
                schema: "Identity",
                table: "Roles",
                column: "BlazorHeroUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_BlazorHeroUserId",
                schema: "Identity",
                table: "Roles",
                column: "BlazorHeroUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_BlazorHeroUserId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "KeyValues");

            migrationBuilder.DropIndex(
                name: "IX_Roles_BlazorHeroUserId",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BlazorHeroUserId",
                schema: "Identity",
                table: "Roles");
        }
    }
}
