using TMS_API_Test1.Models;

namespace TMS_API_Test1.Models.Product
{
    public class ProductDto
    {
        public WarhouseIndexModel WarhouseIndex { get; set; } = new WarhouseIndexModel();
        public string? Name { get; set; }
        public string? ProductType { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
