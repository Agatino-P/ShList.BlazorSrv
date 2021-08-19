﻿using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Pages;
using ShList.BlazorSrv.Services.Interfaces;
using ShList.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services.Models
{
    public class ProductService : IProductService
    {
        private HttpClient _httpClient { get; set; }

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var dtos = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("/api/Products");
            //TODO Check the result and act accordingly
            return dtos.Select(dto => new Product(dto));
        }

        public async Task<Product> Get(string productId)
        {
            ProductDto dto = await _httpClient.GetFromJsonAsync<ProductDto>($"/api/Products/{productId}");
            //TODO Check the result and act accordingly
            return new Product(dto);
        }

        public async Task<Product> AddOrUpdate(Product product)
        {
            ProductDto dto = new ProductDto(product.Id, product.Name, product.Notes);
            //TODO Check the result and act accordingly.
            await _httpClient.PostAsJsonAsync<ProductDto>($"/api/Products",dto);
            return product; //Quick and dirty because I know product is not changed, but the right way is to deserialize the outcome of a successful post
        }
    }
}
