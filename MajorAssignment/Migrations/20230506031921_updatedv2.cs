using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    /// <inheritdoc />
    public partial class updatedv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 6, 10, 19, 21, 672, DateTimeKind.Local).AddTicks(380),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 4, 15, 38, 30, 1, DateTimeKind.Local).AddTicks(7704));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "GiaCapNhat",
                table: "BatDongSan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 4, 15, 38, 30, 1, DateTimeKind.Local).AddTicks(7704),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 6, 10, 19, 21, 672, DateTimeKind.Local).AddTicks(380));
        }
    }
}
