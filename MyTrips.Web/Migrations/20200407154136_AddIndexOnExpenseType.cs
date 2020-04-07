using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTrips.Web.Migrations
{
    public partial class AddIndexOnExpenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_Name",
                table: "ExpenseTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_Name",
                table: "ExpenseTypes");
        }
    }
}
