using BaiTapLonNet.Interface.Repository;
using BaiTapLonNet.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaiTapLonNet.Repository
{
    public class TaiKhoanRepository : CommonRepository<TaiKhoan>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
