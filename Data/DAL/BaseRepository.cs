using BandIT.Data.DAL.Abstraction;
using BandIT.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BandIT.Data.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BandEntity<T>
    {
        protected readonly ApplicationDbContext _db;
        protected readonly ILogger<T> _logger;

        public BaseRepository(ApplicationDbContext db, ILogger<T> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IQueryable<T> GetByBandId(int bandId)
        {
            return _db
                .Set<T>()
                .Where(entity => entity.BandId == bandId)
                .AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db
                .Set<T>()
                .FirstOrDefaultAsync(entity => entity.Id == id)
                ?? throw new ArgumentException($"INVALID_ID {id}");
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                var result = await _db
                    .Set<T>()
                    .AddAsync(entity);

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.InnerException?.Message ?? "");
                return entity;
            }
        }

        public T Delete(T entity)
        {
            try
            {
                var result = _db
                    .Set<T>()
                    .Remove(entity);

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.InnerException?.Message ?? "");
                return entity;
            }
        }

        public T Update(T entity)
        {
            try
            {
                var result = _db
                    .Set<T>()
                    .Update(entity);

                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + ex.InnerException?.Message ?? "");
                return entity;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
