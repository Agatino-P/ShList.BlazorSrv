using ShList.BlazorSrv.Models;
using ShList.Dto;
using System;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services.Interfaces
{
    public interface IShoppingListService : IRestService<ShoppingList,Guid>
    {
        Task SetItemStatus(ShoppingList shoppingList, ShItem item, ShItemStatus status);
    }
}
