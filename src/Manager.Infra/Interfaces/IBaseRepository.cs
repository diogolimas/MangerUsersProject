using Manager.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T: Base{
       
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Remove(T obj);
        Task<T> Get(T obj);
        Task<List<T>> Get(T obj);
        
    }
}