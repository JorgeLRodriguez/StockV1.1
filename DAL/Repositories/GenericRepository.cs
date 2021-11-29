using DAL.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : IdentityBase, new()
    {
        private readonly DatabaseContext _db;
        public GenericRepository(DatabaseContext repository)
        {
            _db = repository;
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<T> query = _db.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var entity = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var model in entity)
            {
                query = query.Include(model);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query.ToList();
        }
        public virtual void Update(T entity)
        {
            entity.ChangedBy = Environment.UserName;
            entity.ChangedOn = DateTime.Now;
            _db.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(Guid id)
        {
            var entity = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(entity);
        }
        public virtual T Create(T entity)
        {
            entity.CreatedBy = Environment.UserName;
            entity.CreatedOn = DateTime.Now;
            _db.Set<T>().Add(entity);
            return entity;
        }
        public T GetById(Guid id)
        {
            return _db.Set<T>().SingleOrDefault(x => x.ID == id);
        }
    }
}