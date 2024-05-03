using Microsoft.EntityFrameworkCore;
using OnlineStoreAPI.Data;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;
using OnlineStoreAPI.Responses;

namespace OnlineStoreAPI.Services
{
    public class ItemService : IItem
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CreateUpdateItemResponseDto> CreateItemAsync(CreateUpdateItemRequestDto item)
        {
            var newItem = new Item
            {
                ItemDescription = item.ItemDescription,
                ItemCost = item.ItemCost,
                Quantity = item.Quantity
            };

            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return new CreateUpdateItemResponseDto
            {
                Message = "Item Created Successfully",
                Status = "Created"
                
            };
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<CreateUpdateItemResponseDto> UpdateItemAsync(CreateUpdateItemRequestDto item,int id)
        {
            var itm = await _context.Items.FindAsync(id);
            if (itm == null)
            {
                throw new Exception("Item not found");
            }
            itm.ItemDescription = item.ItemDescription;
            itm.ItemCost = item.ItemCost;
            itm.Quantity = item.Quantity;
            await _context.SaveChangesAsync();
            return new CreateUpdateItemResponseDto
            {
                Id = id,
                Message="Updated Successfully",
                Status="Updated"
            };
        }
    }
}
