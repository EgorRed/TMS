using Microsoft.AspNetCore.Http.Connections;
using Microsoft.EntityFrameworkCore;
using Registration.Model;

namespace Registration.Service
{
    public class UserManagerService : IUserManagerService
    {
        private UserDbContext _db;


        public UserManagerService(UserDbContext db) 
        {
            _db = db;
        }


        public async Task DeleteUser(int userId)
        {
            var surchUser = await _db.Users.Where(x => x.id == userId).SingleOrDefaultAsync();
            if (surchUser != null)
            {
                //await _db.Users.Where(x => x.id == userId).ExecuteDeleteAsync();
            }
            else
            {
                throw new Exception($"user with this ID \"{userId} \" does not exist");
            }
        }


        public async Task<User[]> GetAllUsers()
        {
            return await _db.Users.ToArrayAsync();
        }


        public async Task<bool> LoginToAccount(UserDto userDto)
        {
            var surchUser = await _db.Users.Where(x => x.login.Equals(userDto.login)).SingleOrDefaultAsync();
            if (surchUser != null)
            {

                var verification = await _db.Users.Where(x => x.password.Equals(PasswordGeneration(userDto))).SingleOrDefaultAsync();
                if (verification != null)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new Exception($"user \"{userDto.login} \" does not exist");
            }
        }


        public async Task UserRegistration(UserDto userDto)
        {
            User user = new User();
            user.login = userDto.login;
            user.password = PasswordGeneration(userDto);
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }


        public string PasswordGeneration(UserDto userDto)
        {
            return (userDto.login.GetHashCode() + userDto.password.GetHashCode()).ToString();
        }

        //string IUserManagerService.PasswordGeneration(UserDto userDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
