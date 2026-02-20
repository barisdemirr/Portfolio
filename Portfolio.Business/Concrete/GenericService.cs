using Portfolio.Business.Abstract;
using Portfolio.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericService(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task TDeleteAsync(T entity)
        {
            await _genericDal.DeleteAsync(entity);
        }

        public async Task<List<T>> TGetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(T entity)
        {
            await _genericDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(T entity)
        {
            await _genericDal.UpdateAsync(entity);
        }

        public async Task<int> TCountAsync()
        {
            return await _genericDal.CountAsync();
        }
    }
}
