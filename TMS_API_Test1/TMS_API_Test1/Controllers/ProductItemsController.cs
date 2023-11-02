using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS_API_Test1.Models;

namespace TMS_API_Test1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductItemsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/ProductItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItems()
        {
          if (_context.ProductItems == null)
          {
              return NotFound();
          }
            return await _context.ProductItems.ToListAsync();
        }

        // GET: api/ProductItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProductItem(uint id)
        {
          if (_context.ProductItems == null)
          {
              return NotFound();
          }
            var productItem = await _context.ProductItems.FindAsync(id);

            if (productItem == null)
            {
                return NotFound();
            }

            return productItem;
        }

        // POST: api/ProductItems
        [HttpPost]
        public async Task<ActionResult<ProductItem>> PostProductItem(ProductItem productItem)
        {
          if (_context.ProductItems == null)
          {
              return Problem("Entity set 'ProductContext.ProductItems'  is null.");
          }
            _context.ProductItems.Add(productItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductItem", new { id = productItem.Id }, productItem);
        }

        // DELETE: api/ProductItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductItem(uint id)
        {
            if (_context.ProductItems == null)
            {
                return NotFound();
            }
            var productItem = await _context.ProductItems.FindAsync(id);
            if (productItem == null)
            {
                return NotFound();
            }

            _context.ProductItems.Remove(productItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
