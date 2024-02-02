using System;
using System.Collections.Generic;

namespace ClothingStore.Domain.Entities;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int? OrderId { get; set; }

    public int? ClothItemId { get; set; }

    public virtual ClothItem? ClothItem { get; set; }

    public virtual Order? Order { get; set; }
}
