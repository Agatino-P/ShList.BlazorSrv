using ShList.BlazorSrv.Models;
using ShList.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(string productId);
        Task<Product> AddOrUpdate(Product product);
    }
}