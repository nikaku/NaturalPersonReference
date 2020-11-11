using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalPersonReference.DB.Migrations
{
    public partial class chagedNaame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Phones_PhoneNumberId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberId",
                table: "Persons",
                newName: "PhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PhoneNumberId",
                table: "Persons",
                newName: "IX_Persons_PhoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Phones_PhoneId",
                table: "Persons",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Phones_PhoneId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "PhoneId",
                table: "Persons",
                newName: "PhoneNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PhoneId",
                table: "Persons",
                newName: "IX_Persons_PhoneNumberId");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Phones_PhoneNumberId",
                table: "Persons",
                column: "PhoneNumberId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
