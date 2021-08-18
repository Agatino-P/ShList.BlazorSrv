using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services
{
    public class ProductService
    {

        private HttpClient _httpClient { get; set; }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var dtos=await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("/api/Products");
            return dtos.Select(dto => new Product(dto));
        }

        public async Task<ProductDto> Get(string productId)
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"/api/Products/{productId}");
        }
    }
}
