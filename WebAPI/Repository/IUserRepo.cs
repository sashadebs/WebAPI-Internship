using WebAPI.Model;

namespace EFApplication.Repository
{
    public interface IUserRepo
    {
        //Users GetUser(int uID);
        Users GetUser(Users user);
    }
}
