//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;

//public class Repository<T> : IRepository<T> where T : class
//{
//    protected BokningDbContext Context { get; }
//    protected DbSet<T> Table { get; }

//    protected Repository(BokningDbContext context)
//    {
//        Context = context;
//        Table = Context.Set<T>();
//    }

//    // Create Read Update Delete (CRUD)
//    // Create
//    public virtual T Add(T entity) { Table.Add(entity); return entity; }
//    public virtual IEnumerable<T> AddRange(IEnumerable<T> entities) { Table.AddRange(entities); return entities; }

//    // Read
//    public virtual T Find(int id) => Table.Find(id);
//    public virtual T FirstOrDefault(Func<T, bool> predicate) => Table.FirstOrDefault(predicate);
//    public virtual IEnumerable<T> Find(Func<T, bool> predicate) => Table.Where(predicate);
//    public virtual IEnumerable<T> GetAll() => Table;
//    public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null!,
//                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null!,
//                                      params Expression<Func<T, object>>[] includes)
//    {
//        IQueryable<T> query = Table;
//        foreach (var include in includes) { query = query.Include(include); }
//        query = (filter != null) ? query.Where(filter) : query;
//        query = (orderBy != null) ? orderBy(query) : query;
//        return query.ToList();
//    }

//    public virtual IEnumerable<T> Query(Func<IQueryable<T>, IQueryable<T>> query) => query(Table);

//    // Update
//    public virtual void Update(T entity) => Table.Update(entity);
//    public virtual T Update(T oldEntity, T newEntity)
//    {
//        Context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
//        Table.Update(oldEntity);
//        return oldEntity;
//    }
//    public virtual void UpdateRange(IEnumerable<T> entities) => Table.UpdateRange(entities);
//    // Delete
//    public virtual void Delete(int id)
//    {
//        var entity = Table.Find(id);
//        if (entity != null)
//            Context.Entry(entity).State = EntityState.Deleted;
//    }
//    public virtual T Delete(T entity) { Table.Remove(entity); return entity; }
//    public virtual void DeleteRange(IEnumerable<T> entities) => Table.RemoveRange(entities);


//}