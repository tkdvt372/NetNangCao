using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BaiTapLonNet.Models
{
    public class ChiTietVanPhong
    {
        public int MaChiTiet { get; set; }
  
        public List<String> TongQuan { get; set; }
       
        public List<String> GiaVaDieuKien { get; set; }
        public int MaBatDongSan { get; set; }
        public BatDongSan BatDongSan { get; set; }
        
    }

}
