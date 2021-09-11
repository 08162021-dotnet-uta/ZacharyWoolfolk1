using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContextLayer.EFModels
{
    public partial class Location
    {
        public Location()
        {
            Orders = new HashSet<Order>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int StoreId { get; set; }
        public string Location1 { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
