using Microsoft.AspNetCore.Components;
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
        private IEnumerable<ProductDto> _productDtos = new List<ProductDto>();

        [Inject]
        private ProductService _productService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _productDtos = await _productService.Get();
            

        }
    }
}
