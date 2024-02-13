namespace ClothStoreApplication.DataTransferObjects
{
    public class UserRegisterDto
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Phone { get; set; } = 0!;
        public string Address { get; set; } = null!;

    }
}
