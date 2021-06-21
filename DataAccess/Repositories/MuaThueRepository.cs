using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MuaThueRepository : BaseRepository<MuaThueNha>
    {
        public new MuaThueNha Create(MuaThueNha muaThueNha)
        {
            muaThueNha.NgayGiaoDich = DateTime.Now;

            var result = base.Create(muaThueNha);
            if (result != null)
            {
                Save();
            }

            return result;
        }

        public IQueryable<MuaThueNha> Search(string tenKhach, decimal minValue, decimal maxValue)
        {
            return null;
        }
    }
}
