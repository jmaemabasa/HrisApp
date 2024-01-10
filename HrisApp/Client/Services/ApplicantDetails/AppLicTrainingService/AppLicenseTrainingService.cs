using HrisApp.Shared.Models.Application;

namespace HrisApp.Client.Services.ApplicantDetails.AppLicTrainingService
{
#nullable disable
    public class AppLicenseTrainingService : IAppLicenseTrainingService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public AppLicenseTrainingService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<App_TrainingT> TrainingTs { get; set; } = new List<App_TrainingT>();
        public List<App_LicenseT> LicenseTs { get; set; } = new List<App_LicenseT>();
        public List<App_ProfBackgroundT> App_ProfBackgroundTs { get; set; } = new List<App_ProfBackgroundT>();
        public List<App_OtherAwardsT> App_OtherAwardsTs { get; set; } = new List<App_OtherAwardsT>();
        public List<App_SelfDeclarationT> App_SelfDeclarationTs { get; set; } = new List<App_SelfDeclarationT>();

        public async Task<List<App_TrainingT>> GetTraininglist(string verifyCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_TrainingT>>($"api/AppTraining/GetTraininglist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateTraining(App_TrainingT train)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppTraining", train);
            var response = await result.Content.ReadFromJsonAsync<App_TrainingT>();
            return response?.Verify_Id;
        }
        public async Task UpdateTraining(App_TrainingT train)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppTraining/UpdateTrainings/{train.Id}", train);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteTraining(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppTraining/{id}");
            //await SetPrimary(result);
        }


        public async Task<List<App_LicenseT>> GetLicenselist(string verifyCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_LicenseT>>($"api/AppLicense/GetLicenselist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateLicense(App_LicenseT _license)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppLicense/InsertLicense", _license);
            var response = await result.Content.ReadFromJsonAsync<App_LicenseT>();
            return response?.Verify_Id;
        }
        public async Task<List<App_LicenseT>> GetExistlicense(string _verifyCode, int id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_LicenseT>>($"api/AppLicense/Getlicenseisexist?verifyId={_verifyCode}&id={id}");
            return result;
        }
        public async Task UpdateLicense(App_LicenseT license)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppLicense/Updatelicense/{license.Id}", license);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteLicense(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppLicense/{id}");
            //await SetPrimary(result);
        }


        public async Task<List<App_ProfBackgroundT>> GetProfBglist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_ProfBackgroundT>>($"api/AppProfBackground/GetProfBglist?verifyCode={verCode}");
            return result;
        }
        public async Task<string> CreateProfBg(App_ProfBackgroundT profbg)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppProfBackground/InsertProfBg", profbg);
            var response = await result.Content.ReadFromJsonAsync<App_ProfBackgroundT>();
            return response?.App_VerifyId;
        }
        public async Task UpdateProfBg(App_ProfBackgroundT profbg)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppProfBackground/UpdateProfBg/{profbg.Id}", profbg);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteProfBg(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppProfBackground/{id}");
        }


        public async Task<List<App_OtherAwardsT>> GetOtherAwardslist(string verCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_OtherAwardsT>>($"api/AppOtherAwards/GetOtherAwardslist?verifyCode={verCode}");
            return result;
        }
        public async Task<string> CreateOtherAwards(App_OtherAwardsT profbg)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppOtherAwards/InsertOtherAwards", profbg);
            var response = await result.Content.ReadFromJsonAsync<App_OtherAwardsT>();
            return response?.Verify_Id;
        }
        public async Task UpdateOtherAwards(App_OtherAwardsT profbg)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppOtherAwards/UpdateOtherAwards/{profbg.Id}", profbg);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteOtherAwards(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppOtherAwards/{id}");
        }


        public async Task GetSelfDeclaration()
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_SelfDeclarationT>>("api/AppSelfDec/GetSelfDec");
            if (result != null)
                App_SelfDeclarationTs = result;
        }
        public async Task<App_SelfDeclarationT> GetSingleSelfDeclaration(int id)
        {

            var result = await _httpClient.GetFromJsonAsync<App_SelfDeclarationT>($"api/AppSelfDec/{id}");
            if (result != null)
                return result;
            throw new Exception("address not found!");
        }

        public async Task<string> CreateSelfDeclaration(App_SelfDeclarationT address)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppSelfDec", address);
            await SetSelfDeclaration(result);
            return address.App_VerifyId;//new
        }

        public async Task UpdateSelfDeclaration(App_SelfDeclarationT address)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppSelfDec/{address.Id}", address);
            await SetSelfDeclaration(result);
        }

        public async Task DeleteSelfDeclaration(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppSelfDec/{id}");
            //await SetAddress(result);
        }


        private async Task SetSelfDeclaration(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<App_SelfDeclarationT>>();
            App_SelfDeclarationTs = response;

        }
    }
}
