using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;
using OnlineStoreAPI.Responses;

namespace OnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItem _itemRepository;
        public ItemController(IItem itemRepository)
        {
            _itemRepository = itemRepository;
        }
        [HttpPost("AddItem")]
        public async Task<ActionResult<CreateUpdateItemResponseDto>> AddItem([FromBody] CreateUpdateItemRequestDto model)
        {
            await _itemRepository.CreateItemAsync(model);
            return Ok(model);
        }
        [HttpGet("GetAllItems")]
        public async Task<IActionResult> GetAllItems()
        {
            var itemList = await _itemRepository.GetAllItemsAsync();
            return Ok(itemList);
        }
        [HttpPut("UpdateItem")]
        public async Task<ActionResult<CreateUpdateItemResponseDto>> UpdateItem( int id, CreateUpdateItemRequestDto model)
        {
            await _itemRepository.UpdateItemAsync(model, id);
            return Ok(model);
        }
        [HttpDelete("DeleteItem")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            await _itemRepository.DeleteItemAsync(id);
            return Ok();
        }
        [HttpGet("GetItemById")]
        public async Task<ActionResult> GetItemById(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            return Ok(item);
        }
    }
}
