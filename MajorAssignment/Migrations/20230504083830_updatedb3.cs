using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    /// <inheritdoc />
    public partial class updatedb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "BatDongSan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 15, 38, 30, 1, DateTimeKind.Local).AddTicks(7704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 4, 13, 53, 19, 767, DateTimeKind.Local).AddTicks(1575));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "BatDongSan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "[]");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 13, 53, 19, 767, DateTimeKind.Local).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 4, 15, 38, 30, 1, DateTimeKind.Local).AddTicks(7704));
        }
    }
}
