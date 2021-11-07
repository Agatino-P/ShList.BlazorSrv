using ShList.BlazorSrv.Models;
using ShList.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services.Interfaces
{
    public interface IRestService<T,K>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(K key);
        Task<T> AddOrUpdate(T t);
        Task<bool> Delete(T t);
    }
}