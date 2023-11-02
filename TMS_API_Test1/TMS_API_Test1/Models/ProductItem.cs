namespace TMS_API_Test1.Models
{
    public class ProductItem
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? ProductType { get; set; }
        public uint Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
