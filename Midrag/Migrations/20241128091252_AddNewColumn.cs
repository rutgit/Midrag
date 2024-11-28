using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midrag.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "ProviderInFields",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProviderInFields_FieldId",
                table: "ProviderInFields",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProviderInFields_Fields_FieldId",
                table: "ProviderInFields",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProviderInFields_Fields_FieldId",
                table: "ProviderInFields");

            migrationBuilder.DropIndex(
                name: "IX_ProviderInFields_FieldId",
                table: "ProviderInFields");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "ProviderInFields");
        }
    }
}
