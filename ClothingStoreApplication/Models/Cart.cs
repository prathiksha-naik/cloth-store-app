using System;
using System.Collections.Generic;

namespace ClothingStoreApplication.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int Quantity { get; set; }

    public int? UserId { get; set; }

    public int? ClothItemId { get; set; }

    public int? SizeId { get; set; }

    public int? WishlistId { get; set; }

    public virtual ClothItem? ClothItem { get; set; }

    public virtual SizeVariant? Size { get; set; }

    public virtual User? User { get; set; }

    public virtual Wishlist? Wishlist { get; set; }
}
