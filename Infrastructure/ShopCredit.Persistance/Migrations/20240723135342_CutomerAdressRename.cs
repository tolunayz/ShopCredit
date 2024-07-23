using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCredit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CutomerAdressRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                table: "CustomerAccPaymentS");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Customers",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                column: "CustomerAccountAccountId",
                principalTable: "CustomersAccounts",
                principalColumn: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                table: "CustomerAccPaymentS");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "Adress");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccPaymentS_CustomersAccounts_CustomerAccountAccountId",
                table: "CustomerAccPaymentS",
                column: "CustomerAccountAccountId",
                principalTable: "CustomersAccounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
