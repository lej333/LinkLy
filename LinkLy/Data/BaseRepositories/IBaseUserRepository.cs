using LinkLy.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkLy.Data.BaseRepositories
{
   public interface IBaseUserRepository<T> where T : class, IUserEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
