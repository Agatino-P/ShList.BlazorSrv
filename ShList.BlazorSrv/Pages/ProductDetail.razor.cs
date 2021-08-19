﻿using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using ShList.Dto;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ProductDetail
    {
        [Parameter]
        public string ProductId { get; set; }

        [Inject]
        private IProductService _productService { get; set; }

        private Product _product { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _product = await _productService.Get(ProductId);
            

            Debug.WriteLine($"product got:{_product.Name}");
            await base.OnInitializedAsync();
        }
    }
}
