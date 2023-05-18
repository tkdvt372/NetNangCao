using BaiTapLonNet.Data;
using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Models;
using BaiTapLonNet.Repository;
using EF.Core.Repository.Interface.Manager;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace BaiTapLonNet.Manager
{
    public class TaiKhoanManager : CommonManager<TaiKhoan>, ITaiKhoanManager
    {
        private readonly string hash = @"foxle@rn";
        public string maHoaMatKhau(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results);
                }
            }
        }
        public TaiKhoanManager(ApplicationDbContext dbContext) : base(new TaiKhoanRepository(dbContext))
        {
        }

        public bool DangKy(TaiKhoan taiKhoan)
        {
            taiKhoan.MatKhau = maHoaMatKhau(taiKhoan.MatKhau);
            return Add(taiKhoan);
        }

        public TaiKhoan DangNhap(string email, string matkhau)
        {
            return GetFirstOrDefault(e => e.Email == email && e.MatKhau == maHoaMatKhau(matkhau));
        }

        public TaiKhoan HoSo(string email)
        {
            return GetFirstOrDefault(p => p.Email == email);
        }

        public bool DoiMatKhau(string email,string matkhau)
        {
            var tk = GetFirstOrDefault(e => e.Email == email);
            var matKhauMoi = maHoaMatKhau(matkhau);
            tk.MatKhau = matKhauMoi;
            return Update(tk);
        }
    }
}
