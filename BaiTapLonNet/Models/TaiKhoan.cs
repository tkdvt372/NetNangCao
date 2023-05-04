namespace BaiTapLonNet.Models
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string HoVaTen { get; set; }
        public string CCCD { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public List<BatDongSan> BatDongSans { get; set;}
    }
}
