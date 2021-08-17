using Microsoft.AspNetCore.Components;
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
        private HttpClient _httpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _productDtos = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Products");
        }
    }
}
