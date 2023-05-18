using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoVaTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "BatDongSan",
                columns: table => new
                {
                    MaBatDongSan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenToaNha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DienTichSan = table.Column<double>(type: "float", nullable: false, defaultValue: 10.0),
                    DienTichChoThue = table.Column<double>(type: "float", nullable: false, defaultValue: 10.0),
                    PhiQuanLy = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    VAT = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PhiGuiOto = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PhiGuiXeMay = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    GiaCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 5, 4, 9, 38, 7, 530, DateTimeKind.Local).AddTicks(6965)),
                    DiaChi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoTang = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Nhà ở"),
                    MaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatDongSan", x => x.MaBatDongSan);
                    table.ForeignKey(
                        name: "FK_BatDongSan_TaiKhoan_MaTaiKhoan",
                        column: x => x.MaTaiKhoan,
                        principalTable: "TaiKhoan",
                        principalColumn: "MaTaiKhoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietVanPhong",
                columns: table => new
                {
                    MaChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaVaDieuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaBatDongSan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietVanPhong", x => x.MaChiTiet);
                    table.ForeignKey(
                        name: "FK_ChiTietVanPhong_BatDongSan_MaBatDongSan",
                        column: x => x.MaBatDongSan,
                        principalTable: "BatDongSan",
                        principalColumn: "MaBatDongSan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatDongSan_MaTaiKhoan",
                table: "BatDongSan",
                column: "MaTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietVanPhong_MaBatDongSan",
                table: "ChiTietVanPhong",
                column: "MaBatDongSan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_CCCD",
                table: "TaiKhoan",
                column: "CCCD",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_Email",
                table: "TaiKhoan",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietVanPhong");

            migrationBuilder.DropTable(
                name: "BatDongSan");

            migrationBuilder.DropTable(
                name: "TaiKhoan");
        }
    }
}
