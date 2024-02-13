using System;
using System.Collections.Generic;

namespace ClothingStoreApplication.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public byte[]? BrandImage { get; set; }

    public virtual ICollection<ClothItem> ClothItems { get; set; } = new List<ClothItem>();
}
