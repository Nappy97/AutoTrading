using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoTrading.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChageCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_CodeCategories_CodeCategoryId",
                table: "Codes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Codes",
                table: "Codes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CodeCategories",
                table: "CodeCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CodeCategories");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CodeCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CodeCategories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "CodeCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CodeCategories");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Codes",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                comment: "사용 여부",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldComment: "사용 여부");

            migrationBuilder.AlterColumn<int>(
                name: "CodeCategoryId",
                table: "Codes",
                type: "integer",
                nullable: false,
                comment: "코드 카테고리 ID",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "코드 카테고리 ID");

            migrationBuilder.AddColumn<int>(
                name: "CodeId",
                table: "Codes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "CodeCategories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "코드 카테고리 설명",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldComment: "코드 카테고리 설명");

            migrationBuilder.AddColumn<int>(
                name: "CodeCategoryId",
                table: "CodeCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Codes",
                table: "Codes",
                column: "CodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodeCategories",
                table: "CodeCategories",
                column: "CodeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_CodeCategories_CodeCategoryId",
                table: "Codes",
                column: "CodeCategoryId",
                principalTable: "CodeCategories",
                principalColumn: "CodeCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_CodeCategories_CodeCategoryId",
                table: "Codes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Codes",
                table: "Codes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CodeCategories",
                table: "CodeCategories");

            migrationBuilder.DropColumn(
                name: "CodeId",
                table: "Codes");

            migrationBuilder.DropColumn(
                name: "CodeCategoryId",
                table: "CodeCategories");

            migrationBuilder.AlterColumn<bool>(
                name: "Enabled",
                table: "Codes",
                type: "boolean",
                nullable: false,
                comment: "사용 여부",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true,
                oldComment: "사용 여부");

            migrationBuilder.AlterColumn<long>(
                name: "CodeCategoryId",
                table: "Codes",
                type: "bigint",
                nullable: false,
                comment: "코드 카테고리 ID",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "코드 카테고리 ID");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Codes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "Codes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "Codes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "Codes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                table: "Codes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "CodeCategories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                comment: "코드 카테고리 설명",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldDefaultValue: "",
                oldComment: "코드 카테고리 설명");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CodeCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                table: "CodeCategories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "CodeCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModified",
                table: "CodeCategories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "LastModifiedBy",
                table: "CodeCategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Codes",
                table: "Codes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodeCategories",
                table: "CodeCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_CodeCategories_CodeCategoryId",
                table: "Codes",
                column: "CodeCategoryId",
                principalTable: "CodeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
