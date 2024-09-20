using Core.Entities.Common;
using System.Linq.Expressions;
using System.Xml.XPath;

namespace DataAccess.Repository.Interface;

public interface IRepository<T> where T: BaseEntity
{
	Task<List<T>>GetAllAsync(params string[] includes);
	Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> expression, params string[] includes);
	Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, params string[] includes);
	Task AddAsync(T entity);
	void UpdateAsync(T entity);
	void DeleteAsync(T entity);
	Task<bool> IsExistAsync(Expression<Func<T,bool>> extension, params string[] includes);
	Task<int> SaveAsync();

}
