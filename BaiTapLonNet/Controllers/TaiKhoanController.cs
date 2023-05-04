using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Manager;
using BaiTapLonNet.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace BaiTapLonNet.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanManager _taiKhoanManager;
        public TaiKhoanController(TaiKhoanManager taiKhoanManager)
        {
            _taiKhoanManager = taiKhoanManager;
        }
        [HttpGet]
        public IActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(string email, string matkhau)
        {
            var taikhoan = _taiKhoanManager.DangNhap(email, matkhau);
            if (taikhoan != null)
            {
                HttpContext.Session.SetString("email", email);
                return RedirectToAction("Index", "BatDongSan");
            }
            else
            {
                ViewBag.Message = "Tài khoản hoặc mật khẩu không chính xác";
                return RedirectToAction("Index", "TaiKhoan");
            }
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(TaiKhoan taiKhoan)
        {
            string message = "";
            bool check = _taiKhoanManager.DangKy(taiKhoan);
            if (check)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                message = "Thêm sản phẩm thất bại";
            }
            ViewBag.Message = message;
            return View();
        }
        public IActionResult DangXuat()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Index", "Home");
        }
        public IActionResult HoSo()
        {
            string email = HttpContext.Session.GetString("email");
            var hoso = _taiKhoanManager.HoSo(email);
            return View(hoso);
        }
        public IActionResult SuaThongTin()
        {
            string email = HttpContext.Session.GetString("email");
            var hoso = _taiKhoanManager.HoSo(email);
            return View(hoso);
        }
        [HttpPost]
        public IActionResult SuaThongTin(TaiKhoan taiKhoan)
        {
            _taiKhoanManager.Update(taiKhoan);
            return RedirectToAction("HoSo", "TaiKhoan");
        }
        public IActionResult DoiMatKhau()
        {
            return View();
        }
    }
}
