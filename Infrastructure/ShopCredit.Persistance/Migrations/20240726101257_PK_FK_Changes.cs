using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCredit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PK_FK_Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_Id",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersAccounts_Customers_Id",
                table: "CustomersAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomersAccounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerAccountId",
                table: "CustomerAccPaymentS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAccounts_CustomerId",
                table: "CustomersAccounts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccPaymentS_CustomerAccountId",
                table: "CustomerAccPaymentS",
                column: "CustomerAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountId",
                table: "CustomerAccPaymentS",
                column: "CustomerAccountId",
                principalTable: "CustomersAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersAccounts_Customers_CustomerId",
                table: "CustomersAccounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountId",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersAccounts_Customers_CustomerId",
                table: "CustomersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomersAccounts_CustomerId",
                table: "CustomersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccPaymentS_CustomerAccountId",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomersAccounts");

            migrationBuilder.DropColumn(
                name: "CustomerAccountId",
                table: "CustomerAccPaymentS");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_Id",
                table: "CustomerAccPaymentS",
                column: "Id",
                principalTable: "CustomersAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersAccounts_Customers_Id",
                table: "CustomersAccounts",
                column: "Id",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
