using WebAPI_for_Client_Side.Models.withToken;

namespace WebAPI_for_Client_Side
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            #region RequestWithoutToken
            //RequestWithoutToken requestWithoutToken = new RequestWithoutToken();
            //await requestWithoutToken.GetApi();
            //await requestWithoutToken.DeleteApi();
            //await requestWithoutToken.PutApi();
            //await requestWithoutToken.PostApi(); 
            #endregion


            #region RequestWithToken
            UserLoginVm userLoginVm = new UserLoginVm() { Email = "kdr@hotmail.com", Password = "6161" };
            Urun urun = new Urun() { KategoriAdi = "Elektronik", StokAdet = 100, UrunAdi = "Capasitor", UrunFiyati = 10 };
            Urun updateurun = new Urun() { Id = 15, UrunAdi = "1 id ad degisti", KategoriAdi = "elektronik", StokAdet = 50, UrunFiyati = 100 };

            RequestWithToken requestWithToken = new RequestWithToken();

            //await requestWithToken.GetApi(userLoginVm);

            //await requestWithToken.GetByIdApi(userLoginVm, 1);

            //await requestWithToken.PostApi(userLoginVm, urun);

            await requestWithToken.PutApi(userLoginVm, updateurun);

            //await requestWithToken.DeleteApi(userLoginVm, 14);
            #endregion




        }
    }
}
