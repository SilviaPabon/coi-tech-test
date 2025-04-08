using CoiServiceCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoiServiceCrud.Controllers
{
    public class ImageProductController : Controller
    {
        private readonly CoiDbContext _context;

        public ImageProductController(CoiDbContext context) {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> SubirImagen(IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
                return BadRequest("Not imaged sended.");

            var nombreArchivo = Path.GetFileName(imagen.FileName);
            var ruta = Path.Combine("wwwroot", "imagenes", nombreArchivo);

            using (var stream = new FileStream(ruta, FileMode.Create))
            {
                await imagen.CopyToAsync(stream);
            }

            var url = $"{Request.Scheme}://{Request.Host}/imagenes/{nombreArchivo}";
            return Ok(new { Url = url });
        }
    }
}
