namespace HrisApp.Client.Services.EmpDetails.EducationService
{
    public class EducationService : IEducationService
    {
#nullable disable
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public EducationService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<Emp_PrimaryT>> GetExistPrimary(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_PrimaryT>>($"api/Primary/GetExistPrimary?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<Emp_SecondaryT>> GetExistSecondary(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_SecondaryT>>($"api/Secondary/GetExistSecondary?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<Emp_SeniorHST>> GetExistSeniorHS(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_SeniorHST>>($"api/SeniorHS/GetExistSeniorHS?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<Emp_CollegeT>> GetExistCollege(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_CollegeT>>($"api/College/GetExistCollege?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<Emp_MasteralT>> GetExistMasteral(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_MasteralT>>($"api/Masteral/GetExistMasteral?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<Emp_DoctorateT>> GetExistDoctorate(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_DoctorateT>>($"api/Doctorate/GetExistDoctorate?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<Emp_OtherEducT>> GetExistOtherEduc(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_OtherEducT>>($"api/OthersEduc/GetExistOtherEduc?verifyId={verifyId}&id={id}");
            return result;
        }

        public List<Emp_PrimaryT> _primary { get; set; } = new List<Emp_PrimaryT>();
        public async Task<List<Emp_PrimaryT>> GetPrimarylist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_PrimaryT>>($"api/Primary/GetPrimarylist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreatePrimary(Emp_PrimaryT primary)
        {
            Console.WriteLine("Saving primary");
            var result = await _httpClient.PostAsJsonAsync("api/Primary", primary);
            var response = await result.Content.ReadFromJsonAsync<Emp_PrimaryT>();
            return response?.Verify_Id;
        }
        public async Task UpdatePrimary(Emp_PrimaryT _primaries)
        {
            Console.WriteLine("Update Primary ");
            var result = await _httpClient.PutAsJsonAsync($"api/Primary/UpdatePrimary/{_primaries.Id}", _primaries);
            var response = result.StatusCode.ToString();
        }
        public async Task DeletePrimary(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Primary/{id}");
            //await SetPrimary(result);
        }
        public async Task CreateNewupdate(Emp_PrimaryT _primaries)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Primary", _primaries);
            await SetPrimary(result);
        }

        private async Task SetPrimary(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_PrimaryT>>();
            _primary = response;
        }

        public List<Emp_SecondaryT> _secondary { get; set; } = new List<Emp_SecondaryT>();
        public async Task<List<Emp_SecondaryT>> GetSecondarylist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_SecondaryT>>($"api/Secondary/GetSecondarylist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateSecondary(Emp_SecondaryT _secondaries)
        {
            Console.WriteLine("Saving secondary");
            var result = await _httpClient.PostAsJsonAsync("api/Secondary", _secondaries);
            var response = await result.Content.ReadFromJsonAsync<Emp_SecondaryT>();
            return response?.Verify_Id;
        }
        public async Task UpdateSecondary(Emp_SecondaryT _secondaries)
        {
            Console.WriteLine("Update Secondary ");
            var result = await _httpClient.PutAsJsonAsync($"api/Secondary/UpdateSecondary/{_secondaries.Id}", _secondaries);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteSecondary(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Secondary/{id}");
            //await SetPrimary(result);
        }

        public List<Emp_SeniorHST> _seniors { get; set; } = new List<Emp_SeniorHST>();
        public async Task<List<Emp_SeniorHST>> GetSeniorHSlist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_SeniorHST>>($"api/SeniorHS/GetSeniorHSlist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateSeniorHS(Emp_SeniorHST _shs)
        {
            Console.WriteLine("Saving SeniorHS");
            var result = await _httpClient.PostAsJsonAsync("api/SeniorHS", _shs);
            var response = await result.Content.ReadFromJsonAsync<Emp_SeniorHST>();
            return response?.Verify_Id;
        }
        public async Task UpdateSeniorHS(Emp_SeniorHST _shs)
        {
            Console.WriteLine("Update SeniorHS ");
            var result = await _httpClient.PutAsJsonAsync($"api/SeniorHS/UpdateSeniorHS/{_shs.Id}", _shs);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteSHS(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/SeniorHS/{id}");
            //await SetPrimary(result);
        }

        public List<Emp_CollegeT> _college { get; set; }
        public async Task<List<Emp_CollegeT>> GetCollegelist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_CollegeT>>($"api/College/GetCollegelist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateCollege(Emp_CollegeT _colleges)
        {
            Console.WriteLine("Saving College");
            var result = await _httpClient.PostAsJsonAsync("api/College", _colleges);
            var response = await result.Content.ReadFromJsonAsync<Emp_CollegeT>();
            return response?.Verify_Id;
        }
        public async Task UpdateCollege(Emp_CollegeT _colleges)
        {
            Console.WriteLine("Update College ");
            var result = await _httpClient.PutAsJsonAsync($"api/College/UpdateCollege/{_colleges.Id}", _colleges);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteCollege(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/College/{id}");
            //await SetPrimary(result);
        }

        public List<Emp_MasteralT> _masteral { get; set; }
        public async Task<List<Emp_MasteralT>> GetMasterallist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_MasteralT>>($"api/Masteral/GetMasterlist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateMasteral(Emp_MasteralT _mas)
        {
            Console.WriteLine("Saving Masteral");
            var result = await _httpClient.PostAsJsonAsync("api/Masteral", _mas);
            var response = await result.Content.ReadFromJsonAsync<Emp_MasteralT>();
            return response?.Verify_Id;
        }
        public async Task UpdateMasteral(Emp_MasteralT _mas)
        {
            Console.WriteLine("Update Masteral ");
            var result = await _httpClient.PutAsJsonAsync($"api/Masteral/UpdateMasteral/{_mas.Id}", _mas);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteMasteral(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Masteral/{id}");
            //await SetPrimary(result);
        }

        public List<Emp_DoctorateT> _doctorate { get; set; }
        public async Task<List<Emp_DoctorateT>> GetDoctoratelist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_DoctorateT>>($"api/Doctorate/GetDoctoratelist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateDoctorate(Emp_DoctorateT _doc)
        {
            Console.WriteLine("Saving Doctorate");
            var result = await _httpClient.PostAsJsonAsync("api/Doctorate", _doc);
            var response = await result.Content.ReadFromJsonAsync<Emp_DoctorateT>();
            return response?.Verify_Id;
        }
        public async Task UpdateDoctorate(Emp_DoctorateT _doc)
        {
            Console.WriteLine("Update Doctorate ");
            var result = await _httpClient.PutAsJsonAsync($"api/Doctorate/UpdateDoctorate/{_doc.Id}", _doc);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteDoctorate(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Doctorate/{id}");
            //await SetPrimary(result);
        }

        public List<Emp_OtherEducT> _other { get; set; }
        public async Task<List<Emp_OtherEducT>> GetOtherEduclist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_OtherEducT>>($"api/OthersEduc/GetOtherEduclist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateOtherEduc(Emp_OtherEducT _others)
        {
            Console.WriteLine("Saving OtherEduc");
            var result = await _httpClient.PostAsJsonAsync("api/OthersEduc", _others);
            var response = await result.Content.ReadFromJsonAsync<Emp_OtherEducT>();
            return response?.Verify_Id;
        }
        public async Task UpdateOtherEduc(Emp_OtherEducT _others)
        {
            Console.WriteLine("Update OtherEduc ");
            var result = await _httpClient.PutAsJsonAsync($"api/OthersEduc/UpdateOtherEduc/{_others.Id}", _others);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteOtherEduc(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/OthersEduc/{id}");
            //await SetPrimary(result);
        }
    }
}
