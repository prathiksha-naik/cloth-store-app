namespace ClothStoreApplication.DataTransferObjects
{
    public class ClothItemDto
    {
        public int ClothItemId { get; set; }

        public byte[]? ClothItemImage { get; set; }

        public string ItemName { get; set; } = null!;

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public int? ClothCategoryId { get; set; }

        public int? BrandId { get; set; }

        public string? Description { get; set; }
    }
}
