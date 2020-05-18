using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCity3.Api.Model
{
    public class EFRepository : IRepository
    {

        MyCity3DbContext _dbctx;
        public EFRepository(MyCity3DbContext dbctx)
        {
            _dbctx = dbctx;
        }

        public IEnumerable<T> GetAll<T>() where T:class
        {
            return _dbctx.Set<T>();
        }

        public T GetOne<T>(int id) where T : class
        {
            return _dbctx.Find<T>(id);
        }

        public void Insert<T>(T entity) where T : class
        {
            _dbctx.Set<T>().Add(entity);
            _dbctx.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _dbctx.Set<T>().Update(entity);
            _dbctx.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _dbctx.SaveChanges();
        }
    }
}
