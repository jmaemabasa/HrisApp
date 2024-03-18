using System.Diagnostics;

namespace HrisApp.Client.Services.LicAndTrainService
{
#nullable disable

    public class LicenseTrainingService : ILicenseTrainingService
    {
        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public LicenseTrainingService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_TrainingT> TrainingTs { get; set; } = new List<Emp_TrainingT>();
        public List<Emp_LicenseT> LicenseTs { get; set; } = new List<Emp_LicenseT>();
        public List<Emp_ProfBackgroundT> Emp_ProfBackgroundTs { get; set; } = new List<Emp_ProfBackgroundT>();

        public async Task<List<Emp_TrainingT>> GetTraininglist(string verifyCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_TrainingT>>($"api/Training/GetTraininglist?verifyCode={verifyCode}");
            return result;
        }

        public async Task<string> CreateTraining(Emp_TrainingT train)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Training", train);
            var response = await result.Content.ReadFromJsonAsync<Emp_TrainingT>();
            return response?.Verify_Id;
        }

        public async Task UpdateTraining(Emp_TrainingT train)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Training/UpdateTrainings/{train.Id}", train);
            var response = result.StatusCode.ToString();
        }

        public async Task DeleteTraining(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Training/{id}");
            //await SetPrimary(result);
        }

        public async Task<List<Emp_LicenseT>> GetLicenselist(string verifyCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_LicenseT>>($"api/License/GetLicenselist?verifyCode={verifyCode}");
            return result;
        }

        public async Task<string> CreateLicense(Emp_LicenseT _license)
        {
            var result = await _httpClient.PostAsJsonAsync("api/License/InsertLicense", _license);
            var response = await result.Content.ReadFromJsonAsync<Emp_LicenseT>();
            return response?.Verify_Id;
        }

        public async Task<List<Emp_LicenseT>> GetExistlicense(string _verifyCode, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_LicenseT>>($"api/License/Getlicenseisexist?verifyId={_verifyCode}&id={id}");
            return result;
        }

        public async Task UpdateLicense(Emp_LicenseT license)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/License/Updatelicense/{license.Id}", license);
            var response = result.StatusCode.ToString();
        }

        public async Task DeleteLicense(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/License/{id}");
            //await SetPrimary(result);
        }

        public async Task<List<Emp_ProfBackgroundT>> GetProfBglist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_ProfBackgroundT>>($"api/ProfBackground/GetProfBglist?verifyCode={verCode}");
            return result;
        }

        public async Task<string> CreateProfBg(Emp_ProfBackgroundT profbg)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ProfBackground/InsertProfBg", profbg);
            var response = await result.Content.ReadFromJsonAsync<Emp_ProfBackgroundT>();
            return response?.Verify_Id;
        }

        public async Task UpdateProfBg(Emp_ProfBackgroundT profbg)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/ProfBackground/UpdateProfBg/{profbg.Id}", profbg);
            var response = result.StatusCode.ToString();
        }

        public async Task DeleteProfBg(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/ProfBackground/{id}");
        }
    }
}