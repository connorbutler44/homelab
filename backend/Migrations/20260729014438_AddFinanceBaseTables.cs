using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homelab.Migrations
{
    /// <inheritdoc />
    public partial class AddFinanceBaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "finance_accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    account_number_last_four = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_finance_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "finance_transactions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    finance_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_finance_transactions", x => x.id);
                    table.ForeignKey(
                        name: "fk_finance_transactions_finance_accounts_finance_account_id",
                        column: x => x.finance_account_id,
                        principalTable: "finance_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_finance_accounts_key",
                table: "finance_accounts",
                column: "key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_finance_transactions_finance_account_id",
                table: "finance_transactions",
                column: "finance_account_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "finance_transactions");

            migrationBuilder.DropTable(
                name: "finance_accounts");
        }
    }
}
