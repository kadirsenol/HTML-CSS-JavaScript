using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Bussines.Abstract
{
    public interface IUserManager : IManager<User, int>
    {
        //Gerekli is kurallari var ise eklenecek.
        public Task<User> ChackUser(User entity);


    }
}
