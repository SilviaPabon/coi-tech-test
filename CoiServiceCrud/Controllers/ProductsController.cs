using CoiServiceCrud.Models;
using CoiServiceCrud.Models.Res;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoiServiceCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CoiDbContext _context;

        public ProductsController(CoiDbContext context)
        {
            _context = context;
        }

        // GET: api/products/
        [HttpGet]
        public async Task<IActionResult> GetProducts(int id)
        {
            Response res = new Response();
            var products = await _context.Products.ToListAsync();
            if (products == null)
                return NotFound();
            
            res.Success = 1;
            res.Data = products;
            
            return Ok(res);
        }

        // GET: api/products/n
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var producto = await _context.Products.FindAsync(id);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] Product product)
        {
            Product productUpdate = await _context.Products.FindAsync(id);
            if (productUpdate == null)
                return NotFound();
            productUpdate.Name = product.Name;
            productUpdate.Description = product.Description;
            productUpdate.Price = product.Price;
            productUpdate.Status = product.Status;
            _context.Entry(productUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/products/order/price
        [HttpGet("order/price")]
        public async Task<IActionResult> GetProductsOrderByPrice()
        {
            Response res = new Response();
            var products = await _context.Products
                .OrderBy(p => p.Price)
                .ToListAsync();
            if (products == null)
                return NotFound();

            res.Success = 1;
            res.Data = products;

            return Ok(res);
        }
    }
}
