using UserServices.DTO;

namespace UserServices.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(UserDTO userDto);
        Task<UserDTO?> GetUserAsync(int userId);
    }
}
