using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTap2.Migrations
{
    public partial class Baitap2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InternMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternMailReplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenIdentificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Internable = table.Column<bool>(type: "bit", nullable: true),
                    FullTime = table.Column<bool>(type: "bit", nullable: true),
                    Cvfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternSpecialized = table.Column<int>(type: "int", nullable: true),
                    TelephoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HowToKnowAlta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InternPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfExperiences = table.Column<short>(type: "smallint", nullable: true),
                    PasswordStatus = table.Column<bool>(type: "bit", nullable: true),
                    ReadyToWork = table.Column<bool>(type: "bit", nullable: true),
                    InternEnabled = table.Column<bool>(type: "bit", nullable: true),
                    EntranceTest = table.Column<float>(type: "real", nullable: true),
                    Introduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiddenToEnterprise = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "AllowAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessProperties = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowAccesses_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowAccesses_RoleId",
                table: "AllowAccesses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowAccesses");

            migrationBuilder.DropTable(
                name: "Interns");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
