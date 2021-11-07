using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ShoppingListEdit : ComponentBase
    {
        [Parameter]
        public string strId { get; set; }
        
        private Guid Id { get; set; }
        private List<Product> _selectableProducts = new List<Product>();

        [Inject]
        private IRestService<ShoppingList, Guid> _shoppingListService { get; set; }
        [Inject] 
        private IRestService<Product, string> _productService { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        //For UI
        protected string Message { get; set; }
        protected string StatusClass { get; set; } = "alert-success";
        protected bool Saved { get; set; } = true;

        protected enum ModeEnum { Edit, Add }
        protected ModeEnum Mode { get; set; }

        private ShoppingList _shoppingList { get; set; }

        //public string Name { get; set; }
        //public string Notes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrWhiteSpace(strId) && Guid.TryParse(strId, out Guid parsedId))
            {
                Mode = ModeEnum.Edit;

                Id = parsedId;
                _shoppingList = await _shoppingListService.Get(Id);
                Saved = false;
            }
            else
            {
                Mode = ModeEnum.Add;
                _shoppingList = new ShoppingList();
                Saved = true;
            }

            IEnumerable<Product> products = await _productService.Get();
            _selectableProducts = new List<Product>(products);

            await base.OnInitializedAsync();
        }

        public async void ProductListCallback(Product product)
        {
            _shoppingList.AddItem(product);
            _selectableProducts.Remove(product);
            //Most likely need to arrange something better for reloads, that filters
        }

        protected void OnCancelCmd()
        {
            _navigationManager.NavigateTo("/products");
        }

        protected async Task HandleValidSubmit()
        {
            _shoppingList = await _shoppingListService.AddOrUpdate(_shoppingList);
            Saved = true;
            Message = "Product Saved";
        }

        protected Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Invalid Data";
            return Task.CompletedTask;
        }



    }
}
