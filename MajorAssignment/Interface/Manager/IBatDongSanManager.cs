using BaiTapLonNet.Models;
using EF.Core.Repository.Interface.Manager;

namespace BaiTapLonNet.Interface.Manager
{
    public interface IBatDongSanManager: ICommonManager<BatDongSan>
    {
        BatDongSan GetBDSById(int id);
        List<BatDongSan> TimKiem(string loai = "", string tukhoa = "", string tinh = "", string huyen = "", string xa = "",double dientich=0,double gia=0);
    }

}
