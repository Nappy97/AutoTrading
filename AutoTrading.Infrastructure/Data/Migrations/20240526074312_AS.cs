using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoTrading.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Memo",
                table: "Stocks",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "특이사항",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "특이사항");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Memo",
                table: "Stocks",
                type: "text",
                nullable: false,
                comment: "특이사항",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "",
                oldComment: "특이사항");
        }
    }
}
