using System.Text.Json;

namespace HrisApp.Client.Services.Assets.Consumables.ConsumableImgService
{
#nullable disable
    public class ConsumableImgService : IConsumableImgService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public ConsumableImgService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<ConsumableImageT> ConsumableImageTs { get; set; } = new List<ConsumableImageT>();

        public async Task UpdateDBImage(ConsumableImageT img)
        {
            await _httpClient.PutAsJsonAsync($"api/ConsumeImage/{img.Id}", img);
            //await Ok(result);
        }

        public async Task<ConsumableImageT> GetSingleImage(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ConsumableImageT>($"api/ConsumeImage/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");
        }

        public async Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/ConsumeImage/PostUploadImage?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<ConsumableImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            ConsumableImageTs = ConsumableImageTs.Concat(newResult).ToList();
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
                var response = await _httpClient.PostAsync($"/api/ConsumeImage/PostUploadImagePanel?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<ConsumableImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            ConsumableImageTs = ConsumableImageTs.Concat(newResult).ToList();
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
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/ConsumeImage/Getattachmentview?jmcode={jmcode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<byte[]> GetImageDataAll(string filename)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/ConsumeImage/GetattachmentviewAll?filename={filename}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<ConsumableImageT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<ConsumableImageT>>("api/ConsumeImage");
        }

        public async Task GetAllImagesPerAss(string jmcode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ConsumableImageT>>($"api/ConsumeImage/GetFilteredImages?jmcode={jmcode}");
            if (result != null)
            {
                ConsumableImageTs = result;
            }
        }

        public async Task DeleteAssetImg(string filename, string jmcode)
        {
            await _httpClient.DeleteAsync($"api/ConsumeImage/DeleteAssetImg?filename={filename}&jmcode={jmcode}");
        }
    }
}
