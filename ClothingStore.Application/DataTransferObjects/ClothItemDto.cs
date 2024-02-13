namespace ClothStoreApplication.DataTransferObjects
{
    public class ClothItemDto
    {
        public int ClothItemId { get; set; }

        public byte[]? ClothItemImage { get; set; }
        public string ItemName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = decimal.Zero;
        public int CategoryId { get; set; }
        public int ClothCategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
