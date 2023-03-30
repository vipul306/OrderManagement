using Microsoft.EntityFrameworkCore;
using OrderDemo.DataAccess.Data;
using OrderDemo.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace OrderDemo.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDBContext _dbContext;
    internal DbSet<T> dbSet;

    public Repository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
        this.dbSet = _dbContext.Set<T>();
    }
    public void Add(T entity)
    {
        dbSet.Add(entity);
    }
    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if(filter != null)
        {
            query = query.Where(filter);
        }
        if(includeProperties != null)
        {
            foreach(var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return query.ToList();
    }
    public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        if (tracked)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if(includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        } 
        else
        {
            IQueryable<T> query = dbSet.AsNoTracking();
            query = query.Where(filter);
            if(includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
    }
    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }
    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}