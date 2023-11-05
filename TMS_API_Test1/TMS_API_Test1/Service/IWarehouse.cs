using TMS_API_Test1.Models;

namespace TMS_API_Test1.Service
{
    public interface IWarehouse
    {
        public WarhouseIndexModel WarehouseIndex { get; }
        public List<IProductModels> AllProducts { get; }

        //добавить определённое количество продукта
        public void AddProductToTheWarehouse(IProductModels product);

        //удалить определённое количество продукта
        public void RemoveTheGoodsFromTheWarehouse(uint productIndex, uint quantity);

        //изменить количество продукта
        public void ChangeTheQuantityOfGoodsInStock(uint productIndex, uint quantity);

        //разбить продукты на котегории
        public Dictionary<string, List<IProductModels>> SplitProductsIntoCategories();

        public IProductModels FindProduct(uint productIndex);
    }
}
