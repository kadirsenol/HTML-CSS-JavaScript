using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebAPI_for_Client_Side.Models;
namespace WebAPI_for_Client_Side
{
    public class RequestWithoutToken
    {
        public async Task<HttpClient> HeaderConfig()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.vercel.app/"); // Api Saglayicisinin baselinki
            client.DefaultRequestHeaders.Accept.Clear(); // Istek basliginda ki isteklerimizin once temizlenmesi.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Request header'ımızın icerisinde ki content type json olarak tanımladık. Api saglaycisindan json formatinda veri istedigimizi belirtiyoruz. "*/*" bu ifade her turlu veri kabul ettigimi ifade eder.
            return client;
            //Reques header = Istek gondermeden once istegimiz hakkında ve kabul edecegimiz cevaplar hakkinda ayarlarin tanimlanmasi
            //Response header = Api saglayicisi tarafindan olusturulmus, sunacagi cevaplar hakkindaki bilgilerin tanimlanmasi.
        }

        public async Task GetApi()
        {

            HttpClient client = await HeaderConfig();

            var result = await client.GetAsync("api/shippers"); // Olusturulan client ile yapilacak api islemi tanimlanir

            if (result.IsSuccessStatusCode)
            {
                string result2 = await result.Content.ReadAsStringAsync(); // Response header icerisinde ki contenti json formatında alır. Cunku saglayici response header icerisinde ki content type i json olarak tanimlamis.
                List<Shipper> shippers = new List<Shipper>();
                shippers = JsonConvert.DeserializeObject<List<Shipper>>(result2); // Json formati istedigimiz formata deserilize edildi.
                foreach (var item in shippers)
                {
                    await Console.Out.WriteLineAsync(item.companyName);
                }

            }

        }

        public async Task PostApi()
        {

            HttpClient client = await HeaderConfig();
            Shipper shipper = new Shipper() { companyName = "MNG", phone = "444 3 444" };
            var json = JsonConvert.SerializeObject(shipper); // Api saglayicisina json gonderebilmek icin
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // Json saglayicisina gonderecegimiz veri adina request headeri icerisinde ki bilgileri olusturuyoruz. (gonderecegimiz veri, karakter turu,verinin tipi)
            var respons = await client.PostAsync("api/shippers", data); // Post islemi gerceklesmesi
            string result = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi

            Console.WriteLine(result);

        }


        public async Task PutApi()
        {

            HttpClient client = await HeaderConfig();
            Shipper shipper = new Shipper() { id = 4, companyName = "Surat", phone = "444 3 444" }; // id bilgisi server side tarafinda gonderilen id ile route de ki id aynı mı kontrolü saglanabilmesi adina yazilir. Ama bu sekilde de id bilgisini degistirilemez kilinir cunku server side tarafinda id kontrolu saglanacagi icin.
            var json = JsonConvert.SerializeObject(shipper); // Api saglayicisina json gonderebilmek icin
            var data = new StringContent(json, Encoding.UTF8, "application/json"); // Json saglayicisina gonderecegimiz veri adina request header icerisinde ki bilgileri olusturuyoruz. (gonderecegimiz veri, karakter turu,verinin tipi)
            var respons = await client.PutAsync("api/shippers/" + shipper.id.ToString(), data); // Put islemi gerceklesmesi,server side tarafinda id parametresi de beklenildigi icin /id yazilmasi gereklidir.
            string result = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi

            Console.WriteLine(result);


        }

        public async Task DeleteApi()
        {


            HttpClient client = await HeaderConfig();
            var respons = await client.DeleteAsync("api/shippers/4"); // Delete islemi gerceklesmesi,server side tarafinda id parametresi de beklenildigi icin /id yazilmasi gereklidir.
            string result = await respons.Content.ReadAsStringAsync(); // Gelen responsun headerinin contentinin okunmasi

            await Console.Out.WriteLineAsync(result);


        }

    }
}
