using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCredit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CustomersAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DebtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersAccounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_CustomersAccounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccPaymentS",
                columns: table => new
                {
                    PaymetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    CustomerAccountAccountId = table.Column<int>(type: "int", nullable: false),
                    PaymetMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDebt = table.Column<long>(type: "bigint", nullable: false),
                    PaidDebt = table.Column<long>(type: "bigint", nullable: false),
                    CurrentDebt = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccPaymentS", x => x.PaymetID);
                    table.ForeignKey(
                        name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                        column: x => x.CustomerAccountAccountId,
                        principalTable: "CustomersAccounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccPaymentS_CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                column: "CustomerAccountAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAccounts_CustomerID",
                table: "CustomersAccounts",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAccPaymentS");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CustomersAccounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
