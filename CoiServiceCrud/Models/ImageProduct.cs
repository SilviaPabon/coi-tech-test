namespace CoiServiceCrud.Models
{
    public class ImageProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        public DateTime DateUpdate { get; set; } = DateTime.UtcNow;

        public Product Product { get; set; } = null!;
    }
}
