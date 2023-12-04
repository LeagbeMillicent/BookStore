using Books.Application.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Persistence
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly BookDbContext _dbContext;

        public GenericRepository(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Add(FormattableString sqlQuery)
        {
            var response = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);

            await _dbContext.SaveChangesAsync();

            return response;
        }

        public async Task<int> Delete(FormattableString sqlQuery)
        {
            var response = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);

            await _dbContext.SaveChangesAsync();
            return response;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            return await _dbContext.Set<TEntity>().FromSqlRaw(query).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetById(FormattableString sqlQuery)
        {
            return await _dbContext.Set<TEntity>().FromSql(sqlQuery).ToListAsync();

        }

        public async Task<int> Update(FormattableString sqlQuery)
        {
            var response = await _dbContext.Database.ExecuteSqlInterpolatedAsync(sqlQuery);
            await _dbContext.SaveChangesAsync();

            return response;
        }
    }
    
        
    
}

