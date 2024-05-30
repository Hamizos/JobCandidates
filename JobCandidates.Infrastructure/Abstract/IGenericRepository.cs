namespace JobCandidates.Infrastructure.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        IQueryable<T> GetTableNoTracking();
    }
}
