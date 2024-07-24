using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCredit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PaymentMethods2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymetID = table.Column<int>(type: "int", nullable: false),
                    PaymentPaymetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_CustomerAccPaymentS_PaymentPaymetID",
                        column: x => x.PaymentPaymetID,
                        principalTable: "CustomerAccPaymentS",
                        principalColumn: "PaymetID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_PaymentPaymetID",
                table: "PaymentMethods",
                column: "PaymentPaymetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
