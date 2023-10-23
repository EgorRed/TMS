using ProductInventory.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.View.Command
{
    internal class ChangeStock : IExecutor
    {
        public string Description { get; }

        public ChangeStock()
        {
            Description = "Выбрать склад.";
        }

        

        public void Execute()
        {

        }
    }
}
