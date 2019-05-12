using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace DataAccessLayer.GenericRepository
{
    /****************************************************************************************************
     * Pattern used to reduce the ammount of code for a simple CRUD to tables                           *
     * Shamelessly took advantage of post:                                                              *
     * https://www.codeproject.com/Articles/892087/Entity-Framework-Generic-Repository-classes-for-CR   *
     ****************************************************************************************************/

    public abstract class GenericRepository<T> where T : class, new()
    {
        internal MusicalogEntities entities;
        internal DbSet<T> dbSet;

        public GenericRepository()
        {
            this.entities = new MusicalogEntities();
            this.dbSet = entities.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> objT = dbSet;
            return objT.ToList();
        }

        public virtual IEnumerable<T> FilterByParam(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public virtual T First()
        {
            return dbSet.FirstOrDefault();
        }

        public virtual T First(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public void Insert(T obj)
        {
            dbSet.Add(obj);
        }

        public void Update(T obj)
        {
            dbSet.Attach(obj);
            entities.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T ObjT = dbSet.Find(id);
            if (ObjT != null)
            {
                Delete(ObjT);
            }

        }

        public void Delete(T obj)
        {
            if (entities.Entry(obj).State == EntityState.Detached)
            {
                dbSet.Attach(obj);
            }
            dbSet.Remove(obj);
        }

        public virtual void Save()
        {
            try
            {
                entities.SaveChanges();
            }
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
            catch (Exception)
            {
                throw;
            }

        }

        public void Dispose()
        {
            if (entities != null)
            {
                entities.Dispose();
                entities = null;
            }
        }
    }
}
