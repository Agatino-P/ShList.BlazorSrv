using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services;
using ShList.Dto;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ProductDetail
    {
        [Parameter]
        public string ProductId { get; set; }

        [Inject]
        private ProductService _productService { get; set; }

        private Product _product { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProductDto dto =await _productService.Get(ProductId);
            _product = new Product(dto);

            Debug.WriteLine($"product got:{_product.Name}");
            await base.OnInitializedAsync();
        }
    }
}
