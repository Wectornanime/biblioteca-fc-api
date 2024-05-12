using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_fc_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdLoan",
                table: "Penaltys",
                newName: "LoanId");

            migrationBuilder.RenameColumn(
                name: "PenaltyDate",
                table: "Loans",
                newName: "LoanDate");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Loans",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdBook",
                table: "Loans",
                newName: "BookId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categorys",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "Penaltys",
                newName: "IdLoan");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Loans",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "LoanDate",
                table: "Loans",
                newName: "PenaltyDate");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Loans",
                newName: "IdBook");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categorys",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150);
        }
    }
}
