namespace products_categories.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}