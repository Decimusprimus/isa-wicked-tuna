using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WickedTunaInfrastructure;

namespace WickedTunaAPI.util
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WickedTunaDbContext _context = null;
        private DbSet<T> _collection = null;

        public Repository(WickedTunaDbContext context)
        {
            _context = context;
            _collection = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = _collection.Find(id);
            _collection.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return _collection.ToList();
        }

        public T GetById(object id)
        {
            return _collection.Find(id);
        }

        public void Insert(T obj)
        {
            _collection.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            //TODO: Check later
            _collection.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
