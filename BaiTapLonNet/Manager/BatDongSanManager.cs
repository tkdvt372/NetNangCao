using BaiTapLonNet.Data;
using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Models;
using BaiTapLonNet.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace BaiTapLonNet.Manager
{
    public class BatDongSanManager : CommonManager<BatDongSan>, IBatDongSanManager
    {
        public BatDongSanManager(ApplicationDbContext dbContext) : base(new BatDongSanRepository(dbContext))
        {
        }

        public BatDongSan GetBDSById(int id)
        {
            return GetFirstOrDefault(e => e.MaBatDongSan == id);
        }

        public List<BatDongSan> TimKiem(string loai = "", string tukhoa = "", string tinh = "", string huyen = "", string xa = "", double dientich = 0, double gia = 0)
        {
            if (loai == "Loại")
                loai = "";
            if (tinh == "Tỉnh")
                tinh = "";
            if (huyen == "Quận/huyện")
                huyen = "";
            if (xa == "Phường/Xã")
                xa = "";

            var batDongSans = GetAll().ToList();
            if (loai == "")
            {

                if (dientich == 0 && gia == 0)
                {
                    var result = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia > 0
                                 select b;
                    return result.ToList();
                }
                else if (gia == 0)
                {
                    if (dientich <= 50)
                    {
                        var kq = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa) && b.DienTichChoThue < dientich
                                  && b.Gia > 0
                                 select b;
                        return kq.ToList();
                    }
                    if (dientich == 351)
                    {
                        var kq = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa) && b.DienTichChoThue >= dientich
                                  && b.Gia > 0
                                 select b;
                        return kq.ToList();
                    }
                    var result = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa) && b.DienTichChoThue < dientich
                                 && b.DienTichChoThue >= (dientich - 50) && b.Gia > 0
                                 select b;
                    return result.ToList();
                }
                else if (dientich == 0)
                {
                    if (gia == 100)
                    {
                        var kq = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia < gia
                                 select b;
                        return kq.ToList();
                    }
                    if (gia == 601)
                    {
                        var kq = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia > gia
                                 select b;
                        return kq.ToList();
                    }
                    var result = from b in batDongSans
                                 where b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia < gia
                                 && b.Gia >= (gia - 100)
                                 select b;
                    return result.ToList();
                }
                if (dientich == 351 && gia == 601)
                {
                    var results1 = from b in batDongSans
                                   where b.TenToaNha.Contains(tukhoa)
                                   && b.TenToaNha.Contains(tukhoa)
                                   && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                   && b.DiaChi.Contains(xa)
                                   && b.DienTichChoThue > dientich
                                   && b.Gia > gia
                                   select b;
                    return results1.ToList();
                }
                else if (dientich == 351)
                {
                    var results1 = from b in batDongSans
                                   where b.TenToaNha.Contains(tukhoa)
                                   && b.TenToaNha.Contains(tukhoa)
                                   && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                   && b.DiaChi.Contains(xa)
                                   && b.DienTichChoThue > dientich
                                   && b.Gia < gia && b.Gia >= (gia - 100)
                                   select b;
                    return results1.ToList();
                }
                else if (gia == 601)
                {
                    var results1 = from b in batDongSans
                                   where b.TenToaNha.Contains(tukhoa)
                                   && b.TenToaNha.Contains(tukhoa)
                                   && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                   && b.DiaChi.Contains(xa)
                                   && b.DienTichChoThue < dientich
                                   && b.DienTichChoThue >= (dientich - 50)
                                   && b.Gia > gia
                                   select b;
                    return results1.ToList();
                }
                var results = from b in batDongSans
                              where b.TenToaNha.Contains(tukhoa)
                              && b.TenToaNha.Contains(tukhoa)
                              && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                              && b.DiaChi.Contains(xa)
                              && b.DienTichChoThue < dientich
                              && b.DienTichChoThue >= (dientich - 50)
                              && b.Gia < gia && b.Gia >= (gia - 100)
                              select b;
                return results.ToList();
            }
            else
            {
                if (dientich == 0 && gia == 0)
                {
                    var result = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia > 0
                                 select b;
                    return result.ToList();
                }
                else if (gia == 0)
                {
                    if (dientich == 50)
                    {
                        var kq = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa) && b.DienTichChoThue < dientich
                                  && b.Gia > 0
                                 select b;
                        return kq.ToList();
                    }
                    if(dientich == 351)
                    {
                        var kq = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa) && b.DienTichChoThue > dientich
                                  && b.Gia > 0
                                 select b;
                        return kq.ToList();
                    }
                    var result = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa) && b.DienTichChoThue < dientich
                                 && b.DienTichChoThue >= (dientich - 50) && b.Gia > 0
                                 select b;
                    return result.ToList();
                }
                else if (dientich == 0)
                {
                    if (gia <= 100)
                    {
                        var kq = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia < gia
                                 select b;
                        return kq.ToList();
                    }
                    if(gia == 601)
                    {
                        var kq = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia > gia
                                 select b;
                        return kq.ToList();
                    }
                    var result = from b in batDongSans
                                 where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                 && b.TenToaNha.Contains(tukhoa)
                                 && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                 && b.DiaChi.Contains(xa)
                                 && b.DienTichChoThue > 0 && b.Gia < gia
                                 && b.Gia > (gia - 100)
                                 select b;
                    return result.ToList();
                }
                if (dientich == 351 && gia == 601)
                {
                    var results1 = from b in batDongSans
                                   where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                   && b.TenToaNha.Contains(tukhoa)
                                   && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                   && b.DiaChi.Contains(xa)
                                   && b.DienTichChoThue > dientich
                                   && b.Gia > gia
                                   select b;
                    return results1.ToList();
                }
                else if (dientich == 351)
                {
                    var results1 = from b in batDongSans
                                   where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                   && b.TenToaNha.Contains(tukhoa)
                                   && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                   && b.DiaChi.Contains(xa)
                                   && b.DienTichChoThue > dientich
                                   && b.Gia < gia && b.Gia >= (gia - 100)
                                   select b;
                    return results1.ToList();
                }
                else if (gia == 601)
                {
                    var results1 = from b in batDongSans
                                   where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                                   && b.TenToaNha.Contains(tukhoa)
                                   && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                                   && b.DiaChi.Contains(xa)
                                   && b.DienTichChoThue < dientich
                                   && b.DienTichChoThue >= (dientich - 50)
                                   && b.Gia > gia
                                   select b;
                    return results1.ToList();
                }
                var results = from b in batDongSans
                              where b.Loai == loai && b.TenToaNha.Contains(tukhoa)
                              && b.DiaChi.Contains(tinh) && b.DiaChi.Contains(huyen)
                              && b.DiaChi.Contains(xa) && b.DienTichChoThue < dientich
                              && b.DienTichChoThue >= (dientich - 50)
                              && b.Gia < gia && b.Gia >= (gia - 100)
                              select b;
                return results.ToList();
            }
        }
    }
}
