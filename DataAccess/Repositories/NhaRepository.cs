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
        public IQueryable<Nha> GetNhaByLoaiNha(int maLoai, int? index, int? size)
        {
            var rs = GetAll().Where(n => n.MaLoai == maLoai);
            var y = rs.GetPage(index, size);
            return (IQueryable<Nha>)y;
        }

        public IQueryable<Nha> GetNhaTheoDiaChi(int? xa, int? huyen, int? tinh, int? index, int? size)
        {
            var temp = GetAll().Where(n => (!xa.HasValue || n.MaXa == xa.Value) && (!huyen.HasValue || n.MaHuyen == huyen.Value) && (!tinh.HasValue || n.MaTinh == tinh.Value));
            return (IQueryable<Nha>)temp.GetPage(index, size);
        }

        public IQueryable<Nha> TimKiem(int loaiNha, int xa, int huyen, int tinh, int trangthai, int loaiGia, decimal giaMin, decimal giaMax,int ? index, int? size)
        {
            var loaiG = context.LoaiGias.Find(loaiGia);
            var listGia = context.GiaNhas.Where(g => g.LoaiGia == loaiG && !g.NgayKetThuc.HasValue && g.Gia >= giaMin&&g.Gia <= giaMax);
            var temp = GetAll().Where(s => s.MaHuyen == huyen && s.MaXa == xa && s.MaTinh == tinh &&s.TrangThai==trangthai && s.MaLoai == loaiNha );
            return (IQueryable<Nha>)temp.GetPage(index, size);
        }

        
    }
}
