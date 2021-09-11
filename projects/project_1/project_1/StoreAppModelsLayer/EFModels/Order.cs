using System;
using System.Collections.Generic;

#nullable disable

namespace StoreAppDBContextLayer.EFModels
{
    public partial class Order
    {
        public Guid ItemizedId { get; set; }
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductQuantity { get; set; }
        public int CompletionTime { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Location Store { get; set; }
    }
}
