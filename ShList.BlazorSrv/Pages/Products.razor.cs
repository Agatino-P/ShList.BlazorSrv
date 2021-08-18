using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services;
using ShList.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class Products
    {
        private IEnumerable<Product> _products = new List<Product>();

        [Inject]
        private ProductService _productService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _products = await _productService.Get();

            await base.OnInitializedAsync();
        }
    }
}
