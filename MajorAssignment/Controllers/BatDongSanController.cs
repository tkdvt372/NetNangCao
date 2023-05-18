using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Manager;
using BaiTapLonNet.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BaiTapLonNet.Controllers
{
    public class BatDongSanController : Controller
    {

        private readonly IBatDongSanManager _batDongSanManager;
        private readonly ITaiKhoanManager _taiKhoanManager;
        private readonly IChiTietVanPhongManager _chiTietVanPhongManager;
        
        public BatDongSanController(BatDongSanManager batDongSanManager, TaiKhoanManager taiKhoanManager,ChiTietVanPhongManager chiTietVanPhong)
        {
            _batDongSanManager = batDongSanManager;
            _taiKhoanManager = taiKhoanManager;
            _chiTietVanPhongManager = chiTietVanPhong;
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
        public async Task<IActionResult> KyGui(IFormFileCollection files)
        {
            string email =  HttpContext.Session.GetString("email");
            if (email == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            var cloudinary = new Cloudinary(new Account("df6xlriko", "672971318197823", "Rq88j3TExUXgfEgQUNomHBGWEpg"));
            var hoso = _taiKhoanManager.HoSo(email);
            BatDongSan temp = new BatDongSan();
            temp.HinhAnh = new List<string> {};
            
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
                }
            }
            temp.TenToaNha = Request.Form["ten"];
            temp.DienTichSan = Double.Parse(Request.Form["dsan"]);
            temp.DienTichChoThue = Double.Parse(Request.Form["dthue"]);
            temp.PhiQuanLy = Double.Parse(Request.Form["quanly"]);
            temp.VAT = Double.Parse(Request.Form["vat"]);
            temp.PhiGuiOto = Double.Parse(Request.Form["oto"]);
            temp.PhiGuiXeMay = Double.Parse(Request.Form["xemay"]);
            temp.SoDienThoai = Request.Form["sdt"];
            temp.Gia = Double.Parse(Request.Form["gia"]);
            temp.DiaChi = Request.Form["sonha"] + ", " + Request.Form["tinh"] + ", " + Request.Form["huyen"] + ", " + Request.Form["xa"];
            temp.SoTang = Int32.Parse(Request.Form["tang"]);
            temp.Loai = Request.Form["loai"];
            temp.MaTaiKhoan = hoso.MaTaiKhoan;
            var isSaved = _batDongSanManager.Add(temp);
            if (isSaved)
            {
                return RedirectToAction("HoSo", "TaiKhoan");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ChiTiet(int id)
        {
            var bds = _batDongSanManager.GetBDSById(id);
            return View(bds);
        }
    

        [HttpGet]
        public IActionResult Sua(int id)
        {
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            var result = _batDongSanManager.GetBDSById(id);
            var chitiet = _chiTietVanPhongManager.GetFirstOrDefault(e => e.MaBatDongSan == result.MaBatDongSan);
            ViewBag.ChiTiet = chitiet;
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult>  Sua(BatDongSan batDongSan,IFormCollection form,IFormFileCollection files)
        {
            string email = HttpContext.Session.GetString("email");
            if (email == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            var bds = _batDongSanManager.GetBDSById(batDongSan.MaBatDongSan);
            var hoso = _taiKhoanManager.HoSo(email);
            batDongSan.MaTaiKhoan = hoso.MaTaiKhoan;
            if (files.Count > 0)
            {
                
                var cloudinary = new Cloudinary(new Account("df6xlriko", "672971318197823", "Rq88j3TExUXgfEgQUNomHBGWEpg"));
                if (bds.HinhAnh.Count > 0)
                {
                    foreach (var url in bds.HinhAnh)
                    {
                        var uri = new Uri(url);
                        var publicId = uri.Segments.Last().Split('.')[0];
                        var deleteParams = new DeletionParams(publicId);
                        cloudinary.Destroy(deleteParams);
                    }
                }
                batDongSan.HinhAnh = new List<string> { };
                
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileName, file.OpenReadStream())
                        };
                        var uploadResult = cloudinary.Upload(uploadParams);
                        batDongSan.HinhAnh.Add(uploadResult.SecureUrl.AbsoluteUri);
                    }
                }
            }
            else
            {
                batDongSan.HinhAnh = bds.HinhAnh;
            }

            ChiTietVanPhong temp;
            var chitiet = _chiTietVanPhongManager.GetFirstOrDefault(e => e.MaBatDongSan == batDongSan.MaBatDongSan);
            if (chitiet == null)
            {
                temp = new ChiTietVanPhong() { MaBatDongSan = batDongSan.MaBatDongSan};
            }
            else
            {
                temp = chitiet;
            }
            List<string> list = new List<string>();
            List<string> inputNames = new List<string>();
            foreach (string key in form.Keys)
            {
                if (key.StartsWith("input-"))
                {
                    inputNames.Add(key);
                }
            }
            int inputCount = inputNames.Count;
            if (inputCount > 2)
            {
                for (int i = 1; i <= inputCount; i++)
                {
                    string inputName = "input-" + i;
                    if (inputNames.Contains(inputName))
                    {
                        string inputValue = form[inputName];
                        list.Add(inputValue);
                    }
                }
            }
            List<string> outputArray = new List<string> { };
            int h, k;
            for (h = 0, k = 0; h < list.Count; h += 2, k++)
            {
                if (h == list.Count - 1)
                {
                    outputArray.Add(list[h]);
                }
                else
                {
                    outputArray.Add(list[h] + ":" + list[h + 1]);
                }
            }
            _batDongSanManager.Update(batDongSan);
            
            temp.TongQuan.Clear();
            temp.TongQuan = outputArray;
            temp.MaBatDongSan = batDongSan.MaBatDongSan;
            var test = _chiTietVanPhongManager.GetFirstOrDefault(x => x.MaBatDongSan == bds.MaBatDongSan);
            if (test != null)
            {
                _chiTietVanPhongManager.Update(temp);
            }
            else
            {
                _chiTietVanPhongManager.Add(temp);
               
            }
            
            return RedirectToAction("HoSo", "TaiKhoan");
        }
    }
}
