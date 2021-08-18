using Microsoft.AspNetCore.Components;
using ShList.Dto;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ProductDto>> Get()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("/api/Products");
        }

        public async Task<ProductDto> Get(string productId)
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"/api/Products/{productId}");
        }
    }
}
