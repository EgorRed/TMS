namespace TMS_API_Test1.Models.Product
{
    public class SpecificProductModel
    {
        public WarhouseIndexModel warhouseIndex { get; set; } = new WarhouseIndexModel();
        public uint ProductId { get; set; }
        public uint Quantity { get; set; }
    }
}
