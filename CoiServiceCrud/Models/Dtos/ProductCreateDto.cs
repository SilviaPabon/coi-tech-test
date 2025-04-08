using System.ComponentModel.DataAnnotations.Schema;

namespace CoiServiceCrud.Models.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool Status { get; set; }
        [NotMapped]
        public IFormFile? Imagen { get; set; }
    }
}
