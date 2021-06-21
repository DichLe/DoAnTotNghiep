using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public static class StaticEntity
    {
        /// <summary>
        /// Phân trang cho classes.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IQueryable<object> GetPage(this IQueryable<object> list, int? index, int? size)
        {
            var page = index ?? 1;
            var pageSize = size ?? 12;
            return list.OrderBy(x => "").Skip((page - 1) * pageSize);
        }

        public static decimal SumTotalValue(this ICollection<ChiTietMuaThue> data)
        {
            if (data != null)
            {
                return data.Sum(s => s.Gia.Value);
            }

            return 0;
        }
    }
}
