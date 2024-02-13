namespace ClothStoreApplication.DataTransferObjects
{
    public class SizeVariantDto
    {
        public int SizeId { get; set; }

        public string Size { get; set; } = null!;

        public int Quantity { get; set; }

        public int ClothItemId { get; set; }
    }
}
