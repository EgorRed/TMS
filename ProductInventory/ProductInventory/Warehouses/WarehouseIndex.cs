using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Warehouses
{
    internal class WarehouseIndex<TWarehouseIndex> where TWarehouseIndex : IComparable<TWarehouseIndex>
    {
        public TWarehouseIndex Index { get; set; }
        public WarehouseIndex(TWarehouseIndex index) 
        {
            Index = index;
        }

        public static bool operator >(WarehouseIndex<TWarehouseIndex> a, WarehouseIndex<TWarehouseIndex> b)
        {
            return a.Index.CompareTo(b.Index) > 0;
        }

        public static bool operator <(WarehouseIndex<TWarehouseIndex> a, WarehouseIndex<TWarehouseIndex> b)
        {
            return a.Index.CompareTo(b.Index) < 0;
        }

        public static bool operator ==(WarehouseIndex<TWarehouseIndex> a, WarehouseIndex<TWarehouseIndex> b)
        {
            return a.Index.Equals(b);
        }

        public static bool operator !=(WarehouseIndex<TWarehouseIndex> a, WarehouseIndex<TWarehouseIndex> b)
        {
            return !a.Index.Equals(b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            else if(ReferenceEquals(obj, null))
            {
                return false;
            }
            else
            {
                return base.Equals(obj);
            }

        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
