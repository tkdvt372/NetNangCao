﻿// <auto-generated />
using System;
using BaiTapLonNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaiTapLonNet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230504083830_updatedb3")]
    partial class updatedb3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaiTapLonNet.Models.BatDongSan", b =>
                {
                    b.Property<int>("MaBatDongSan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBatDongSan"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("DienTichChoThue")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<double>("DienTichSan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<double>("Gia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<DateTime>("GiaCapNhat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 5, 4, 15, 38, 30, 1, DateTimeKind.Local).AddTicks(7704));

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("[]");

                    b.Property<string>("Loai")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Nhà ở");

                    b.Property<int>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<double>("PhiGuiOto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PhiGuiXeMay")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<double>("PhiQuanLy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoTang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("TenToaNha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("VAT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(0.0);

                    b.HasKey("MaBatDongSan");

                    b.HasIndex("MaTaiKhoan");

                    b.ToTable("BatDongSan", (string)null);
                });

            modelBuilder.Entity("BaiTapLonNet.Models.ChiTietVanPhong", b =>
                {
                    b.Property<int>("MaChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTiet"));

                    b.Property<string>("GiaVaDieuKien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaBatDongSan")
                        .HasColumnType("int");

                    b.Property<string>("TongQuan")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("[\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"]");

                    b.HasKey("MaChiTiet");

                    b.HasIndex("MaBatDongSan")
                        .IsUnique();

                    b.ToTable("ChiTietVanPhong", (string)null);
                });

            modelBuilder.Entity("BaiTapLonNet.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTaiKhoan"));

                    b.Property<string>("CCCD")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaTaiKhoan");

                    b.HasIndex("CCCD")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("BaiTapLonNet.Models.BatDongSan", b =>
                {
                    b.HasOne("BaiTapLonNet.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("BatDongSans")
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("BaiTapLonNet.Models.ChiTietVanPhong", b =>
                {
                    b.HasOne("BaiTapLonNet.Models.BatDongSan", "BatDongSan")
                        .WithOne("ChiTietVanPhong")
                        .HasForeignKey("BaiTapLonNet.Models.ChiTietVanPhong", "MaBatDongSan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BatDongSan");
                });

            modelBuilder.Entity("BaiTapLonNet.Models.BatDongSan", b =>
                {
                    b.Navigation("ChiTietVanPhong")
                        .IsRequired();
                });

            modelBuilder.Entity("BaiTapLonNet.Models.TaiKhoan", b =>
                {
                    b.Navigation("BatDongSans");
                });
#pragma warning restore 612, 618
        }
    }
}
