using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ProductEdit
    {
        [Parameter]
        public string ProductId { get; set; }

        [Inject]
        private IProductService _productService { get; set; }

    [Inject]
        private NavigationManager _navigationManager { get; set; }

        //For UI
        protected string Message { get; set; }
        protected string StatusClass { get; set; } = "alert-success";
        protected bool Saved { get; set; } = true;

        protected enum ModeEnum { Edit, Add }
        protected ModeEnum Mode { get; set; }

        private Product _product { get; set; }

        //public string Name { get; set; }
        //public string Notes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(ProductId))
            {
                Mode = ModeEnum.Add;
                _product = new Product();
                Saved = true;
            }
            else
            {
                Mode = ModeEnum.Edit;
                _product = await _productService.Get(ProductId);
                Saved = false;
            }
            await base.OnInitializedAsync();
        }

        protected void         NavigateToProducts()
        {
            _navigationManager.NavigateTo("/products");
        }

        protected async Task HandleValidSubmit()
        {
            _product = await _productService.AddOrUpdate(_product);
            Saved = true;
            Message = "Saved!";
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Invalid Data";
            //_product = await _productService.AddOrUpdate(_product);
        }



    }
}
