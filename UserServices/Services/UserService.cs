using AutoMapper;
using UserServices.Data;
using UserServices.DTO;
using UserServices.Model;

namespace UserServices.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateUserAsync(UserDTO userDto)
        {
            var user = new User();

            if (userDto.ImageFile != null)
            {
                // Validate the image type
                var allowedTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
                if (!allowedTypes.Contains(userDto.ImageFile.ContentType))
                {
                    throw new InvalidOperationException("Invalid file type. Only JPG and PNG images are allowed.");
                }

                using var ms = new MemoryStream();
                await userDto.ImageFile.CopyToAsync(ms);
                user.Image = ms.ToArray();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.UserId;
        }

        public async Task<UserDTO?> GetUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            return new UserDTO
            {
                UserId = user.UserId,
                ImageFile = user.Image != null ? new FormFile(
                    new MemoryStream(user.Image), 0, user.Image.Length, "Image", "image.jpg") : null
            };
        }
    }
}
