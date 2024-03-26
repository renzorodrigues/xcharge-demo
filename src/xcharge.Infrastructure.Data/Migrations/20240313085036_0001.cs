using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xcharge.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class _0001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Block",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    NumberOfLifts = table.Column<short>(type: "smallint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Block", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominium",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_Complement = table.Column<string>(type: "text", nullable: true),
                    Address_District = table.Column<string>(type: "text", nullable: false),
                    Address_Number = table.Column<string>(type: "text", nullable: false),
                    Address_PublicArea = table.Column<string>(type: "text", nullable: false),
                    Address_State = table.Column<string>(type: "text", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Email_EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Identification_CityRegistration = table.Column<string>(type: "text", nullable: true),
                    Identification_Cnpj = table.Column<string>(type: "text", nullable: true),
                    Identification_StateRegistration = table.Column<string>(type: "text", nullable: true),
                    Landline_Number = table.Column<string>(type: "text", nullable: false),
                    Mobile_Number = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_Complement = table.Column<string>(type: "text", nullable: true),
                    Address_District = table.Column<string>(type: "text", nullable: false),
                    Address_Number = table.Column<string>(type: "text", nullable: false),
                    Address_PublicArea = table.Column<string>(type: "text", nullable: false),
                    Address_State = table.Column<string>(type: "text", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "text", nullable: false),
                    Email_EmailAddress = table.Column<string>(type: "text", nullable: false),
                    Identification_Cpf = table.Column<string>(type: "text", nullable: false),
                    Identification_Pis = table.Column<string>(type: "text", nullable: true),
                    Identification_Rg = table.Column<string>(type: "text", nullable: true),
                    Landline_Number = table.Column<string>(type: "text", nullable: false),
                    Mobile_Number = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CondominiumUser",
                columns: table => new
                {
                    CondominiumsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondominiumUser", x => new { x.CondominiumsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CondominiumUser_Condominium_CondominiumsId",
                        column: x => x.CondominiumsId,
                        principalTable: "Condominium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CondominiumUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false),
                    BlockId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsRented = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsForRent = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_Block_BlockId",
                        column: x => x.BlockId,
                        principalTable: "Block",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unit_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unit_User_TenantId",
                        column: x => x.TenantId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CondominiumUser_UsersId",
                table: "CondominiumUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_BlockId",
                table: "Unit",
                column: "BlockId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_OwnerId",
                table: "Unit",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_TenantId",
                table: "Unit",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondominiumUser");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Condominium");

            migrationBuilder.DropTable(
                name: "Block");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
