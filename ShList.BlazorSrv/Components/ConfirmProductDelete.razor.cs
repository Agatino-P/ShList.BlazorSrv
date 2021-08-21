using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Components
{
    public partial class ConfirmProductDelete
    {
        [Parameter]
        public EventCallback<Product> ConfirmProductDeleteCallBack { get; set; }

        //Will bind to this
        //Note: the binded value should never be null, so alway initialize it with default values
        public Product Product { get; set; } = new Product();
        private bool _confirmed { get; set; } = false;

        public bool ShowDialog{ get; set; } = false;
        public void Show(Product product)
        {
            Product = product;
            ShowDialog = true;
            StateHasChanged();
        }
        public async Task Close()
        {
            ShowDialog = false;
            await ConfirmProductDeleteCallBack.InvokeAsync(_confirmed?Product:null);
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
