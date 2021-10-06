using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations.Migrations
{
    public partial class UpdateConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Clients",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Employees",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Rooms",
                table: "Room");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Clients",
                table: "Client",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Employees",
                table: "Employee",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Rooms",
                table: "Room",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Clients",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Employees",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_Rooms",
                table: "Room");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Clients",
                table: "Client",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Employees",
                table: "Employee",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_Rooms",
                table: "Room",
                column: "HotelId",
                principalTable: "Hotel",
                principalColumn: "Id");
        }
    }
}
