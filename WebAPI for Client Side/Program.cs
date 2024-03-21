namespace WebAPI_for_Client_Side
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            #region RequestWithoutToken
            RequestWithoutToken requestWithoutToken = new RequestWithoutToken();
            await requestWithoutToken.GetApi();
            //await requestWithoutToken.DeleteApi();
            //await requestWithoutToken.PutApi();
            //await requestWithoutToken.PostApi(); 
            #endregion




        }
    }
}
