using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContextLayer.EFModels
{
    public partial class StoreInventory
    {
        public Guid ItemizedId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Inventory { get; set; }

        public virtual Product Product { get; set; }
        public virtual Location Store { get; set; }
    }
}
