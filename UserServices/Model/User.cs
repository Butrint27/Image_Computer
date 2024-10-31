namespace UserServices.Model
{
    public class User
    {
        public int UserId { get; set; }

        // Image stored as a byte array (BLOB)
        public byte[]? Image { get; set; }
    }
}
