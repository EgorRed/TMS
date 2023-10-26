using ProductInventory.MyProduct;
using ProductInventory.Warehouses;
using ProductInventory.Warehouses.Interfaces;
using ProductInventory.WarehousesFileProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductInventory.WarehousesFileProvider
{
    internal class FileProvider : IFileProvider
    {
        public string DefoultPath { get; }


        public FileProvider(string defoultPath)
        {
            DefoultPath = defoultPath;
        }   


        public void Createfile(string name)
        {
            if (!File.Exists($"{DefoultPath}\\{name}.txt")) 
            {
                FileStream fs = File.Create($"{DefoultPath}\\{name}.txt");
                fs.Close();
            }
            else 
            {
                throw new Exception("there is already such a file");
            }
        }


        public void DeleteFile(string name)
        {
            if (File.Exists($"{DefoultPath}\\{name}.txt"))
            {
                File.Delete($"{DefoultPath}\\{name}.txt");
            }
            else
            {
                throw new Exception($"there is no such file");
            }
        }


        //public void Write(string name, string data)
        //{
        //    throw new NotImplementedException();
        //}


        //public void Read(string path)
        //{
        //    throw new NotImplementedException();
        //}


        public void Synchronization(IWarehouse<uint> warehouse)
        {
            if (File.Exists($"{DefoultPath}\\{warehouse.WarehouseIndex}.txt"))
            {
                using (StreamWriter writeStream = new StreamWriter($"{DefoultPath}\\{warehouse.WarehouseIndex}.txt", false, Encoding.UTF8))
                {
                    foreach (var product in warehouse.AllProducts)
                    {
                        writeStream.WriteLine(product.GetString());
                    }
                }
            }
            else
            {
                throw new Exception($"there is no such file {DefoultPath}\\{warehouse.WarehouseIndex}.txt");
            }
        }


        public void LoadData(WarhousesManager manager)
        {
            if (Directory.Exists($"{DefoultPath}\\"))
            {
                
                var files = Directory.GetFiles(DefoultPath).ToList();
                foreach (var file in files) 
                {
                    var fileName = Path.GetFileName(file);
                    var warehouseIndex = uint.Parse(fileName.Remove(fileName.Length - 4));
                    Warhouse<uint> warehouse = new Warhouse<uint>(warehouseIndex);

                    foreach (var lineProduct in File.ReadAllLines($"{DefoultPath}\\{warehouseIndex}.txt"))
                    {
                        Product product = new Product();
                        product.ParseString(lineProduct);
                        warehouse.AddProductToTheWarehouse(product);
                    }

                    manager.LoadWarhouses(warehouse);
                }
            }
        }
    }
}
