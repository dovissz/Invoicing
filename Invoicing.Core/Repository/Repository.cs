using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Core.Repository
{
    /// <summary>
    /// Generic repository class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties

        protected readonly DbContext context;
        private DbSet<T> entities;

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes new object or repository
        /// </summary>
        /// <param name="context"></param>
        public Repository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Inserts entity
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(Guid id)
        {
            if (id == null) 
                throw new ArgumentNullException("entity");
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }

        #endregion Methods

    }
}