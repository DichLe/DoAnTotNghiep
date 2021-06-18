using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class NhaRepository:BaseRepository<Nha>
    {
        public IQueryable<Nha> GetNhaByLoaiNha(int maLoai)
        {
            return GetAll().Where(n => n.MaLoai == maLoai);
        }

        public IQueryable<Nha> GetNhaTheoDiaChi(int? xa,int?huyen,int? tinh)
        {
            return GetAll().Where(n=>(!xa.HasValue||n.MaXa==xa.Value)&&(!huyen.HasValue || n.MaHuyen == huyen.Value)&&(!tinh.HasValue || n.MaTinh == tinh.Value));
        }

    }
}
