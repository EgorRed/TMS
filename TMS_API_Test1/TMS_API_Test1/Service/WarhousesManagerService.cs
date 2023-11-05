using Microsoft.Extensions.FileProviders;
using TMS_API_Test1.Models;

namespace TMS_API_Test1.Service
{
    public class WarhousesManagerService : IWarhousesManagerService
    {
        //public List<IWarehouse> Warehouses { get; }
        //private FileProvider _fileProvider { get; set; }
        public Dictionary<WarhouseIndexModel, IWarehouse> Warehouses { get; }

        public WarhousesManagerService()
        {
            Warehouses = new Dictionary<WarhouseIndexModel, IWarehouse>();
        }

        //public WarhousesManager(string DefoultPath) : this()
        //{
        //    _fileProvider = new FileProvider(DefoultPath);
        //    _fileProvider.LoadData(this);
        //}

        //public void LoadWarhouses(Warhouse warhouse)
        //{
        //    if (FindWarehouse(warhouse.WarehouseIndex) == null)
        //    {
        //        Warehouses.Add(warhouse.WarehouseIndex, warhouse);
        //    }
        //    else
        //    {
        //        throw new Exception("such a warehouse already exists");
        //    }
        //}

        public void CreateNewWarehouse(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) == null)
            {
                Warehouses.Add(warehouseIndex, new Warhouse(warehouseIndex));
                //_fileProvider.Createfile($"{warehouseIndex}");
            }
            else
            {
                throw new Exception("such a warehouse already exists");
            }
        }


        public void DeleteWarehouse(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                Warehouses.Remove(warehouseIndex);
                //_fileProvider.DeleteFile($"{_fileProvider.DefoultPath}\\{warehouseIndex}");
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public List<IProductModels> GetListAllProducts(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                return FindWarehouse(warehouseIndex).AllProducts;
            }
            else
            {
                throw new Exception("Attempt to access a non-existent warehouse");
            }
        }


        public void AddProduct(WarhouseIndexModel warehouseIndex, IProductModels product)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                var warehouse = FindWarehouse(warehouseIndex);
                warehouse.AddProductToTheWarehouse(product);
                //_fileProvider.Synchronization(warehouse);
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public void RemoveProduct(WarhouseIndexModel warehouseIndex, uint productIndex, uint quantity)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                FindWarehouse(warehouseIndex).RemoveTheGoodsFromTheWarehouse(productIndex, quantity);
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }


        public Dictionary<string, List<IProductModels>> GetProductCategories(WarhouseIndexModel warehouseIndex)
        {
            if (FindWarehouse(warehouseIndex) != null)
            {
                return FindWarehouse(warehouseIndex).SplitProductsIntoCategories();
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }

        public void MovingTheProduct(WarhouseIndexModel warehouseFromWhere, WarhouseIndexModel warehouseWhere, uint productIndex, uint quantity)
        {
            var _warehouseFromWhere = FindWarehouse(warehouseFromWhere);
            var _warehouseWhere = FindWarehouse(warehouseWhere);

            if (_warehouseFromWhere != null && _warehouseWhere != null)
            {
                _warehouseFromWhere.RemoveTheGoodsFromTheWarehouse(productIndex, quantity);
                _warehouseWhere.AddProductToTheWarehouse(_warehouseFromWhere.FindProduct(productIndex));
            }
            else
            {
                throw new Exception("There is no such warehouse");
            }
        }

        public IWarehouse FindWarehouse(WarhouseIndexModel warehouseIndex)
        {
            IWarehouse returnValue;
            if(Warehouses.TryGetValue(warehouseIndex, out returnValue))
            {
                return returnValue;
            }
            return null;
        }

    }
}
