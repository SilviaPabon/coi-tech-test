using Microsoft.AspNetCore.Components.Forms;

namespace Client.Models
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public IBrowserFile? Imagen { get; set; }
    }
}
