using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract;
using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Concrete
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
