using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MobileProjectServer.Migrations
{
    /// <inheritdoc />
    public partial class MobileDataBaseIntital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Nickname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone_Number", type: "varchar(11)", maxLength: 11, nullable: true),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    PhotoPath = table.Column<string>(name: "Photo_Path", type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinates_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enter_Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LastEntry = table.Column<DateTime>(name: "Last_Entry", type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enter_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enter_Histories_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FriendshipType = table.Column<string>(name: "Friendship_Type", type: "varchar(100)", maxLength: 100, nullable: true),
                    FirstUsersId = table.Column<int>(type: "int", nullable: false),
                    SecondUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_FirstUsersId",
                        column: x => x.FirstUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_SecondUsersId",
                        column: x => x.SecondUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinates_UsersId",
                table: "Coordinates",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Enter_Histories_UsersId",
                table: "Enter_Histories",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FirstUsersId",
                table: "Friends",
                column: "FirstUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_SecondUsersId",
                table: "Friends",
                column: "SecondUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropTable(
                name: "Enter_Histories");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
