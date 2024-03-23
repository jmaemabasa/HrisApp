using System.Text.Json;

namespace HrisApp.Client.Services.Assets.AssVehicleImageSvc
{
#nullable disable
    public class AssVehicleImageSvc : IAssVehicleImageSvc
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssVehicleImageSvc()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetVehicleImageT> AssetVehicleImageTs { get; set; } = new List<AssetVehicleImageT>();

        public async Task UpdateDBImage(AssetVehicleImageT img)
        {
            await _httpClient.PutAsJsonAsync($"api/AssVehicleImage/{img.Id}", img);
            //await Ok(result);
        }

        public async Task<AssetVehicleImageT> GetSingleImage(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetVehicleImageT>($"api/AssVehicleImage/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");
        }

        public async Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AssVehicleImage/PostUploadImage?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssetVehicleImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssetVehicleImageTs = AssetVehicleImageTs.Concat(newResult).ToList();
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
                var response = await _httpClient.PostAsync($"/api/AssVehicleImage/PostUploadImagePanel?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssetVehicleImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssetVehicleImageTs = AssetVehicleImageTs.Concat(newResult).ToList();
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
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssVehicleImage/Getattachmentview?jmcode={jmcode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<byte[]> GetImageDataAll(string filename)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssVehicleImage/GetattachmentviewAll?filename={filename}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<AssetVehicleImageT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetVehicleImageT>>("api/AssVehicleImage");
        }

        public async Task GetAllImagesPerAss(string jmcode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetVehicleImageT>>($"api/AssVehicleImage/GetFilteredImages?jmcode={jmcode}");
            if (result != null)
            {
                AssetVehicleImageTs = result;
            }
        }

        public async Task DeleteAssetImg(string filename, string jmcode)
        {
            await _httpClient.DeleteAsync($"api/AssVehicleImage/DeleteAssetImg?filename={filename}&jmcode={jmcode}");
        }
    }
}
