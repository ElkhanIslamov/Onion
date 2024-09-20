using Core.Entities.Common;
using DataAccess.Contexts;
using DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace DataAccess.Repository.Implementation;
public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<T>> GetAllAsync(params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }
    public async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.Where(expression).ToListAsync();
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task AddAsync(T entity)
    => await _context.Set<T>().AddAsync(entity);
    public void UpdateAsync(T entity)
    => _context.Set<T>().Update(entity);
    public void DeleteAsync(T entity)
    => _context.Set<T>().Remove(entity);
    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> extension, params string[] includes)
    {
        var query = _context.Set<T>().AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return await query.AnyAsync(extension);
    }

    public async Task<int> SaveAsync()
    => await _context.SaveChangesAsync();


}
