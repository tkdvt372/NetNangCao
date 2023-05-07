using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    /// <inheritdoc />
    public partial class updateDB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "TaiKhoan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "https://res.cloudinary.com/df6xlriko/image/upload/v1683367962/avt_xl7z3r.jpg");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 6, 17, 13, 29, 189, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 6, 10, 26, 15, 996, DateTimeKind.Local).AddTicks(8191));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "TaiKhoan");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 6, 10, 26, 15, 996, DateTimeKind.Local).AddTicks(8191),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 6, 17, 13, 29, 189, DateTimeKind.Local).AddTicks(1303));
        }
    }
}
