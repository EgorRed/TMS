using TMS_API_Test1.Models;
using TMS_API_Test1.Models.Product;

namespace TMS_API_Test1.Service
{
    public interface IWarhousesManagerService
    {
        Dictionary<WarhouseIndexModel, IWarehouse> Warehouses { get; }

        void CreateNewWarehouse(WarhouseIndexModel warehouseIndex);

        void DeleteWarehouse(WarhouseIndexModel warehouseIndex);

        List<IProductModels> GetListAllProducts(WarhouseIndexModel warehouseIndex);

        void AddProduct(WarhouseIndexModel warehouseIndex, IProductModels product);

        void RemoveProduct(WarhouseIndexModel warehouseIndex, uint productIndex, uint quantity);

        Dictionary<string, List<IProductModels>> GetProductCategories(WarhouseIndexModel warehouseIndex);

        void MovingTheProduct(WarhouseIndexModel warehouseFromWhere, WarhouseIndexModel warehouseWhere, uint productIndex, uint quantity);
        
        IWarehouse FindWarehouse(WarhouseIndexModel warehouseIndex);
    }
}
