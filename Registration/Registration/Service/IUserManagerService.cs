using Registration.Model;

namespace Registration.Service
{
    public interface IUserManagerService
    {
        Task UserRegistration(UserDto user);
        Task<bool> LoginToAccount(UserDto user);
        Task DeleteUser(int userId);
        Task<User[]> GetAllUsers();
        string PasswordGeneration(UserDto userDto);
    }
}
