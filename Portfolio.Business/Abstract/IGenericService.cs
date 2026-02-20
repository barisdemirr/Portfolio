using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsertAsync(T entity);
        Task TDeleteAsync(T entity);
        Task TUpdateAsync(T entity);
        Task<List<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(int id);
        Task<int> TCountAsync();
    }
}
