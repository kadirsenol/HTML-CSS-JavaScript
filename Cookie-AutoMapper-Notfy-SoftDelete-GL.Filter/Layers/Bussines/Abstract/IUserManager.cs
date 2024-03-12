using Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Entities.Concrete;

namespace Cookie_AutoMapper_Notfy_SoftDelete_GL.Filter.Layers.Bussines.Abstract
{
    public interface IUserManager : IManager<User, int>
    {
        //Gerekli is kurallari var ise eklenecek.
        public Task<User> ChackUser(User entity);
    }
}
