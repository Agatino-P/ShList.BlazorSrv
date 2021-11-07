using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Pages
{
    public partial class ShoppingListEdit : ComponentBase
    {
        [Parameter]
        public string strId { get; set; }
        public Guid Id { get; set; }

        [Inject]
        private IRestService<ShoppingList, Guid> _slService { get; set; }

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
                _shoppingList = await _slService.Get(Id);
                Saved = false;
            }
            else
            {
                Mode = ModeEnum.Add;
                _shoppingList = new ShoppingList();
                Saved = true;
            }
            await base.OnInitializedAsync();
        }

        protected void OnCancelCmd()
        {
            _navigationManager.NavigateTo("/products");
        }

        protected async Task HandleValidSubmit()
        {
            _shoppingList = await _slService.AddOrUpdate(_shoppingList);
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
