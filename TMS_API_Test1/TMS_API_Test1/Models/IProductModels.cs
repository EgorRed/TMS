namespace TMS_API_Test1.Models
{
    public interface IProductModels
    {
        uint Id { get; set; }
        string Name { get; set; }
        string ProductType { get; set; }
        uint Quantity { get; set; }
        decimal Price { get; set; }
        decimal PriceTotal { get; set; }
        public void SetPriceTotal();
    }
}
