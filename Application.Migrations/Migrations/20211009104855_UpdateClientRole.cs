using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations.Migrations
{
    public partial class UpdateClientRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Client",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_RoleId",
                table: "Client",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Role_RoleId",
                table: "Client");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Client_RoleId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Client");
        }
    }
}
