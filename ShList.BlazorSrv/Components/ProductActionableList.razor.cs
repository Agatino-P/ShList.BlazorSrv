using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Components
{
    public partial class ProductActionableList : ComponentBase
    {
        [Parameter]
        public List<Product> SelectableProducts { get; set; }

        //public List<Product> Products = new List<Product>();

        [Parameter]
        public EventCallback<Product> ActionCallback { get; set; }


        //Will bind to this
        //Note: the binded value should never be null, so alway initialize it with default values

        public async Task ActionButtonCmd(Product product)
        {
            await ActionCallback.InvokeAsync(product);
            StateHasChanged();
        }

    }
}
