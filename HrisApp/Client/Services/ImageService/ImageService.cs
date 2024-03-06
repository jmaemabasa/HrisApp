using System.Text.Json;

namespace HrisApp.Client.Services.ImageService
{
#nullable disable

    public class ImageService : IImageService
    {
        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public ImageService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<EmpPictureT> EmpPictureTs { get; set; } = new List<EmpPictureT>();
        public List<DocumentT> DocumentTs { get; set; } = new List<DocumentT>();

        public async Task UpdateDBImage(EmpPictureT img)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Image/{img.Id}", img);
            //await Ok(result);
        }

        public async Task<EmpPictureT> GetSingleImage(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmpPictureT>($"api/Image/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");
        }

        public async Task AttachFile(MultipartFormDataContent formdata, string EmployeeId, int division, int department, string lastname, string verify)
        {
            Console.WriteLine($"Multipart={formdata.Count()}, EmployId={EmployeeId}, DivisionId={division}, Department={department},Lastname={lastname}, VerifyId={verify}");
            try
            {
                var response = await _httpClient.PostAsync($"/api/Image/PostUploadImage?EmployeeId={EmployeeId}&division={division}&department={department}&lastname={lastname}&verify={verify}", formdata);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(content))
                    {
                        var newResult = JsonSerializer.Deserialize<List<EmpPictureT>>(content, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (newResult is not null)
                        {
                            EmpPictureTs = EmpPictureTs.Concat(newResult).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Services Error: {ex.Message}");
            }
        }

        public async Task<byte[]> GetImageData(string verifyCode)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/Image/Getattachmentview?verifyCode={verifyCode}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<byte[]>> GetPDFData(string verifyCode, string EmployeeNo)
        {
            try
            {
                var pdfList = await _httpClient.GetFromJsonAsync<List<byte[]>>($"api/Document/GetPDFview?&EmployeeNo={EmployeeNo}&verifyCode={verifyCode}");
                if (pdfList != null)
                    return pdfList;

                throw new Exception("No PDFs Found");
            }
            catch (Exception)
            {
                ////Console.WriteLine($"Exception occurred while fetching PDF data: {ex.Message}");
                //foreach (var area in DocumentTs)
                //{
                //    Console.WriteLine($"verify Id: {area.Verify_Id}, Name: {area.EmployeeNo}");
                //}
                return null;
            }
        }

        public async Task GetNewPDF(string verifyId, string employeId)
        {
            var result = await _httpClient.GetFromJsonAsync<List<DocumentT>>($"api/Document/GetFilteredPDF?verifyId={verifyId}&employeId={employeId}");
            if (result != null)
            {
                DocumentTs = result;
                // Console.WriteLine to check if the data is fetched
                //foreach (var area in documentImages)
                //{
                //    Console.WriteLine($"verify Id: {area.Verify_Id}, Name: {area.EmployeeNo}");
                //}
            }
        }

        public async Task AttachedFile(MultipartFormDataContent formdata, string EmployeeId, int division, int department, string lastname, string verify)
        {
            var response = await _httpClient.PostAsync($"api/Document/Postoutletfile?EmployeeId={EmployeeId}&division={division}&department={department}&lastname={lastname}&verify={verify}", formdata);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    var newResult = JsonSerializer.Deserialize<List<DocumentT>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (newResult is not null)
                    {
                        DocumentTs = DocumentTs.Concat(newResult).ToList();
                    }
                }
            }
        }

        public async Task<string> GetAttfileName(string _employeeId, string _verifyCode)
        {
            try
            {
                var _list = await _httpClient.GetFromJsonAsync<List<DocumentT>>($"api/Document/GetFilteredPDF?verifyId={_verifyCode}&employeId={_employeeId}");
                var _model = _list.FirstOrDefault();
                return _model.Img_Filename;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Services error: {ex.Message}");
                return ex.Message;
            }
        }

        public async Task<byte[]> Getdocumentfileview(string _employeeId, string _verifyCode, string _filename)
        {
            var _imgs = await _httpClient.GetFromJsonAsync<byte[]>($"api/Document/Getdocumentfileview?employeeId={_employeeId}&verifyCode={_verifyCode}&filename={_filename}");
            if (_imgs != null)
                return _imgs;
            throw new Exception("No Signature Found");
        }

        public async Task<List<DocumentT>> GetDocuImagelist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<DocumentT>>($"api/Document/GetDocuImagelist?verCode={verCode}");
            return result;
        }
    }
}