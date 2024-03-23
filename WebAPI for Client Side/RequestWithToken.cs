using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAPI_for_Client_Side.Models.withToken;

namespace WebAPI_for_Client_Side
{
    public class RequestWithToken
    {
        public async Task<HttpClient> HeaderConfig()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5272/"); // Api Saglayicisinin baselinki
            client.DefaultRequestHeaders.Accept.Clear(); // Istek basliginda ki isteklerimizin once temizlenmesi.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Request header'ımızın icerisinde ki content type json olarak tanımladık. Api saglaycisindan json formatinda veri istedigimizi belirtiyoruz. "*/*" bu ifade her turlu veri kabul ettigimi ifade eder.
            return client;
            //Reques header = Istek gondermeden once istegimiz hakkında ve kabul edecegimiz cevaplar hakkinda ayarlarin tanimlanmasi
            //Response header = Api saglayicisi tarafindan olusturulmus, sunacagi cevaplar hakkindaki bilgilerin tanimlanmasi.
        }

        public async Task<string> AccountPostApi(UserLoginVm userLoginVm)
        {
            HttpClient client = await HeaderConfig();
            var json = JsonConvert.SerializeObject(userLoginVm); // Api saglayicisina json gonderebilmek icin
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // Json saglayicisina gonderecegimiz veri adina request headeri icerisinde ki bilgileri olusturuyoruz. (gonderecegimiz veri, karakter turu,verinin tipi)
            var respons = await client.PostAsync("api/Account", data); // Post islemi gerceklesmesi
            string JsonAccesstoken = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi
            string accesstoken = JsonConvert.DeserializeObject<string>(JsonAccesstoken);
            await Console.Out.WriteLineAsync(accesstoken);
            return accesstoken;
        }

        public async Task GetApi(UserLoginVm userLoginVm)
        {

            HttpClient client = await HeaderConfig();
            string accesstoken = await AccountPostApi(userLoginVm);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // Alinan tokeni client nesnesinin istek basliginda ki authorizationuna ekledikten sonra istenilen istekler yapilabilir.

            var result = await client.GetAsync("api/Urun/GetAll"); // Olusturulan client ile yapilacak api islemi tanimlanir

            if (result.IsSuccessStatusCode)
            {
                string result2 = await result.Content.ReadAsStringAsync(); // Response header icerisinde ki contenti json formatında alır. Cunku saglayici response header icerisinde ki content type i json olarak tanimlamis.
                List<Urun> uruns = new List<Urun>();
                uruns = JsonConvert.DeserializeObject<List<Urun>>(result2); // Json formati istedigimiz formata deserilize edildi.
                foreach (var item in uruns)
                {
                    await Console.Out.WriteLineAsync(item.UrunAdi);
                }

            }

        }

        public async Task GetByIdApi(UserLoginVm userLoginVm, int id)
        {
            HttpClient client = await HeaderConfig();
            string accesstoken = await AccountPostApi(userLoginVm);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // Alinan tokeni client nesnesinin istek basliginda ki authorizationuna ekledikten sonra istenilen istekler yapilabilir.

            var result = await client.GetAsync($"api/Urun/GetById/{id}"); // Olusturulan client ile yapilacak api islemi tanimlanir

            if (result.IsSuccessStatusCode)
            {
                string result2 = await result.Content.ReadAsStringAsync(); // Response header icerisinde ki contenti json formatında alır. Cunku saglayici response header icerisinde ki content type i json olarak tanimlamis.
                Urun urun = JsonConvert.DeserializeObject<Urun>(result2); // Json formati istedigimiz formata deserilize edildi.

                await Console.Out.WriteLineAsync(urun.UrunAdi);
            }
        }

        public async Task PostApi(UserLoginVm userLoginVm, Urun urun)
        {
            HttpClient client = await HeaderConfig();
            string accesstoken = await AccountPostApi(userLoginVm);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // Alinan tokeni client nesnesinin istek basliginda ki authorizationuna ekledikten sonra istenilen istekler yapilabilir.
            var json = JsonConvert.SerializeObject(urun); // Api saglayicisina json gonderebilmek icin
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // Json saglayicisina gonderecegimiz veri adina request headeri icerisinde ki bilgileri olusturuyoruz. (gonderecegimiz veri, karakter turu,verinin tipi)
            var respons = await client.PostAsync("api/Urun", data); // Post islemi gerceklesmesi
            string status = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi

            await Console.Out.WriteLineAsync(status);
        }


        public async Task PutApi(UserLoginVm userLoginVm, Urun urun)
        {

            HttpClient client = await HeaderConfig();
            string accesstoken = await AccountPostApi(userLoginVm);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // Alinan tokeni client nesnesinin istek basliginda ki authorizationuna ekledikten sonra istenilen istekler yapilabilir.           
            var json = JsonConvert.SerializeObject(urun); // Api saglayicisina json gonderebilmek icin
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // Json saglayicisina gonderecegimiz veri adina request header icerisinde ki bilgileri olusturuyoruz. (gonderecegimiz veri, karakter turu,verinin tipi)
            var respons = await client.PutAsync("api/Urun", data); // Put islemi gerceklesmesi,server side tarafinda id parametresi de beklenildigi icin /id yazilmasi gereklidir.
            string result = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi

            await Console.Out.WriteLineAsync(result);


        }

        public async Task DeleteApi(UserLoginVm userLoginVm, int id)
        {

            HttpClient client = await HeaderConfig();
            string accesstoken = await AccountPostApi(userLoginVm);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken); // Alinan tokeni client nesnesinin istek basliginda ki authorizationuna ekledikten sonra istenilen istekler yapilabilir.   
            var respons = await client.DeleteAsync($"api/Urun/{id}"); // Delete islemi gerceklesmesi,server side tarafinda id parametresi de beklenildigi icin /id yazilmasi gereklidir.
            string result = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi

            await Console.Out.WriteLineAsync(result);


        }
    }
}
