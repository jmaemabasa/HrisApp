using System.Text.Json;

namespace HrisApp.Client.Services.Assets.Licenses.AssLicenseImageService
{
#nullable disable
    public class AssLicenseImageService : IAssLicenseImageService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssLicenseImageService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssLicenseImageT> AssLicenseImageTs { get; set; } = new List<AssLicenseImageT>();

        public async Task UpdateDBImage(AssLicenseImageT img)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AssLicenseImage/{img.Id}", img);
            //await Ok(result);
        }

        public async Task<AssLicenseImageT> GetSingleImage(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssLicenseImageT>($"api/AssLicenseImage/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");
        }

        public async Task AttachFile(MultipartFormDataContent formdata, int category, int subcat, string jmcode, string remarks)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/AssLicenseImage/PostUploadImage?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssLicenseImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssLicenseImageTs = AssLicenseImageTs.Concat(newResult).ToList();
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
                var response = await _httpClient.PostAsync($"/api/AssLicenseImage/PostUploadImagePanel?category={category}&subcat={subcat}&jmcode={jmcode}&remarks={remarks}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<AssLicenseImageT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            AssLicenseImageTs = AssLicenseImageTs.Concat(newResult).ToList();
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
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssLicenseImage/Getattachmentview?jmcode={jmcode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<byte[]> GetImageDataAll(string filename)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/AssLicenseImage/GetattachmentviewAll?filename={filename}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<AssLicenseImageT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssLicenseImageT>>("api/AssLicenseImage");
        }

        public async Task GetAllImagesPerAss(string jmcode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssLicenseImageT>>($"api/AssLicenseImage/GetFilteredImages?jmcode={jmcode}");
            if (result != null)
            {
                AssLicenseImageTs = result;
            }
        }

        public async Task DeleteAssetImg(string filename, string jmcode)
        {
            await _httpClient.DeleteAsync($"api/AssLicenseImage/DeleteAssetImg?filename={filename}&jmcode={jmcode}");
        }
    }
}
