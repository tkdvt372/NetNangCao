using BaiTapLonNet.Models;
using EF.Core.Repository.Interface.Manager;

namespace BaiTapLonNet.Interface.Manager
{
    public interface ITaiKhoanManager:ICommonManager<TaiKhoan>
    {
        public TaiKhoan DangNhap(string email, string matkhau);
        public bool DoiMatKhau(string email,string matkhau);
        public bool DangKy(TaiKhoan taiKhoan);
        public TaiKhoan HoSo(string? email);
    }
}
