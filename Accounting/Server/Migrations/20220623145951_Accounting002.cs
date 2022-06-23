using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Server.Migrations
{
    public partial class Accounting002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeExpense_CategoryIncomeExpense_CategoryIncomeExpensesId",
                table: "IncomeExpense");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryIncomeExpensesId",
                table: "IncomeExpense",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeExpense_CategoryIncomeExpense_CategoryIncomeExpensesId",
                table: "IncomeExpense",
                column: "CategoryIncomeExpensesId",
                principalTable: "CategoryIncomeExpense",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeExpense_CategoryIncomeExpense_CategoryIncomeExpensesId",
                table: "IncomeExpense");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryIncomeExpensesId",
                table: "IncomeExpense",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeExpense_CategoryIncomeExpense_CategoryIncomeExpensesId",
                table: "IncomeExpense",
                column: "CategoryIncomeExpensesId",
                principalTable: "CategoryIncomeExpense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
