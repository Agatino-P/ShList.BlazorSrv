using Microsoft.AspNetCore.Components;
using ShList.BlazorSrv.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Components
{
    public partial class ShItemActionableList : ComponentBase
    {
        [Parameter]
        public List<ShItem> ShItems { get; set; } = new();

        [Parameter]
        public string ButtonClass { get; set; }

        [Parameter]
        public EventCallback<ShItem> ActionCallback { get; set; }


        //Will bind to this
        //Note: the binded value should never be null, so alway initialize it with default values

        public async Task ActionButtonCmd(ShItem item)
        {
            await ActionCallback.InvokeAsync(item);
            //StateHasChanged(); Arrives from container?
        }

    }
}
