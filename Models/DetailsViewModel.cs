using System.Collections.Generic;

namespace onlineshop.Models
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}