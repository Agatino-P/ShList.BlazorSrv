using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IShoppingListService _shoppingListService { get; set; }
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
        private IEnumerable<Product> _allProducts;
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

            _allProducts = await _productService.Get();
            updateSelectableProducts();    

            await base.OnInitializedAsync();
        }

        private void updateSelectableProducts()
        {
            _selectableProducts = new List<Product>(_allProducts)
                            .Where(pr => !_shoppingList.Items.Any(item => item.Product == pr.Name)).ToList();
        }


        public void RemoveItem(ShItem item)
        {
            _shoppingList.RemoveItem(item);
            updateSelectableProducts();
        }


        public void AddItemCallback(Product product)
        {
            _shoppingList.AddItem(product);
            updateSelectableProducts();
            StateHasChanged();
            //Most likely need to arrange something better for reloads, that filters
        }

        public async Task ItemChangedCallback(ShItem shItem) => await HandleValidSubmit();
        
        protected void OnCancelCmd()
        {
            _navigationManager.NavigateTo("/shoppinglists");
        }

        protected async Task HandleValidSubmit()
        {
            _shoppingList = await _shoppingListService.AddOrUpdate(_shoppingList);
            Saved = true;
            Message = "List Saved";
        }

        protected Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "Invalid Data";
            return Task.CompletedTask;
        }



    }
}
