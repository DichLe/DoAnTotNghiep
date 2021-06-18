using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GiaNhaRepository : BaseRepository<GiaNha>
    {
        public GiaNha GetGiaHienTaiTheoNha(int maNha, int type)
        {
            return GetAll().FirstOrDefault(g => g.MaNha == maNha && g.MaLoaiGia == type && !g.NgayKetThuc.HasValue);
        }

        public IQueryable<GiaNha> GetLichSuGia(int maNha, int type)
        {
            return GetAll().Where(g => g.MaNha == maNha && g.MaLoaiGia == type);
        }

        public new GiaNha Create(GiaNha giaNha)
        {
            giaNha.NgayKetThuc = null;
            if (giaNha.MaNha.HasValue && giaNha.MaLoaiGia.HasValue)
            {
                var dsGiaNha = GetLichSuGia(giaNha.MaNha.Value, giaNha.MaLoaiGia.Value);
                foreach (var item in dsGiaNha)
                {
                    if (!item.NgayKetThuc.HasValue)
                    {
                        item.NgayKetThuc = DateTime.Now;
                    }
                }
            }
            Save();
            return base.Create(giaNha);
        }
    }
}
