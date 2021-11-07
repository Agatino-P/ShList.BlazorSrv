using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ShoppingLists : ComponentBase
    {
        private IEnumerable<ShoppingList> _shoppingList = new List<ShoppingList>();

        [Inject]
        private IRestService<ShoppingList, Guid> _slService { get; set; }

        protected ConfirmShoppingListDelete ConfirmShoppingListDeleteDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await getAllLists();
            await base.OnInitializedAsync();
        }

        protected async Task RefreshCmd()
        {
            await getAllLists();
            StateHasChanged();
        }

        private async Task getAllLists()
        {
            _shoppingList = await _slService.Get();
        }

        protected void ShowDeleteShoppingListCmd(ShoppingList shoppingList)
        {
            ConfirmShoppingListDeleteDialog.ShoppingList = shoppingList;
            ConfirmShoppingListDeleteDialog.Show(shoppingList);
        }

        public async void ShoppingListDeleteCallBack(ShoppingList shoppingList)
        {
            if (shoppingList != null)
            {
                bool deleted = await _slService.Delete(shoppingList);
                await RefreshCmd();
            }
        }

    }
}
