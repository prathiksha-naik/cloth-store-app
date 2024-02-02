using System;
using System.Collections.Generic;

namespace ClothingStore.Domain.Entities;

public partial class SizeVariant
{
    public int SizeId { get; set; }

    public string Size { get; set; } = null!;

    public int Quantity { get; set; }

    public int? ClothItemId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ClothItem? ClothItem { get; set; }
}
