namespace HrisApp.Client.Services.AnnouncementS
{
#nullable disable
    public class AnnouncementService : IAnnouncementService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public AnnouncementService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AnnouncementT> AnnouncementTs { get; set; }

        public async Task CreateAnnouncement(AnnouncementT obj)
        {
            var res = await _httpClient.PostAsJsonAsync("api/Announcement/CreateAnnouncement", obj);
        }

        public async Task GetAnnouncement()
        {
            var res = await _httpClient.GetFromJsonAsync<List<AnnouncementT>>("api/Announcement/GetAnnouncement");
            if (res != null)
            {
                AnnouncementTs = res;
            }
        }

        public async Task<List<AnnouncementT>> GetAnnouncementList()
        {
            var res = await _httpClient.GetFromJsonAsync<List<AnnouncementT>>("api/Announcement");
            if (res != null)
            {
                return res;
            }
            else { return null; }
        }
        
        public async Task<List<AnnouncementT>> GetFilteredAnnouncementList()
        {
            var res = await _httpClient.GetFromJsonAsync<List<AnnouncementT>>("api/Announcement/GetFilteredAnnouncement");
            if (res != null)
            {
                return res;
            }
            else { return null; }
        }

        public async Task<AnnouncementT> GetSingleAnnouncement(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AnnouncementT>($"api/Announcement/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task UpdateAnnouncement(AnnouncementT obj)
        {
            try
            {
                var res = await _httpClient.PutAsJsonAsync("api/Announcement/UpdateAnnouncement", obj);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex + " hays");
            }
        }
    }
}
