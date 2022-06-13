using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Accounting.Server.Migrations
{
    public partial class Accounting001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryIncomeExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryIncomeExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeExpense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CategoryIncomeExpensesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeExpense_CategoryIncomeExpense_CategoryIncomeExpensesId",
                        column: x => x.CategoryIncomeExpensesId,
                        principalTable: "CategoryIncomeExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accountings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IncomeExpensesId = table.Column<int>(type: "integer", nullable: false),
                    CategoryIncomeExpensesId = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Sum = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accountings_CategoryIncomeExpense_CategoryIncomeExpensesId",
                        column: x => x.CategoryIncomeExpensesId,
                        principalTable: "CategoryIncomeExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accountings_IncomeExpense_IncomeExpensesId",
                        column: x => x.IncomeExpensesId,
                        principalTable: "IncomeExpense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accountings_CategoryIncomeExpensesId",
                table: "Accountings",
                column: "CategoryIncomeExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Accountings_IncomeExpensesId",
                table: "Accountings",
                column: "IncomeExpensesId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeExpense_CategoryIncomeExpensesId",
                table: "IncomeExpense",
                column: "CategoryIncomeExpensesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accountings");

            migrationBuilder.DropTable(
                name: "IncomeExpense");

            migrationBuilder.DropTable(
                name: "CategoryIncomeExpense");
        }
    }
}
