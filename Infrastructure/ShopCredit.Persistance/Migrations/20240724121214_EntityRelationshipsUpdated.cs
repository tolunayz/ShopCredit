using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCredit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EntityRelationshipsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_CustomerAccPaymentS_PaymentPaymetID",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_PaymentPaymetID",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_CustomersAccounts_CustomerID",
                table: "CustomersAccounts");

            migrationBuilder.DropColumn(
                name: "PaymentPaymetID",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "PaymetMethod",
                table: "CustomerAccPaymentS");

            migrationBuilder.RenameColumn(
                name: "CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                newName: "PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccPaymentS_CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                newName: "IX_CustomerAccPaymentS_PaymentMethodId");

            migrationBuilder.AddColumn<int>(
                name: "PaymetMethodId",
                table: "CustomerAccPaymentS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAccounts_CustomerID",
                table: "CustomersAccounts",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccPaymentS_AccountID",
                table: "CustomerAccPaymentS",
                column: "AccountID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_AccountID",
                table: "CustomerAccPaymentS",
                column: "AccountID",
                principalTable: "CustomersAccounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_PaymentMethods_PaymentMethodId",
                table: "CustomerAccPaymentS",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_AccountID",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_PaymentMethods_PaymentMethodId",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropIndex(
                name: "IX_CustomersAccounts_CustomerID",
                table: "CustomersAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccPaymentS_AccountID",
                table: "CustomerAccPaymentS");

            migrationBuilder.DropColumn(
                name: "PaymetMethodId",
                table: "CustomerAccPaymentS");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "CustomerAccPaymentS",
                newName: "CustomerAccountAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccPaymentS_PaymentMethodId",
                table: "CustomerAccPaymentS",
                newName: "IX_CustomerAccPaymentS_CustomerAccountAccountId");

            migrationBuilder.AddColumn<int>(
                name: "PaymentPaymetID",
                table: "PaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymetMethod",
                table: "CustomerAccPaymentS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_PaymentPaymetID",
                table: "PaymentMethods",
                column: "PaymentPaymetID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersAccounts_CustomerID",
                table: "CustomersAccounts",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                column: "CustomerAccountAccountId",
                principalTable: "CustomersAccounts",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_CustomerAccPaymentS_PaymentPaymetID",
                table: "PaymentMethods",
                column: "PaymentPaymetID",
                principalTable: "CustomerAccPaymentS",
                principalColumn: "PaymetID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
