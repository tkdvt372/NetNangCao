using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace BaiTapLonNet.Models
{
    public class BatDongSan
    {
        public int MaBatDongSan { get; set; }
        public string TenToaNha { get; set; }
        public double DienTichSan { get; set; }
        public double DienTichChoThue { get; set; }
        public double PhiQuanLy { get; set; }
        public double VAT { get; set; }
        public double PhiGuiOto { get; set; }
        public double PhiGuiXeMay { get; set; }
        public string SoDienThoai { get; set; }
        public double Gia { get; set; }
        public DateTime GiaCapNhat { get; set; }
        public string DiaChi { get; set; }
        public int SoTang { get; set; }
        public List<String> HinhAnh { get; set; }
        public string Loai { get; set; }
        public ChiTietVanPhong ChiTietVanPhong { get; set; }
        public int MaTaiKhoan { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }

}
