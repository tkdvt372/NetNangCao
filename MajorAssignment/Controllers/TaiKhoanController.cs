using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Manager;
using BaiTapLonNet.Models;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net;
using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;

namespace BaiTapLonNet.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly ITaiKhoanManager _taiKhoanManager;
        private readonly IBatDongSanManager _batDongSanManager;
        public TaiKhoanController(TaiKhoanManager taiKhoanManager, BatDongSanManager batDongSanManager)
        {
            _taiKhoanManager = taiKhoanManager;
            _batDongSanManager = batDongSanManager;
        }
        [HttpGet]
        public IActionResult DangNhap()
        {
            ViewBag.text = TempData["text"];
            return View();
        }
        [HttpPost]
        public IActionResult DangNhap(string email, string matkhau)
        {
            var taikhoan = _taiKhoanManager.DangNhap(email, matkhau);
            if (taikhoan != null)
            {
                HttpContext.Session.SetString("email", email);
                return RedirectToAction("HoSo", "TaiKhoan");
            }
            else
            {
                ViewBag.text = "Tài khoản hoặc mật khẩu không chính xác";
                TempData["text"] = ViewBag.text;
                return RedirectToAction("DangNhap", "TaiKhoan");
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
            if (email == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            var hoso = _taiKhoanManager.HoSo(email);
            var taikhoan = _taiKhoanManager.GetAll();
            var bds = _batDongSanManager.GetAll();
            var result = from b in bds
                         join t in taikhoan
                         on b.MaTaiKhoan equals t.MaTaiKhoan
                         where t.MaTaiKhoan == hoso.MaTaiKhoan
                         select new
                         {
                             b.MaBatDongSan,
                             b.HinhAnh,
                             b.TenToaNha,
                             b.DienTichSan,
                             b.DienTichChoThue,
                             b.PhiQuanLy,
                             b.VAT,
                             b.Gia,
                             b.Loai

                         };
            ViewBag.listBDS = result.ToList();
            return View(hoso);
        }
        public IActionResult SuaThongTin()
        {
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
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
        [HttpGet]
        public IActionResult QuenMatKhau()
        {
            ViewBag.text = TempData["text"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> QuenMatKhau(string email)
        {
            var taikhoan = _taiKhoanManager.GetFirstOrDefault(e => e.Email == email);
            if (taikhoan == null)
            {
                ViewBag.text = "Email không tồn tại";
                TempData["text"] = ViewBag.text;
                return RedirectToAction("QuenMatKhau");
            }
            else
            {
                var code = new Random().Next(100000, 999999).ToString();
                MailMessage message = new MailMessage();
                message.From = new MailAddress("dgamedvt0@gmail.com");
                message.To.Add(email);
                message.Subject = "Quên mật khẩu";
                message.Body = "Mã xác minh là: " + code;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("dgamedvt0@gmail.com", "saagghlgdhqfmjev");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
                var codePass = new RouteValueDictionary();
                codePass.Add("code", code);
                codePass.Add("email", email);
                return RedirectToAction("DoiMatKhau", "TaiKhoan", codePass);
            }

        }
        [HttpGet]
        public IActionResult DoiMatKhau(string code,string email)
        {
            ViewBag.text = TempData["text"];
            if (code != null)
            {
                ViewBag.code = code;
            }
            else
            {
                ViewBag.code = TempData["code"];
            }
            if (email != null)
            {
                ViewBag.email = email;
            }
            else
            {
                ViewBag.email = TempData["email"];
            }
            return View();
        }
        [HttpPost]
        public IActionResult DoiMatKhau(string password, string email,string repassword,string code,string confirmcode)
        {
            
            if(password == null || repassword == null || confirmcode == null)
            {
                ViewBag.text = "Vui lòng nhập đầy đủ thông tin";
                ViewBag.code = code;
                ViewBag.email = email;
                TempData["text"] = ViewBag.text;
                TempData["code"] = ViewBag.code;
                TempData["email"] = ViewBag.email;
                return RedirectToAction("DoiMatKhau");
            }else if(password != repassword)
            {
                ViewBag.text = "Mật khẩu không trùng khớp";
                ViewBag.code = code;
                ViewBag.email = email;
                TempData["text"] = ViewBag.text;
                TempData["code"] = ViewBag.code;
                TempData["email"] = ViewBag.email;
                return RedirectToAction("DoiMatKhau");
            }else if(code != confirmcode)
            {
                ViewBag.text = "Mã xác minh không chính xác";
                ViewBag.code = code;
                ViewBag.email = email;
                TempData["text"] = ViewBag.text;
                TempData["code"] = ViewBag.code;
                TempData["email"] = ViewBag.email;
                return RedirectToAction("DoiMatKhau");
            }
            else
            {
                _taiKhoanManager.DoiMatKhau(email, password);
                return RedirectToAction("DangNhap","TaiKhoan");
            }
        }

        [HttpPost]
        public IActionResult ThayAvatar(IFormFile file)
        {
            string email = HttpContext.Session.GetString("email");
            var tk = _taiKhoanManager.GetFirstOrDefault(e => e.Email == email);
            var cloudinary = new Cloudinary(new Account("df6xlriko", "672971318197823", "Rq88j3TExUXgfEgQUNomHBGWEpg"));
            if (tk.HinhAnh != "https://res.cloudinary.com/df6xlriko/image/upload/v1683367962/avt_xl7z3r.jpg")
            {
                var uri = new Uri(tk.HinhAnh);
                var publicId = uri.Segments.Last().Split('.')[0];
                var deleteParams = new DeletionParams(publicId);
                cloudinary.Destroy(deleteParams);
            }
            if (file.Length > 0)
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream())
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                tk.HinhAnh = uploadResult.SecureUrl.AbsoluteUri;
                _taiKhoanManager.Update(tk);
            }
            return RedirectToAction("HoSo","TaiKhoan");
        }
    }
}
