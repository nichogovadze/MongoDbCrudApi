using Microsoft.AspNetCore.Mvc;
using MongoDbCrudApi.Models;
using MongoDbCrudApi.Services;

namespace MongoDbCrudApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<Item>> Get() => _itemService.Get();

        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<Item> Get(string id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<Item> Create(Item item)
        {
            _itemService.Create(item);

            return CreatedAtRoute("GetItem", new { id = item.Id.ToString() }, item);
        }

        [HttpPut]
        public IActionResult Update(string id, Item itemIn)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Update(id, itemIn);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var item = _itemService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            _itemService.Remove(item.Id);

            return NoContent();
        }
    }
}