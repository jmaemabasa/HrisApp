using System.Text.Json;

namespace HrisApp.Client.Services.Assets.AssetAccessImageService
{
#nullable disable

    public class AssetAccessImageService : IAssetAccessImageService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetAccessImageService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetAccessImageT> AssetAccessImageTs { get; set; } = new List<AssetAccessImageT>();

        public async Task UpdateDBImage(AssetAccessImageT img)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AssetAccessImage/{img.Id}", img);
            //await Ok(result);
        }

        public async Task<AssetAccessImageT> GetSingleImage(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetAccessImageT>($"api/AssetAccessImage/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");
        }

        public async Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AssetAccessImage/PostUploadImage?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssetAccessImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssetAccessImageTs = AssetAccessImageTs.Concat(newResult).ToList();
                        }
                    }
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
                var response = await _httpClient.PostAsync($"/api/AssetAccessImage/PostUploadImagePanel?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssetAccessImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssetAccessImageTs = AssetAccessImageTs.Concat(newResult).ToList();
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
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssetAccessImage/Getattachmentview?jmcode={jmcode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<byte[]> GetImageDataAll(string filename)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssetAccessImage/GetattachmentviewAll?filename={filename}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<AssetAccessImageT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetAccessImageT>>("api/AssetAccessImage");
        }

        public async Task GetAllImagesPerAss(string jmcode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetAccessImageT>>($"api/AssetAccessImage/GetFilteredImages?jmcode={jmcode}");
            if (result != null)
            {
                AssetAccessImageTs = result;
            }
        }

        public async Task DeleteAssetImg(string filename, string jmcode)
        {
            await _httpClient.DeleteAsync($"api/AssetAccessImage/DeleteAssetImg?filename={filename}&jmcode={jmcode}");
        }
    }
}