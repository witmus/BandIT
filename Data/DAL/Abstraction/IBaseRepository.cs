using BandIT.Models.Entities.Abstract;

namespace BandIT.Data.DAL.Abstraction
{
    public interface IBaseRepository<T> where T : BandEntity<T>
    {
        public Task<T> GetByIdAsync(int id);
        public IQueryable<T> GetByBandId(int bandId);

        public Task<T> CreateAsync(T entity);
        public T Update(T entity);
        public T Delete(T entity);

        public Task<int> CommitAsync();
    }
}
