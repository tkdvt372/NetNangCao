using BaiTapLonNet.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BaiTapLonNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BatDongSan> batDongSans { get; set; }
        public DbSet<ChiTietVanPhong> chiTietVanPhongs { get; set; }
        public DbSet<TaiKhoan> taiKhoans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BatDongSan>(e =>
            {
                e.ToTable("BatDongSan");
                e.HasOne(e => e.TaiKhoan).WithMany(e => e.BatDongSans).HasForeignKey(e => e.MaTaiKhoan);
                e.HasOne(e => e.ChiTietVanPhong).WithOne(e => e.BatDongSan).HasForeignKey<ChiTietVanPhong>(e => e.MaBatDongSan);
                e.HasKey(e => e.MaBatDongSan);
                e.Property(e => e.TenToaNha).IsRequired().HasMaxLength(200);
                e.Property(e => e.DienTichSan).IsRequired().HasDefaultValue(10);
                e.Property(e => e.DienTichChoThue).IsRequired().HasDefaultValue(10);
                e.Property(e => e.PhiQuanLy).IsRequired().HasDefaultValue(0);
                e.Property(e => e.VAT).IsRequired().HasDefaultValue(0);
                e.Property(e => e.PhiGuiOto).IsRequired().HasDefaultValue(0);
                e.Property(e => e.PhiGuiXeMay).IsRequired().HasDefaultValue(0);
                e.Property(e => e.SoDienThoai).IsRequired();
                e.Property(e => e.Gia).IsRequired().HasDefaultValue(0);
                e.Property(e => e.GiaCapNhat).IsRequired().HasDefaultValue(DateTime.Now);
                e.Property(e => e.DiaChi).IsRequired().HasMaxLength(200);
                e.Property(e => e.SoTang).IsRequired().HasDefaultValue(1);
                e.Property(e => e.HinhAnh).HasDefaultValue(new List<string> { })
                .IsRequired()
                .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<List<string>>(v)
                   );
                e.Property(e => e.Loai).IsRequired().HasDefaultValue("Nhà ở");
            });
            modelBuilder.Entity<ChiTietVanPhong>(e =>
            {

                e.ToTable("ChiTietVanPhong");
                e.HasKey(e => e.MaChiTiet);
                e.HasOne(e => e.BatDongSan).WithOne(e => e.ChiTietVanPhong).HasForeignKey<ChiTietVanPhong>(e => e.MaBatDongSan);
                e.Property(e => e.TongQuan)
                .IsRequired().HasDefaultValue(new List<string> {"", "", "", "", "", "", "", "", "", "" })
                .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v)
                );
            });

            modelBuilder.Entity<TaiKhoan>(e =>
            {
                e.ToTable("TaiKhoan");
                e.HasKey(e => e.MaTaiKhoan);
                e.Property(e => e.HoVaTen).IsRequired().HasMaxLength(50);
                e.HasIndex(e => e.CCCD).IsUnique();
                e.HasIndex(e => e.Email).IsUnique();
                e.Property(e => e.HinhAnh).HasDefaultValue("https://res.cloudinary.com/df6xlriko/image/upload/v1683367962/avt_xl7z3r.jpg");
                e.Property(e => e.MatKhau).IsRequired().HasMaxLength(50);
            });
        }
    }
}
