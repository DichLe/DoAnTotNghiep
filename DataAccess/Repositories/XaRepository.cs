using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class XaRepository:BaseRepository<Ward>
    {
        public IQueryable<Ward> GetXaByHuyen(int maHuyen)
        {
            return GetAll().Where(x=>x.DistrictID== maHuyen);
        }
    }
}
