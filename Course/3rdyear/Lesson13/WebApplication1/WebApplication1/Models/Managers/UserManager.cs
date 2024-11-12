


using WebApplication1.Models.Interfaces;
using WebApplication1.Models.Models;

namespace WebApplication1.Models.Managers
{
    public class UserManager : IUserManager
    {
        
        private readonly DatabaseContext _databaseContext;

        public UserManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public void CreateUser(UserModel user)
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }

        public List<UserModel> GetAllUser()
        {
            return _databaseContext.Users.ToList();
        }

        public string UpdateUser(int id, UserModel user)
        {
            UserModel findUser = _databaseContext.Users.FirstOrDefault(u => u.Id == id);

            if (findUser == null)
            {
                return "User not found";
            }
            
            findUser.Username = user.Username;
            findUser.Password = user.Password;
            
            _databaseContext.SaveChanges();
            return "User updated";
        }
    }
}

