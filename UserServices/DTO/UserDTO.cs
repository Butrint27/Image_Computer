namespace UserServices.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        // Accepts image upload
        public IFormFile? ImageFile { get; set; }
    }
}
