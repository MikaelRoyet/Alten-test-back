using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Alten_test.Data.Models
{
    public class ProductDTO
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string? InventoryStatus { get; set; }
        public string? Category { get; set; }
        public string? image { get; set; }
        public int rating { get; set; }

    }
}
