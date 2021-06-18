using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly DataAccess.Models.NhaDatEntities context;
        protected readonly DbSet<T> entity;
        public BaseRepository()
        {
            context = new NhaDatEntities();
            entity = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return entity;
        }

        public T Create(T obj)
        {
            try
            {
                entity.Add(obj);
                return obj;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T GetById(object id)
        {
            return entity.Find(id);
        }

        public bool Update(T obj)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object id, ref bool isDdeleted)
        {
            var found = GetById(id);
            if (found != null)
            {
                if (isDdeleted == true)
                {
                    return false;
                }
                isDdeleted = true;
                return true;
            }

            return false;
        }

        protected void Save()
        {
            context.SaveChanges();
        }

        protected void Dispose()
        {
            context.Dispose();
        }
    }
}
