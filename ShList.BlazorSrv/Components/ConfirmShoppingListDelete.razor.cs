using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Components
{
    public partial class ConfirmShoppingListDelete : ComponentBase
    {
        [Parameter]
        public EventCallback<ShoppingList> ConfirmShoppingListDeleteCallBack { get; set; }

        //Will bind to this
        //Note: the binded value should never be null, so alway initialize it with default values
        public ShoppingList ShoppingList { get; set; }
        private bool _confirmed { get; set; } = false;

        public bool ShowDialog{ get; set; } = false;
        public void Show(ShoppingList  shoppingList)
        {
            ShoppingList = shoppingList;
            ShowDialog = true;
            StateHasChanged();
        }
        public async Task Close()
        {
            ShowDialog = false;
            await ConfirmShoppingListDeleteCallBack.InvokeAsync(_confirmed?ShoppingList:null);
            StateHasChanged();
        }

        public async Task OnYes()
        {
            _confirmed = true;
            await Close();
        }

        public async Task OnNo()
        {
            _confirmed = false;
            await Close();
        }

    }
}
