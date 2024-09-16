using Core.Entities.Common;
using DataAccess.Contexts;
using DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository.Implementation;
public class Repository<T> : IRepository<T> where T : BaseEntity
{
	private readonly AppDbContext _context;
	public Repository(AppDbContext context)
	{
		_context = context;
	}
	public async Task<List<T>> GetAllAsync()
	=> await _context.Set<T>().ToListAsync();
	public async Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> expression)
	=> await _context.Set<T>().Where(expression).ToListAsync();
	public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression)
	=> await _context.Set<T>().FirstOrDefaultAsync(expression);
	public async Task AddAsync(T entity)
	=> await _context.Set<T>().AddAsync(entity);
	public void UpdateAsync(T entity)
	=> _context.Set<T>().Update(entity);
	public void DeleteAsync(T entity)
	=> _context.Set<T>().Remove(entity);
	public async Task<bool> IsExistAsync(Expression<Func<T, bool>> extension)
	=> await _context.Set<T>().AnyAsync(extension);
	public async Task<int> SaveAsync()
	=> await _context.SaveChangesAsync();


}
