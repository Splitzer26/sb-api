using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SBAPI.Domain.Migrations
{
    /// <inheritdoc />
    public partial class statusesimplemented : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TypeBankAccount",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tax",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "SalesOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Quotations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "ProductTransfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FamilyProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CashRegisters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BranchOffices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_StatusId",
                table: "Warehouses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_StatusId",
                table: "SalesOrder",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_StatusId",
                table: "Quotations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_StatusId",
                table: "PurchaseOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransfers_StatusId",
                table: "ProductTransfers",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Status_StatusId",
                table: "Invoices",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTransfers_Status_StatusId",
                table: "ProductTransfers",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Status_StatusId",
                table: "PurchaseOrders",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Status_StatusId",
                table: "Quotations",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrder_Status_StatusId",
                table: "SalesOrder",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Status_StatusId",
                table: "Users",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Status_StatusId",
                table: "Warehouses",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Status_StatusId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTransfers_Status_StatusId",
                table: "ProductTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Status_StatusId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Status_StatusId",
                table: "Quotations");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrder_Status_StatusId",
                table: "SalesOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Status_StatusId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Status_StatusId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_StatusId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Users_StatusId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrder_StatusId",
                table: "SalesOrder");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_StatusId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_StatusId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductTransfers_StatusId",
                table: "ProductTransfers");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_StatusId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TypeBankAccount");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tax");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "ProductTransfers");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FamilyProducts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CashRegisters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BranchOffices");
        }
    }
}
