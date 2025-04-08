using CoiServiceCrud.Models;
using CoiServiceCrud.Models.Dtos;
using CoiServiceCrud.Models.Res;
using Humanizer;
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
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Status = dto.Status
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(); // necesitamos el ID

            // Si hay imagen, guardarla
            if (dto.Imagen != null && dto.Imagen.Length > 0)
            {
                var nombreArchivo = $"{Guid.NewGuid()}_{Path.GetFileName(dto.Imagen.FileName)}";
                var ruta = Path.Combine("wwwroot", "imagenes", nombreArchivo);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(stream);
                }

                var url = $"{Request.Scheme}://{Request.Host}/imagenes/{nombreArchivo}";
                var image = new ImageProduct
                {
                    ProductId = product.Id,
                    Url = url,
                    DateCreation = DateTime.Now,
                    DateUpdate = DateTime.Now
                };

                _context.ImageProducts.Add(image);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();
            //return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, [FromForm] ProductCreateDto dto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Status = dto.Status;
            product.DateUpdate = DateTime.UtcNow;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            if (dto.Imagen != null && dto.Imagen.Length > 0)
            {
                var nombreArchivo = $"{Guid.NewGuid()}_{Path.GetFileName(dto.Imagen.FileName)}";
                var ruta = Path.Combine("wwwroot", "imagenes", nombreArchivo);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(stream);
                }

                var url = $"{Request.Scheme}://{Request.Host}/imagenes/{nombreArchivo}";

                // Elimina en local -- cambiar esto con lògica en la nube o almacenamiento externo
                var nombreArchivoViejo = Path.GetFileName(url);
                var rutaVieja = Path.Combine("wwwroot", "imagenes", nombreArchivoViejo);

                if (System.IO.File.Exists(rutaVieja))
                {
                    System.IO.File.Delete(rutaVieja);
                }

                // Elimina imagen anterior
                var imagenAnterior = await _context.ImageProducts
                    .FirstOrDefaultAsync(i => i.ProductId == id);

                if (imagenAnterior != null)
                {
                    _context.ImageProducts.Remove(imagenAnterior);
                }

                var nuevaImagen = new ImageProduct
                {
                    ProductId = id,
                    Url = url,
                    DateUpdate = DateTime.Now
                };

                _context.ImageProducts.Add(nuevaImagen);
                await _context.SaveChangesAsync();
            }

            return NoContent();
            //Product productUpdate = await _context.Products.FindAsync(id);
            //if (productUpdate == null)
            //    return NotFound();
            //productUpdate.Name = product.Name;
            //productUpdate.Description = product.Description;
            //productUpdate.Price = product.Price;
            //productUpdate.Status = product.Status;
            //_context.Entry(productUpdate).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            //return NoContent();
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
