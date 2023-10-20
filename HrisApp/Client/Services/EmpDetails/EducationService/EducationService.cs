using HrisApp.Shared.Models.Education;
using System;
using static MudBlazor.Icons;

namespace HrisApp.Client.Services.EmpDetails.EducationService
{
    public class EducationService : IEducationService
    {
        private readonly HttpClient _http;
#nullable disable
        public EducationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PrimaryT>> GetExistPrimary(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<PrimaryT>>($"api/Primary/GetExistPrimary?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<SecondaryT>> GetExistSecondary(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<SecondaryT>>($"api/Secondary/GetExistSecondary?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<SeniorHST>> GetExistSeniorHS(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<SeniorHST>>($"api/SeniorHS/GetExistSeniorHS?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<CollegeT>> GetExistCollege(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<CollegeT>>($"api/College/GetExistCollege?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<MasteralT>> GetExistMasteral(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<MasteralT>>($"api/Masteral/GetExistMasteral?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<DoctorateT>> GetExistDoctorate(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<DoctorateT>>($"api/Doctorate/GetExistDoctorate?verifyId={verifyId}&id={id}");
            return result;
        }
        public async Task<List<OtherEducT>> GetExistOtherEduc(string verifyId, int id)
        {
            var result = await _http.GetFromJsonAsync<List<OtherEducT>>($"api/OthersEduc/GetExistOtherEduc?verifyId={verifyId}&id={id}");
            return result;
        }

        public List<PrimaryT> _primary { get; set; } = new List<PrimaryT>();   
        public async Task<List<PrimaryT>> GetPrimarylist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<PrimaryT>>($"api/Primary/GetPrimarylist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreatePrimary(PrimaryT primary)
        {
            Console.WriteLine("Saving primary");
            var result = await _http.PostAsJsonAsync("api/Primary", primary);
            var response = await result.Content.ReadFromJsonAsync<PrimaryT>();
            return response?.Verify_Id;
        }
        public async Task UpdatePrimary(PrimaryT _primaries)
        {
            Console.WriteLine("Update Primary ");
            var result = await _http.PutAsJsonAsync($"api/Primary/UpdatePrimary/{_primaries.Id}", _primaries);
            var response = result.StatusCode.ToString();
        }
        public async Task CreateNewupdate(PrimaryT _primaries)
        {
            var result = await _http.PostAsJsonAsync("api/Primary", _primaries);
            await SetPrimary(result);
        }
        private async Task SetPrimary(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PrimaryT>>();
            _primary = response;
        }

        public List<SecondaryT> _secondary { get; set; } = new List<SecondaryT>();
        public async Task<List<SecondaryT>> GetSecondarylist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<SecondaryT>>($"api/Secondary/GetSecondarylist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateSecondary(SecondaryT _secondaries)
        {
            Console.WriteLine("Saving secondary");
            var result = await _http.PostAsJsonAsync("api/Secondary", _secondaries);
            var response = await result.Content.ReadFromJsonAsync<SecondaryT>();
            return response?.Verify_Id;
        }
        public async Task UpdateSecondary(SecondaryT _secondaries)
        {
            Console.WriteLine("Update Secondary ");
            var result = await _http.PutAsJsonAsync($"api/Secondary/UpdateSecondary/{_secondaries.Id}", _secondaries);
            var response = result.StatusCode.ToString();
        }

        public List<SeniorHST> _seniors { get; set; } = new List<SeniorHST>();
        public async Task<List<SeniorHST>> GetSeniorHSlist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<SeniorHST>>($"api/SeniorHS/GetSeniorHSlist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateSeniorHS(SeniorHST _shs)
        {
            Console.WriteLine("Saving SeniorHS");
            var result = await _http.PostAsJsonAsync("api/SeniorHS", _shs);
            var response = await result.Content.ReadFromJsonAsync<SeniorHST>();
            return response?.Verify_Id;
        }
        public async Task UpdateSeniorHS(SeniorHST _shs)
        {
            Console.WriteLine("Update SeniorHS ");
            var result = await _http.PutAsJsonAsync($"api/SeniorHS/UpdateSeniorHS/{_shs.Id}", _shs);
            var response = result.StatusCode.ToString();
        }

        public List<CollegeT> _college { get; set; }
        public async Task<List<CollegeT>> GetCollegelist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<CollegeT>>($"api/College/GetCollegelist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateCollege(CollegeT _colleges)
        {
            Console.WriteLine("Saving College");
            var result = await _http.PostAsJsonAsync("api/College", _colleges);
            var response = await result.Content.ReadFromJsonAsync<CollegeT>();
            return response?.Verify_Id;
        }
        public async Task UpdateCollege(CollegeT _colleges)
        {
            Console.WriteLine("Update College ");
            var result = await _http.PutAsJsonAsync($"api/College/UpdateCollege/{_colleges.Id}", _colleges);
            var response = result.StatusCode.ToString();
        }

        public List<MasteralT> _masteral { get; set; }
        public async Task<List<MasteralT>> GetMasterallist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<MasteralT>>($"api/Masteral/GetMasterlist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateMasteral(MasteralT _mas)
        {
            Console.WriteLine("Saving Masteral");
            var result = await _http.PostAsJsonAsync("api/Masteral", _mas);
            var response = await result.Content.ReadFromJsonAsync<MasteralT>();
            return response?.Verify_Id;
        }
        public async Task UpdateMasteral(MasteralT _mas)
        {
            Console.WriteLine("Update Masteral ");
            var result = await _http.PutAsJsonAsync($"api/Masteral/UpdateMasteral/{_mas.Id}", _mas);
            var response = result.StatusCode.ToString();
        }

        public List<DoctorateT> _doctorate { get; set; }
        public async Task<List<DoctorateT>> GetDoctoratelist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<DoctorateT>>($"api/Doctorate/GetDoctoratelist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateDoctorate(DoctorateT _doc)
        {
            Console.WriteLine("Saving Doctorate");
            var result = await _http.PostAsJsonAsync("api/Doctorate", _doc);
            var response = await result.Content.ReadFromJsonAsync<DoctorateT>();
            return response?.Verify_Id;
        }
        public async Task UpdateDoctorate(DoctorateT _doc)
        {
            Console.WriteLine("Update Doctorate ");
            var result = await _http.PutAsJsonAsync($"api/Doctorate/UpdateDoctorate/{_doc.Id}", _doc);
            var response = result.StatusCode.ToString();
        }

        public List<OtherEducT> _other { get; set; }
        public async Task<List<OtherEducT>> GetOtherEduclist(string verCode)
        {
            var result = await _http.GetFromJsonAsync<List<OtherEducT>>($"api/OthersEduc/GetOtherEduclist?verCode={verCode}");
            return result;
        }
        public async Task<string> CreateOtherEduc(OtherEducT _others)
        {
            Console.WriteLine("Saving OtherEduc");
            var result = await _http.PostAsJsonAsync("api/OthersEduc", _others);
            var response = await result.Content.ReadFromJsonAsync<OtherEducT>();
            return response?.Verify_Id;
        }
        public async Task UpdateOtherEduc(OtherEducT _others)
        {
            Console.WriteLine("Update OtherEduc ");
            var result = await _http.PutAsJsonAsync($"api/OthersEduc/UpdateOtherEduc/{_others.Id}", _others);
            var response = result.StatusCode.ToString();
        }
    }
}
