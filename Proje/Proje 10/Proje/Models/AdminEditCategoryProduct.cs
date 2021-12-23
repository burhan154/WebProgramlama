namespace Proje.Models
{
    public class AdminEditCategoryProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public bool IsAprroved { get; set; }
        public bool IsHome { get; set; }
        public bool IsFeatured { get; set; }
    }
}