using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZZTicaret.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class m5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "NameSurname");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "BasketItems",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameSurname",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "BasketItems",
                newName: "Count");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
