using DataAccessLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.CachedRepository
{
    public abstract class CachedRepository<T> : GenericRepository<T> where T : class, new()
    {
        public virtual string GetClassName()
        {
            return typeof(T).FullName;
        }

        private void LoadIfNecessary(MemoryCache cache, string className)
        {
            if (cache[className] == null)
            {
                IQueryable<T> objT = dbSet;
                cache[className] = objT.ToList();
            }
        }

        public override IEnumerable<T> GetAll()
        {
            var cache = MemoryCache.Default;
            string className = GetClassName();
            LoadIfNecessary(cache, className);
            return (IEnumerable<T>)cache[className];
        }

        public override IEnumerable<T> FilterByParam(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var cache = MemoryCache.Default;
            string className = GetClassName();
            LoadIfNecessary(cache, className);
            return ((IQueryable<T>)cache[className]).Where(predicate).ToList();
        }

        public override T First(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var cache = MemoryCache.Default;
            string className = GetClassName();
            LoadIfNecessary(cache, className);
            return ((IEnumerable<T>)cache[className]).AsQueryable().FirstOrDefault(predicate);
        }

        public override void Save()
        {
            base.Save();

            var cache = MemoryCache.Default;
            string className = GetClassName();
            cache.Remove(className);
        }
    }
}
