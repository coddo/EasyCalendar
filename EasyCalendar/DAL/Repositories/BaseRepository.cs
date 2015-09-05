using EasyCalendar.DAL.Context;
using EasyCalendar.DAL.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace EasyCalendar.DAL.Repositories
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        internal readonly DatabaseContext _dbContext;
        internal readonly DbSet<T> _dbSet;

        internal BaseRepository(DatabaseContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        #region Persistence logic

        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();

                return true;
            }

            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region CRUD

        public T Get(string id)
        {
            return _dbSet.Find(id);
        }

        public T[] GetAll()
        {
            return _dbSet.ToArray();
        }

        public T Insert(T obj)
        {
            if (obj == null)
                return null;

            if (obj.Id == null || obj.Id == string.Empty || obj.Id == Guid.Empty.ToString())
                obj.Id = Guid.NewGuid().ToString();

            _dbSet.Add(obj);

            return Save() ? _dbSet.Find(obj.Id) : null;
        }

        public T[] InsertAll(T[] objs)
        {
            if (objs == null || objs.Length == 0)
                return null;

            for(int i=0; i < objs.Length; i++)
            {
                if (objs[i].Id == null || objs[i].Id == string.Empty || objs[i].Id == Guid.Empty.ToString())
                    objs[i].Id = Guid.NewGuid().ToString();
            }

            _dbSet.AddRange(objs);

            return Save() ? objs : null;
        }

        public T Update(T obj)
        {
            if (obj == null)
                return null;

            var dbObject = _dbSet.Find(obj.Id);
            dbObject = obj;

            return Save() ? _dbSet.Find(obj.Id) : null;
        }

        public bool Delete(string id)
        {
            return Delete(_dbSet.Find(id));
        }

        public bool Delete(T obj)
        {
            if (obj == null)
                return false;

            if (_dbContext.Entry(obj).State == EntityState.Detached)
                _dbSet.Attach(obj);

            _dbSet.Remove(obj);

            return Save();
        }

        #endregion
    }
}
