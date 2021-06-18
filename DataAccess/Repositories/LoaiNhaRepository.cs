using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class LoaiNhaRepository : BaseRepository<LoaiNha>
    {
        public IQueryable<LoaiNha> ThemLoaiNhas(IQueryable<LoaiNha> loaiNhas)
        {
            foreach (var item in loaiNhas)
            {
                var temp = this.Create(item);
                if (temp == null)
                {
                    return null;
                }
            }
            this.Save();
            return loaiNhas;
        }
    }
}
