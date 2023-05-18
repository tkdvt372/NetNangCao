using BaiTapLonNet.Data;
using BaiTapLonNet.Interface.Manager;
using BaiTapLonNet.Interface.Repository;
using BaiTapLonNet.Models;
using BaiTapLonNet.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;

namespace BaiTapLonNet.Manager
{
    public class ChiTietVanPhongManager : CommonManager<ChiTietVanPhong>, IChiTietVanPhongManager
    {
        public ChiTietVanPhongManager(ApplicationDbContext dbContext) : base(new ChiTietVanPhongRepository(dbContext))
        {
        }
    }
}
