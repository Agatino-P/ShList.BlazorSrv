using ShList.BlazorSrv.Models;
using ShList.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services.Interfaces
{
    public interface IRestService<T>
    {
        Task<IEnumerable<T>> Get();
        Task<Product> Get(string name);
        Task<Product> AddOrUpdate(T t);
        Task<bool> Delete(T t);
    }
}