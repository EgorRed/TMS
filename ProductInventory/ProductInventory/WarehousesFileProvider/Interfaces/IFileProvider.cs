using ProductInventory.Warehouses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.WarehousesFileProvider.Interfaces
{
    internal interface IFileProvider
    {
        string DefoultPath { get; }
        void Createfile(string name);
        void DeleteFile(string name);
        //void Write(string path, string data);
        //void Read(string path);

        void LoadData(WarhousesManager manager);
        void Synchronization(IWarehouse<uint> warehouse);
    }
}
