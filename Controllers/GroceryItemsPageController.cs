using Kuprynas.Models;
using Kuprynas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kuprynas.Controllers
{
    public class GroceryItemsMvcController : Controller
    {
        private readonly IGroceryItemService _groceryItemService;

        public GroceryItemsMvcController(IGroceryItemService groceryItemService)
        {
            _groceryItemService = groceryItemService;
        }

        // GET: /GroceryItemsMvc/
        public async Task<IActionResult> Index()
        {
            var items = await _groceryItemService.GetAllItemsAsync();
            return View(items);
        }

        // GET: /GroceryItemsMvc/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _groceryItemService.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: /GroceryItemsMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /GroceryItemsMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroceryItem groceryItem)
        {
            if (!ModelState.IsValid)
                return View(groceryItem);

            await _groceryItemService.AddItemAsync(groceryItem);
            return RedirectToAction(nameof(Index));
        }

        // GET: /GroceryItemsMvc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _groceryItemService.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /GroceryItemsMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GroceryItem groceryItem)
        {
            if (!ModelState.IsValid)
                return View(groceryItem);

            if (id != groceryItem.Id)
                return BadRequest("ID mismatch.");

            await _groceryItemService.UpdateItemAsync(groceryItem);
            return RedirectToAction(nameof(Index));
        }

        // GET: /GroceryItemsMvc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _groceryItemService.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /GroceryItemsMvc/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _groceryItemService.DeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
