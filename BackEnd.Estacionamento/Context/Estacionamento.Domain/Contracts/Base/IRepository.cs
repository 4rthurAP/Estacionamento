using Estacionamento.Domain.Models.Base;
using System.Linq.Expressions;

namespace Estacionamento.Domain.Contracts.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<TEntity> SaveAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int? id);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}
