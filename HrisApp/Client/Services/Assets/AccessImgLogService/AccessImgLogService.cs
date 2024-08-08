namespace HrisApp.Client.Services.Assets.AccessImgLogService
{
    public class AccessImgLogService : IAccessImgLogService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AccessImgLogService()
        {
            _httpClient = _mainService.Get_Http();
        }
        public async Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AccessImgLog/PostUploadImage?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Services Error: {ex.Message}");
            }
        }


        public async Task AttachFilePanel(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AccessImgLog/PostUploadImagePanel?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Services Error: {ex.Message}");
            }
        }

        public async Task<List<AccessImgLogT>> GetAllImagesPerAss(string jmcode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AccessImgLogT>>($"api/AccessImgLog/GetFilteredImages?jmcode={jmcode}");

            return result!;
        }
        public async Task<byte[]> GetImageDataByFileName(string filename)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AccessImgLog/GetattachmentviewAll?filename={filename}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }
        public async Task DeleteAssetImg(string filename, string jmcode)
        {
            await _httpClient.DeleteAsync($"api/AccessImgLog/DeleteAssetImg?filename={filename}&jmcode={jmcode}");
        }
    }
}
