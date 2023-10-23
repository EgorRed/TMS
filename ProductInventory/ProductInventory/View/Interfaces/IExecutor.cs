using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Interfaces
{
    internal interface IExecutor
    {
        public string Description { get; }
        public void Execute();
    }
}
