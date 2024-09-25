using EFApplication.Repository;
using WebAPI.Model;
using WebApp.Models;

namespace WebAPI.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext dbcontext;
        public UserRepo(AppDbContext db)
        {
            dbcontext = db;
        }

        Users IUserRepo.GetUser(Users user)
        {
            return dbcontext.Users.FirstOrDefault(u => u.username == user.username);
        }

    }
}
