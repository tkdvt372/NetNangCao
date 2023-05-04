using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Manager;
using BaiTapLonNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Linq;

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
        /*[HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BatDongSan batDongSan)
        {
            string message = "";
            bool isSaved = _batDongSanManager.Add(batDongSan);
            if (isSaved)
            {
                return RedirectToAction("TrangChu", "Home");
            }
            else
            {
                message = "Thêm BDS thất bại";
            }
            ViewBag.Message = message;
            return View();
        }*/

        [HttpGet]
        public IActionResult ChiTiet(int id)
        {
            var bds = _batDongSanManager.GetBDSById(id);
            return View(bds);
        }
    }
}
