using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalPersonReference.DB.Migrations
{
    public partial class relatedPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedPersons_Persons_PersonId1",
                table: "RelatedPersons");

            migrationBuilder.DropIndex(
                name: "IX_RelatedPersons_PersonId1",
                table: "RelatedPersons");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "RelatedPersons");

            migrationBuilder.AddColumn<int>(
                name: "ConnectionType",
                table: "RelatedPersons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "RelatedPersons");

            migrationBuilder.AddColumn<int>(
                name: "PersonId1",
                table: "RelatedPersons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelatedPersons_PersonId1",
                table: "RelatedPersons",
                column: "PersonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedPersons_Persons_PersonId1",
                table: "RelatedPersons",
                column: "PersonId1",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
