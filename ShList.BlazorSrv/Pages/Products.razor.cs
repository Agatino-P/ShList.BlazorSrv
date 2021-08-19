using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using ShList.BlazorSrv.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class Products
    {
        private IEnumerable<Product> _products = new List<Product>();

        [Inject]
        private IProductService _productService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _products = await _productService.Get();

            await base.OnInitializedAsync();
        }
    }
}
