using System.Net.Http;

namespace HrisApp.Client.Services.ApplicantDetails.AppSibChildService
{
#nullable disable
    public class AppSibChildService : IAppSibChildService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public AppSibChildService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<App_SiblingT> App_SiblingTs { get; set; } = new List<App_SiblingT>();
        public List<App_ChildrenT> App_ChildrenTs { get; set; } = new List<App_ChildrenT>();

        public async Task<List<App_SiblingT>> GetSiblinglist(string verifyCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_SiblingT>>($"api/AppSibling/GetSiblinglist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateSibling(App_SiblingT train)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppSibling/InsertSibling", train);
            var response = await result.Content.ReadFromJsonAsync<App_SiblingT>();
            return response?.App_VerifyId;
        }
        public async Task UpdateSibling(App_SiblingT train)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppSibling/UpdateSibling/{train.Id}", train);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteSibling(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppSibling/{id}");
            //await SetPrimary(result);
        }


        public async Task<List<App_ChildrenT>> GetChildrenlist(string verifyCode)
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_ChildrenT>>($"api/AppChildren/GetChildrenlist?verifyCode={verifyCode}");
            return result;
        }
        public async Task<string> CreateChildren(App_ChildrenT train)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppChildren/InsertChildren", train);
            var response = await result.Content.ReadFromJsonAsync<App_ChildrenT>();
            return response?.App_VerifyId;
        }
        public async Task UpdateChildren(App_ChildrenT train)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppChildren/UpdateChildren/{train.Id}", train);
            var response = result.StatusCode.ToString();
        }
        public async Task DeleteChildren(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppChildren/{id}");
            //await SetPrimary(result);
        }
    }
}
