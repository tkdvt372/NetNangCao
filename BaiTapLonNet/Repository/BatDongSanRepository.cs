using BaiTapLonNet.Interface.Repository;
using BaiTapLonNet.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonNet.Repository
{
    public class BatDongSanRepository : CommonRepository<BatDongSan>, IBatDongSanRepository
    {
        public BatDongSanRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
