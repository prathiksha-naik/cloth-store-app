using System;
using System.Collections.Generic;

namespace ClothingStore.Domain.Entities;

public partial class ClothItem
{
    public int ClothItemId { get; set; }

    public byte[]? ClothItemImage { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public int? CategoryId { get; set; }

    public int? ClothCategoryId { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ClothCategory? ClothCategory { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<SizeVariant> SizeVariants { get; set; } = new List<SizeVariant>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
