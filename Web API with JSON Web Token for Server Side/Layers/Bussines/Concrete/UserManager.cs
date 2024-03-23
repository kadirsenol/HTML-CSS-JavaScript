using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Concrete
{
    public class UserManager : Manager<User, int>, IUserManager
    {

        //IUserManagerde is kurallari olusturursan ilgili manager metodunu override edip configure edebilirsin.
        public async Task<User> ChackUser(User entity)
        {
            User user = await base.FirstOrDefault(p => p.Email == entity.Email && p.Password == entity.Password);
            if (user == null)
            {
                throw new Exception("Kullanıcı adı veya şifre hatalı");
            }
            else
            {
                return user;
            }

        }
    }
}
