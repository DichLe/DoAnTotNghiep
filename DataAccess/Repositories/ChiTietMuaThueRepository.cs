
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ChiTietMuaThueRepository : BaseRepository<ChiTietMuaThue>
    {
        public IQueryable<ChiTietMuaThue> CreateCTMTs(IQueryable<ChiTietMuaThue> chiTietMuaThues, int maMuaThue)
        {
            foreach (var item in chiTietMuaThues)
            {
                item.MaMuaThue = maMuaThue;
                var rs = Create(item);
                if (rs == null)
                {
                    return null;
                }
            }

            Save();
            return chiTietMuaThues;
        }
    }
}
