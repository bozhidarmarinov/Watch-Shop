using System.Collections.Generic;

namespace onlineshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public ICollection<CategoryToProduct> CategoriesToProducts { get; set; }
        public Item Item { get; set; }
    }
}