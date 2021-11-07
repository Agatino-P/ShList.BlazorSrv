using Newtonsoft.Json.Linq;
using ShList.BlazorSrv.Models;
using ShList.BlazorSrv.Services.Interfaces;
using ShList.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShList.BlazorSrv.Services.Models
{
    public class ShoppingListService : IRestService<ShoppingList, Guid>
    {
        private HttpClient _httpClient { get; set; }

        public ShoppingListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ShoppingList>> Get()
        {
            ShoppingListDto[] dtos = await _httpClient.GetFromJsonAsync<ShoppingListDto[]>("/api/shoppinglists");
            //TODO Check the result and act accordingly
            return dtos.Select(dto => new ShoppingList(dto));
        }

        public async Task<ShoppingList> Get(Guid id)
        {
            ShoppingListDto dto = await _httpClient.GetFromJsonAsync<ShoppingListDto>($"/api/shoppinglists/{id}");
            //TODO Check the result and act accordingly
            return new ShoppingList(dto);
        }

        public async Task<ShoppingList> AddOrUpdate(ShoppingList shoppingList)
        {
            ShoppingListDto dto = shoppingList.ToDto();
            //TODO Check the result and act accordingly.
            await _httpClient.PostAsJsonAsync<ShoppingListDto>($"/api/ShoppingLists", dto);
            return shoppingList; //Quick and dirty because I know ShoppingList is not changed, but the right way is to deserialize the outcome of a successful post
        }

        public async Task<bool> Delete(ShoppingList shoppingList)
        {
            ShoppingListDto dto = shoppingList.ToDto();
            //TODO Check the result and act accordingly.
            HttpResponseMessage outcome = await _httpClient.DeleteAsync($"/api/ShoppingLists/{shoppingList.Id}");
            return outcome.IsSuccessStatusCode == true; //Quick and dirty because I know ShoppingList is not changed, but the right way is to deserialize the outcome of a successful post
        }



    }
}
