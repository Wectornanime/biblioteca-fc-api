using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace biblioteca_fc_api.Migrations
{
    /// <inheritdoc />
    public partial class AddPenalty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Penaltys_LoanId",
                table: "Penaltys",
                column: "LoanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Penaltys_Loans_LoanId",
                table: "Penaltys",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Penaltys_Loans_LoanId",
                table: "Penaltys");

            migrationBuilder.DropIndex(
                name: "IX_Penaltys_LoanId",
                table: "Penaltys");
        }
    }
}
