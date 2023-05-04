using BaiTapLonNet.Interface.Repository;
using BaiTapLonNet.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonNet.Repository
{
    public class ChiTietVanPhongRepository : CommonRepository<ChiTietVanPhong>, IChiTietVanPhongRepository
    {
        public ChiTietVanPhongRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
