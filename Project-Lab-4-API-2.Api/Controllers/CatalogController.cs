using Microsoft.AspNetCore.Mvc;
using Project.Lab4.API2.Domain.Catalog;
using Project.Lab4.API2.Data;

namespace Project.Lab4.API2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly StoreContext _db;

        public CatalogController(StoreContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _db.Items.ToList();
            return Ok(_db.Items);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        {
            var item = _db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost]
        public IActionResult Post(Item item)
        {
            return Created("/catalog/42", item);
        }

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m)
            {
                Id = id
            };

            item.AddRating(rating);

            return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }
    }

    public class Rating
    {
    }

    public class Item
    {
        private string v1;
        private string v2;
        private string v3;
        private decimal v4;

        public Item(string v1, string v2, string v3, decimal v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
        }

        public int Id { get; set; }

        internal void AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
