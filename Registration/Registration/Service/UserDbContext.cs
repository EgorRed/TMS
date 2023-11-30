
using Microsoft.EntityFrameworkCore;
using Registration.Model;

namespace Registration.Service
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=UsersData;Trusted_Connection=True");
        }

        //public UserDbContext(DbContextOptions<UserDbContext> options)
        //    : base(options) { }
    }
}
