using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    /// <inheritdoc />
    public partial class updatedb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaVaDieuKien",
                table: "ChiTietVanPhong");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 6, 10, 26, 15, 996, DateTimeKind.Local).AddTicks(8191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 6, 10, 19, 21, 672, DateTimeKind.Local).AddTicks(380));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GiaVaDieuKien",
                table: "ChiTietVanPhong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 6, 10, 19, 21, 672, DateTimeKind.Local).AddTicks(380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 6, 10, 26, 15, 996, DateTimeKind.Local).AddTicks(8191));
        }
    }
}
