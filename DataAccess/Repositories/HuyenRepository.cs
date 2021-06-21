using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class HuyenRepository:BaseRepository<District>
    {
        public IQueryable<District> GetHuyenByTinh(int maTinh)
        {
            return GetAll().Where(h => h.ProvinceId == maTinh);
        }
    }
}
