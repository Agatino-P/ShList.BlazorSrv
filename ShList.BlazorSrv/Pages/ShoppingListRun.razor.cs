using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using ShList.Dto;

namespace ShList.BlazorSrv.Pages
{
    public partial class ShoppingListRun
    {
        [Parameter]
        public string strId { get; set; }

        private ShoppingList _shoppingList { get; set; }
        private bool _showActive = true;
        private bool _showOnHold = false;
        private bool _showDone = false;
        private IEnumerable<ShItem> _activeItems => _shoppingList.Items.Where(ShItem => ShItem.Status == Dto.ShItemStatus.Active);
        private IEnumerable<ShItem> _onHoldItems => _shoppingList.Items.Where(ShItem => ShItem.Status == Dto.ShItemStatus.OnHold);
        private IEnumerable<ShItem> _doneItems => _shoppingList.Items.Where(ShItem => ShItem.Status == Dto.ShItemStatus.Done);

        [Inject]
        private IShoppingListService _shoppingListService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrWhiteSpace(strId) && Guid.TryParse(strId, out Guid parsedId))
            {
                _shoppingList = await _shoppingListService.Get(parsedId);
            }


            await base.OnInitializedAsync();
        }

        private async Task setItemStatus(ShItem Item, ShItemStatus status)
        {
            Item.Status = status;
            await _shoppingListService.SetItemStatus(_shoppingList, Item, status);
        }


    }
}
