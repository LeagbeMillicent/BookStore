using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(string query);

        Task<int> Add(FormattableString sqlQuery);

        Task<int> Update(FormattableString sqlQuery);

        Task<IEnumerable<TEntity>> GetById(FormattableString sqlQuery);

        Task<int> Delete(FormattableString sqlQuery);
    }

}
