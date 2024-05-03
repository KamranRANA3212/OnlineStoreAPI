using OnlineStoreAPI.Models;
using OnlineStoreAPI.Responses;

namespace OnlineStoreAPI.Interfaces
{
    public interface IItem
    {
        Task<CreateUpdateItemResponseDto> CreateItemAsync(CreateUpdateItemRequestDto item);
        Task<CreateUpdateItemResponseDto> UpdateItemAsync(CreateUpdateItemRequestDto item, int id);
        Task DeleteItemAsync(int id);
        Task<Item> GetItemByIdAsync(int id);
        Task <List<Item>> GetAllItemsAsync();


    }
}
