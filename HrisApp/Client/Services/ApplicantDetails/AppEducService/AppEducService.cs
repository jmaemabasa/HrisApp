namespace HrisApp.Client.Services.ApplicantDetails.AppEducService
{
#nullable disable
    public class AppEducService : IAppEducService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public AppEducService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<App_PrimaryT>> GetExistPrimary(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_PrimaryT>>($"api/AppPrimary/GetExistPrimary?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<App_SecondaryT>> GetExistSecondary(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_SecondaryT>>($"api/AppSecondary/GetExistSecondary?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<App_SeniorHST>> GetExistSeniorHS(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_SeniorHST>>($"api/AppSeniorHS/GetExistSeniorHS?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<App_CollegeT>> GetExistCollege(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_CollegeT>>($"api/AppCollege/GetExistCollege?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<App_MasteralT>> GetExistMasteral(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_MasteralT>>($"api/AppMasteral/GetExistMasteral?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<App_DoctorateT>> GetExistDoctorate(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_DoctorateT>>($"api/AppDoctorate/GetExistDoctorate?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<App_OtherEducT>> GetExistOtherEduc(string verifyId, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_OtherEducT>>($"api/AppOthersEduc/GetExistOtherEduc?verifyId={verifyId}&id={id}");
            return result;
        }

        public List<App_PrimaryT> _primary { get; set; } = new List<App_PrimaryT>();
        public async Task<List<App_PrimaryT>> GetPrimarylist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_PrimaryT>>($"api/AppPrimary/GetPrimarylist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreatePrimary(App_PrimaryT primary)
        {
            Console.WriteLine("Saving primary");
            var result = await _httpClient.PostAsJsonAsync("api/AppPrimary", primary);
            var response = await result.Content.ReadFromJsonAsync<App_PrimaryT>();
            return response?.Verify_Id;
        }
        public async Task UpdatePrimary(App_PrimaryT _primaries)
        {
            Console.WriteLine("Update Primary ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppPrimary/UpdatePrimary/{_primaries.Id}", _primaries);
            var response = result.StatusCode.ToString();
        }
        public async Task DeletePrimary(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppPrimary/{id}");
            //await SetPrimary(result);
        }
        public async Task CreateNewupdate(App_PrimaryT _primaries)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppPrimary", _primaries);
            await SetPrimary(result);
        }

        private async Task SetPrimary(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<App_PrimaryT>>();
            _primary = response;
        }

        public List<App_SecondaryT> _secondary { get; set; } = new List<App_SecondaryT>();
        public async Task<List<App_SecondaryT>> GetSecondarylist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_SecondaryT>>($"api/AppSecondary/GetSecondarylist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateSecondary(App_SecondaryT _secondaries)
        {
            Console.WriteLine("Saving secondary");
            var result = await _httpClient.PostAsJsonAsync("api/AppSecondary", _secondaries);
            var response = await result.Content.ReadFromJsonAsync<App_SecondaryT>();
            return response?.Verify_Id;
        }
        public async Task UpdateSecondary(App_SecondaryT _secondaries)
        {
            Console.WriteLine("Update Secondary ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppSecondary/UpdateSecondary/{_secondaries.Id}", _secondaries);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteSecondary(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppSecondary/{id}");
            //await SetPrimary(result);
        }

        public List<App_SeniorHST> _seniors { get; set; } = new List<App_SeniorHST>();
        public async Task<List<App_SeniorHST>> GetSeniorHSlist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_SeniorHST>>($"api/AppSeniorHS/GetSeniorHSlist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateSeniorHS(App_SeniorHST _shs)
        {
            Console.WriteLine("Saving SeniorHS");
            var result = await _httpClient.PostAsJsonAsync("api/AppSeniorHS", _shs);
            var response = await result.Content.ReadFromJsonAsync<App_SeniorHST>();
            return response?.Verify_Id;
        }
        public async Task UpdateSeniorHS(App_SeniorHST _shs)
        {
            Console.WriteLine("Update SeniorHS ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppSeniorHS/UpdateSeniorHS/{_shs.Id}", _shs);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteSHS(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppSeniorHS/{id}");
            //await SetPrimary(result);
        }

        public List<App_CollegeT> _college { get; set; }
        public async Task<List<App_CollegeT>> GetCollegelist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_CollegeT>>($"api/AppCollege/GetCollegelist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateCollege(App_CollegeT _colleges)
        {
            Console.WriteLine("Saving College");
            var result = await _httpClient.PostAsJsonAsync("api/AppCollege", _colleges);
            var response = await result.Content.ReadFromJsonAsync<App_CollegeT>();
            return response?.Verify_Id;
        }
        public async Task UpdateCollege(App_CollegeT _colleges)
        {
            Console.WriteLine("Update College ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppCollege/UpdateCollege/{_colleges.Id}", _colleges);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteCollege(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppCollege/{id}");
            //await SetPrimary(result);
        }

        public List<App_MasteralT> _masteral { get; set; }
        public async Task<List<App_MasteralT>> GetMasterallist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_MasteralT>>($"api/AppMasteral/GetMasterlist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateMasteral(App_MasteralT _mas)
        {
            Console.WriteLine("Saving Masteral");
            var result = await _httpClient.PostAsJsonAsync("api/AppMasteral", _mas);
            var response = await result.Content.ReadFromJsonAsync<App_MasteralT>();
            return response?.Verify_Id;
        }
        public async Task UpdateMasteral(App_MasteralT _mas)
        {
            Console.WriteLine("Update Masteral ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppMasteral/UpdateMasteral/{_mas.Id}", _mas);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteMasteral(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppMasteral/{id}");
            //await SetPrimary(result);
        }

        public List<App_DoctorateT> _doctorate { get; set; }
        public async Task<List<App_DoctorateT>> GetDoctoratelist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_DoctorateT>>($"api/AppDoctorate/GetDoctoratelist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateDoctorate(App_DoctorateT _doc)
        {
            Console.WriteLine("Saving Doctorate");
            var result = await _httpClient.PostAsJsonAsync("api/AppDoctorate", _doc);
            var response = await result.Content.ReadFromJsonAsync<App_DoctorateT>();
            return response?.Verify_Id;
        }
        public async Task UpdateDoctorate(App_DoctorateT _doc)
        {
            Console.WriteLine("Update Doctorate ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppDoctorate/UpdateDoctorate/{_doc.Id}", _doc);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteDoctorate(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppDoctorate/{id}");
            //await SetPrimary(result);
        }

        public List<App_OtherEducT> _other { get; set; }
        public async Task<List<App_OtherEducT>> GetOtherEduclist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_OtherEducT>>($"api/AppOthersEduc/GetOtherEduclist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateOtherEduc(App_OtherEducT _others)
        {
            Console.WriteLine("Saving OtherEduc");
            var result = await _httpClient.PostAsJsonAsync("api/AppOthersEduc", _others);
            var response = await result.Content.ReadFromJsonAsync<App_OtherEducT>();
            return response?.Verify_Id;
        }
        public async Task UpdateOtherEduc(App_OtherEducT _others)
        {
            Console.WriteLine("Update OtherEduc ");
            var result = await _httpClient.PutAsJsonAsync($"api/AppOthersEduc/UpdateOtherEduc/{_others.Id}", _others);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteOtherEduc(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppOthersEduc/{id}");
            //await SetPrimary(result);
        }
    }
}
