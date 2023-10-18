using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Datalager.Repository
{


    public class Repository<T>
        where T : class
    {
        internal DbContext context;
        internal DbSet<T> dbSet;
        //protected DbSet<T> Table { get; }


        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        /// <summary>
        ///  Add a new entity to the Table.
        /// </summary>
        /// <param name="entity"></param>

        public void Add(T entity)
        {
            dbSet.Add(entity);

        }

        /// <summary>
        /// Uppdate the entity and save changes
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            dbSet.Update(entity);

        }
        /// <summary>
        /// Remove the given entity from the Table.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            dbSet.Remove(entity);

        }

        public virtual IEnumerable<T> GetAll() => dbSet;



        /// <summary>
        ///  Find a set of entities that match a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate);
        }
        /// <summary>
        ///  Find the first entity that match a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T FirstOrDefault(Func<T, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.Where(predicate);
        }

        public T FirstOrDefault(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query.FirstOrDefault(predicate);
        }
    }

}

