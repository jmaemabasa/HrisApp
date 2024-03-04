using System.Text.Json;

namespace HrisApp.Client.Services.Assets.AssetImageService
{
#nullable disable

    public class AssetImageService : IAssetImageService
    {
        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public AssetImageService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetImageT> AssetImageTs { get; set; } = new List<AssetImageT>();

        public async Task UpdateDBImage(AssetImageT img)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AssetImage/{img.Id}", img);
            //await Ok(result);
        }

        public async Task<AssetImageT> GetSingleImage(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetImageT>($"api/AssetImage/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");
        }

        public async Task AttachFile(MultipartFormDataContent formdata, string assetcode, int category, int subcat, string jmcode)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AssetImage/PostUploadImage?assetcode={assetcode}&category={category}&subcat={subcat}&jmcode={jmcode}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssetImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssetImageTs = AssetImageTs.Concat(newResult).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Services Error: {ex.Message}");
            }
        }

        public async Task AttachFilePanel(MultipartFormDataContent formdata, string assetcode, int category, int subcat, string jmcode)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AssetImage/PostUploadImagePanel?assetcode={assetcode}&category={category}&subcat={subcat}&jmcode={jmcode}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssetImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssetImageTs = AssetImageTs.Concat(newResult).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Services Error: {ex.Message}");
            }
        }

        public async Task<byte[]> GetImageData(string jmcode)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssetImage/Getattachmentview?jmcode={jmcode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<byte[]> GetImageDataAll(string assetcode)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssetImage/GetattachmentviewAll?assetcode={assetcode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<AssetImageT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetImageT>>("api/AssetImage");
        }

        public async Task GetAllImagesPerAss(string jmcode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetImageT>>($"api/AssetImage/GetFilteredImages?jmcode={jmcode}");
            if (result != null)
            {
                AssetImageTs = result;
            }
        }
    }
}