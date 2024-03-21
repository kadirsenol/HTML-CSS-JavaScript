using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Web_API_with_JSON_Web_Token_for_Server_Side.Layers.Entities.Concrete;

namespace Web_API_with_JSON_Web_Token_for_Server_Side.MyExtensions.Tokens
{
    public class TokenManager() // Key degerini secrets dosyasi uzerinden refere verebilmek adina IConfiguration u parametre olarak aldim. Bu servislere default yuklu geliyor.
    {

        public async Task<User> CreateToken(User user, IConfiguration configuration)
        {


            List<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, user.Rol),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Ad),
                new Claim("TcNo", user.TcNo.ToString()) // Bunun icin istersen bir policy olusturabilirsin.
            };
            user.ExprationToken = DateTime.Now.AddMinutes(30);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])); //Bunu screet dosyasına yaz ve buraya orayı refere et
            SigningCredentials signingcredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //HmacSha256 kriptolama algoritma secenek kodu. JWT sitesinden secilebiliyor.
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: "http://localhost:5272", // Bu tokeni kim uretti.
                audience: "http://localhost:5272", // Bu token kimler tarafindan kullanilacak
                expires: user.ExprationToken,
                notBefore: DateTime.Now, // Token uretildikten ne kadar sure sonra devreye girsin
                signingCredentials: signingcredentials,
                claims: Claims

                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            user.AccessToken = handler.WriteToken(securityToken);
            user.RefreshToken = await CreateRefreshToken();

            return user;
        }

        public async Task<string> CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

    }
}
