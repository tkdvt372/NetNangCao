using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Manager;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapLonNet.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly IBatDongSanManager _batDongSanManager;
        private readonly ITaiKhoanManager _taiKhoanManager;
        private readonly IChiTietVanPhongManager _chiTietVanPhongManager;
        public HomeController(BatDongSanManager batDongSanManager,TaiKhoanManager taiKhoanManager,ChiTietVanPhongManager chiTietVanPhongManager)
        {
            _batDongSanManager = batDongSanManager;
            _taiKhoanManager = taiKhoanManager;
            _chiTietVanPhongManager = chiTietVanPhongManager;
        }
        public IActionResult Index()
        {
            string email = HttpContext.Session.GetString("email");
            var taikhoan = _taiKhoanManager.GetFirstOrDefault(x => x.Email == email);  
            if (taikhoan == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan",new { area = "" });
            }
            ViewBag.taikhoan = taikhoan;
            return View(taikhoan);
        }
    }
}
