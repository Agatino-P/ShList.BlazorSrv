using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ShoppingLists : ComponentBase
    {
        private IEnumerable<Product> _products = new List<Product>();

        [Inject]
        private IRestService<Product> _productService { get; set; }

        protected ConfirmProductDelete ConfirmProductDeleteDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await getAllProducts();
            await base.OnInitializedAsync();
        }

        protected async Task RefreshCmd()
        {
            await getAllProducts();
            StateHasChanged();
        }

        private async Task getAllProducts()
        {
            _products = await _productService.Get();
        }

        protected void ShowDeleteProductCmd(Product product)
        {
            ConfirmProductDeleteDialog.Product = product;
            ConfirmProductDeleteDialog.Show(product);
        }

        public async void ProductDeleteCallBack(Product product)
        {
            if (product != null)
            {
                bool deleted = await _productService.Delete(product);
                await RefreshCmd();
            }
        }

    }
}
