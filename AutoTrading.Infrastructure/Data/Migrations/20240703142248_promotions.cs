using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoTrading.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class promotions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionRole_Action_ActionId",
                table: "ActionRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionRole_Roles_RoleId",
                table: "ActionRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionRole",
                table: "ActionRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Action",
                table: "Action");

            migrationBuilder.RenameTable(
                name: "ActionRole",
                newName: "ActionRoles");

            migrationBuilder.RenameTable(
                name: "Action",
                newName: "Actions");

            migrationBuilder.RenameIndex(
                name: "IX_ActionRole_RoleId",
                table: "ActionRoles",
                newName: "IX_ActionRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionRoles",
                table: "ActionRoles",
                columns: new[] { "ActionId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actions",
                table: "Actions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "이벤트 이름"),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "프로모션 시작 날짜"),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "프로모션 종료 날짜"),
                    ImagePath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false, comment: "이미지 경로"),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRoles_Actions_ActionId",
                table: "ActionRoles",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRoles_Roles_RoleId",
                table: "ActionRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionRoles_Actions_ActionId",
                table: "ActionRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionRoles_Roles_RoleId",
                table: "ActionRoles");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actions",
                table: "Actions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionRoles",
                table: "ActionRoles");

            migrationBuilder.RenameTable(
                name: "Actions",
                newName: "Action");

            migrationBuilder.RenameTable(
                name: "ActionRoles",
                newName: "ActionRole");

            migrationBuilder.RenameIndex(
                name: "IX_ActionRoles_RoleId",
                table: "ActionRole",
                newName: "IX_ActionRole_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Action",
                table: "Action",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionRole",
                table: "ActionRole",
                columns: new[] { "ActionId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRole_Action_ActionId",
                table: "ActionRole",
                column: "ActionId",
                principalTable: "Action",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionRole_Roles_RoleId",
                table: "ActionRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
