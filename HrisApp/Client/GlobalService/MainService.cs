namespace HrisApp.Client.GlobalService
{
    public class MainsService : IMainsService
    {
        private static HttpClient _httpClient;
        public MainsService()
        {

        }

        public MainsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public HttpClient Get_Http()
        {
            return _httpClient;
        }

        public async Task Set_Http()
        {
            await Task.Delay(1);
        }
    }
}
