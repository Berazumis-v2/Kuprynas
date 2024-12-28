using Kuprynas.Models;
using Kuprynas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kuprynas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryItemsController : ControllerBase
    {
        private readonly IGroceryItemService _groceryItemService;

        public GroceryItemsController(IGroceryItemService groceryItemService)
        {
            _groceryItemService = groceryItemService;
        }

        // GET: api/GroceryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryItem>>> GetAllAsync()
        {
            var items = await _groceryItemService.GetAllItemsAsync();
            return Ok(items);
        }

        // GET: api/GroceryItems/1
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItem>> GetByIdAsync(int id)
        {
            var item = await _groceryItemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/GroceryItems
        [HttpPost]
        public async Task<ActionResult<GroceryItem>> CreateAsync([FromBody] GroceryItem groceryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _groceryItemService.AddItemAsync(groceryItem);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = groceryItem.Id }, groceryItem);
        }

        // PUT: api/GroceryItems/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] GroceryItem groceryItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groceryItem.Id)
            {
                return BadRequest("The provided ID does not match the item's ID.");
            }

            await _groceryItemService.UpdateItemAsync(groceryItem);
            return NoContent();
        }

        // DELETE: api/GroceryItems/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingItem = await _groceryItemService.GetItemByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _groceryItemService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
