using System;
using System.Collections.Generic;

namespace ClothingStoreApplication.Models;

public partial class Wishlist
{
    public int WishlistId { get; set; }

    public int? UserId { get; set; }

    public int? ClothItemId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ClothItem? ClothItem { get; set; }

    public virtual User? User { get; set; }
}
