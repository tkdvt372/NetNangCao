using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    /// <inheritdoc />
    public partial class updatedb10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChucVu",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "user");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 23, 16, 38, 52, 666, DateTimeKind.Local).AddTicks(5403),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 6, 17, 13, 29, 189, DateTimeKind.Local).AddTicks(1303));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChucVu",
                table: "TaiKhoan");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 6, 17, 13, 29, 189, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 23, 16, 38, 52, 666, DateTimeKind.Local).AddTicks(5403));
        }
    }
}
