using HrisApp.Shared.Models.LiscenseAndTraining;
using System.ComponentModel;
using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.LicAndTrainService
{
    public class LicenseTrainingService : ILicenseTrainingService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public LicenseTrainingService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<TrainingT> TrainingTs { get; set; } = new List<TrainingT>();
        public List<LicenseT> LicenseTs { get; set; } = new List<LicenseT>();

        public async Task<List<TrainingT>> GetTraininglist(string verifyCode)
        {
            var result = await _http.GetFromJsonAsync<List<TrainingT>>($"api/Training/GetTraininglist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateTraining(TrainingT train)
        {
            Console.WriteLine("Saving train");
            var result = await _http.PostAsJsonAsync("api/Training", train);
            var response = await result.Content.ReadFromJsonAsync<TrainingT>();
            return response?.Verify_Id;
        }
        public async Task UpdateTraining(TrainingT train)
        {
            Console.WriteLine("Update train");
            var result = await _http.PutAsJsonAsync($"api/Training/UpdateTrainings/{train.Id}", train);
            var response = result.StatusCode.ToString();
        }



        public async Task<List<LicenseT>> GetLicenselist(string verifyCode)
        {
            var result = await _http.GetFromJsonAsync<List<LicenseT>>($"api/License/GetLicenselist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateLicense(LicenseT _license)
        {
            Console.WriteLine("Saving License");
            var result = await _http.PostAsJsonAsync("api/License/InsertLicense", _license);
            var response = await result.Content.ReadFromJsonAsync<LicenseT>();
            return response?.Verify_Id;
        }
        public async Task<List<LicenseT>> GetExistlicense(string _verifyCode, int id)
        {
            var result = await _http.GetFromJsonAsync<List<LicenseT>>($"api/License/Getlicenseisexist?verifyId={_verifyCode}&id={id}");
            return result;
        }
        public async Task UpdateLicense(LicenseT license)
        {
            var result = await _http.PutAsJsonAsync($"api/License/Updatelicense/{license.Id}", license);
            var response = result.StatusCode.ToString();
        }
    }
}
