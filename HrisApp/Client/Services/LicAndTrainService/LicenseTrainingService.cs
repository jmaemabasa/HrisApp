namespace HrisApp.Client.Services.LicAndTrainService
{
#nullable disable
    public class LicenseTrainingService : ILicenseTrainingService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public LicenseTrainingService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Emp_TrainingT> TrainingTs { get; set; } = new List<Emp_TrainingT>();
        public List<Emp_LicenseT> LicenseTs { get; set; } = new List<Emp_LicenseT>();

        public async Task<List<Emp_TrainingT>> GetTraininglist(string verifyCode)
        {
            var result = await _http.GetFromJsonAsync<List<Emp_TrainingT>>($"api/Training/GetTraininglist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateTraining(Emp_TrainingT train)
        {
            Console.WriteLine("Saving train");
            var result = await _http.PostAsJsonAsync("api/Training", train);
            var response = await result.Content.ReadFromJsonAsync<Emp_TrainingT>();
            return response?.Verify_Id;
        }
        public async Task UpdateTraining(Emp_TrainingT train)
        {
            Console.WriteLine("Update train");
            var result = await _http.PutAsJsonAsync($"api/Training/UpdateTrainings/{train.Id}", train);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteTraining(int id)
        {
            var result = await _http.DeleteAsync($"api/Training/{id}");
            //await SetPrimary(result);
        }


        public async Task<List<Emp_LicenseT>> GetLicenselist(string verifyCode)
        {
            var result = await _http.GetFromJsonAsync<List<Emp_LicenseT>>($"api/License/GetLicenselist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateLicense(Emp_LicenseT _license)
        {
            Console.WriteLine("Saving License");
            var result = await _http.PostAsJsonAsync("api/License/InsertLicense", _license);
            var response = await result.Content.ReadFromJsonAsync<Emp_LicenseT>();
            return response?.Verify_Id;
        }
        public async Task<List<Emp_LicenseT>> GetExistlicense(string _verifyCode, int id)
        {
            var result = await _http.GetFromJsonAsync<List<Emp_LicenseT>>($"api/License/Getlicenseisexist?verifyId={_verifyCode}&id={id}");
            return result;
        }
        public async Task UpdateLicense(Emp_LicenseT license)
        {
            var result = await _http.PutAsJsonAsync($"api/License/Updatelicense/{license.Id}", license);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteLicense(int id)
        {
            var result = await _http.DeleteAsync($"api/License/{id}");
            //await SetPrimary(result);
        }
    }
}
