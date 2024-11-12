



using WebApplication1.Models.Models;

namespace WebApplication1.Models.Interfaces
{
    public interface IUserManager
    {
        public void CreateUser(UserModel user);
        public List<UserModel> GetAllUser();
        public string UpdateUser(int id, UserModel user);
    }
}