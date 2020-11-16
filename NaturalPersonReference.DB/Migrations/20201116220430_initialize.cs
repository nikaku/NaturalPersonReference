using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalPersonReference.DB.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocaleResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocaleResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Tin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PhoneId = table.Column<int>(type: "int", nullable: false),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_Phones_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPersons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RelatedPersonId = table.Column<int>(type: "int", nullable: false),
                    ConnectionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPersons", x => new { x.PersonId, x.RelatedPersonId });
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RelatedPersons_Persons_RelatedPersonId",
                        column: x => x.RelatedPersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 1, "Tbilisi" },
                    { 2, "Kutaisi" },
                    { 3, "Batumi" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "GEO" },
                    { 2, "ENG" }
                });

            migrationBuilder.InsertData(
                table: "LocaleResources",
                columns: new[] { "Id", "LanguageId", "ResourceName", "ResourceValue" },
                values: new object[,]
                {
                    { 1, 1, "FirstName.Error", "არავალლიდური სახელი" },
                    { 2, 2, "FirstName.Error", "First Name is not valid" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "PhoneNumber", "Type" },
                values: new object[,]
                {
                    { 1, "551551551", 1 },
                    { 2, "551551552", 0 },
                    { 3, "551551553", 0 },
                    { 4, "551551554", 1 },
                    { 5, "551551555", 0 },
                    { 6, "551551544", 2 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "CityId", "FirstName", "Gender", "LastName", "PhoneId", "PicturePath", "Tin" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nika", 1, "Kurdadze", 1, null, "57001057458" },
                    { 4, new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Giga", 1, "Grigalashvili", 1, null, "57001057428" },
                    { 2, new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Vazha", 1, "Jambazishvili", 2, null, "57001057451" },
                    { 3, new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beka", 0, "Latsabidze", 3, null, "57001057458" },
                    { 5, new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zura", 1, "Adghuladze", 4, null, "77701052458" },
                    { 6, new DateTime(1994, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Goderdzi", 1, "Lominashvili", 5, null, "57001057451" }
                });

            migrationBuilder.InsertData(
                table: "RelatedPersons",
                columns: new[] { "PersonId", "RelatedPersonId", "ConnectionType" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 1, 2, 1 },
                    { 2, 4, 1 },
                    { 1, 3, 1 },
                    { 3, 2, 1 },
                    { 3, 4, 2 },
                    { 4, 5, 0 },
                    { 5, 2, 2 },
                    { 1, 5, 1 },
                    { 3, 5, 1 },
                    { 3, 6, 1 },
                    { 1, 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons",
                column: "PhoneId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_RelatedPersonId",
                table: "RelatedPersons",
                column: "RelatedPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "LocaleResources");

            migrationBuilder.DropTable(
                name: "RelatedPersons");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
