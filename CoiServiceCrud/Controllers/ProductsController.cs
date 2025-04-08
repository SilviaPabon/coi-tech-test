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
            res.Success = 1;
            res.Data = await _context.Products.ToListAsync();
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
    }
}
