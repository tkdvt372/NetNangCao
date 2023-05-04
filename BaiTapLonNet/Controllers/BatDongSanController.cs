using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Manager;
using BaiTapLonNet.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapLonNet.Controllers
{
    public class BatDongSanController : Controller
    {

        private readonly IBatDongSanManager _batDongSanManager;
        public BatDongSanController(BatDongSanManager batDongSanManager)
        {
            _batDongSanManager = batDongSanManager;
        }
        public IActionResult Index(string loai = "", string tukhoa = "", string tinh = "", string huyen = "", string xa = "", double dientich=0,double gia=0)
        {
            var results = _batDongSanManager.TimKiem(loai,tukhoa, tinh, huyen, xa,dientich,gia);
            return View(results);

        }
        [HttpPost]
        public IActionResult Search(string tukhoa, string tinh, string huyen, string xa, string loai,string dientich,string gia)
        {
            if (dientich == "Tất cả diện tích"  || dientich == "")
                dientich = "0";
            if(gia == "Tất cả giá" || gia == "")
                gia = "0";
            return RedirectToAction("Index", "BatDongSan",
                new
                {
                    tukhoa = tukhoa,
                    loai = loai,
                    tinh = tinh,
                    huyen = huyen,
                    xa = xa,
                    dientich = Double.Parse(dientich),
                    gia = Double.Parse(gia)
                });
        }
        [HttpGet]
        public IActionResult KyGui()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KyGuiAsync(IFormFileCollection files)
        {
            BatDongSan temp = new BatDongSan();
            temp.HinhAnh = new List<string> {};
            var cloudinary = new Cloudinary(new Account("df6xlriko", "672971318197823", "Rq88j3TExUXgfEgQUNomHBGWEpg"));
            int i = 0;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, file.OpenReadStream())
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    temp.HinhAnh.Add(uploadResult.SecureUrl.AbsoluteUri);
                    i++;
                }
            }
            temp.TenToaNha = Request.Form["ten"];
            return Json(new {temp});
        }

        [HttpGet]
        public IActionResult ChiTiet(int id)
        {
            var bds = _batDongSanManager.GetBDSById(id);
            return View(bds);
        }
        public IActionResult Sua()
        {
            return View();
        }
    }
}
