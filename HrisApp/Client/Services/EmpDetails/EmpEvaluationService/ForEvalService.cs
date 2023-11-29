//using HrisApp.Shared.Models.Employee;

//namespace HrisApp.Client.Services.EmpDetails.EmpEvaluationService
//{
//#nullable disable
//    public class ForEvalService : IForEvalService
//    {
//        public HttpClient _httpClient;
//        MainsService _mainService = new MainsService();
//        public ForEvalService()
//        {
//            _httpClient = _mainService.Get_Http();
//        }

//        public List<EmployeeEvaluationT> EmployeeEvaluationTs { get; set; } = new List<EmployeeEvaluationT>();
//        public async Task<List<EmployeeEvaluationT>> GetForEvallist(string verCode)
//        {
//            return await _httpClient.GetFromJsonAsync<List<EmployeeEvaluationT>>($"api/EmpEvaluation/GetForEvallist?verCode={verCode}");
//        }

//        public async Task GetForEval()
//        {
//            var result = await _httpClient.GetFromJsonAsync<List<EmployeeEvaluationT>>("api/EmpEvaluation/GetForEval");
//            if (result != null)
//            {
//                EmployeeEvaluationTs = result;
//            }
//        }

//        public async Task<EmployeeEvaluationT> GetSingleEval(int id)
//        {
//            var result = await _httpClient.GetFromJsonAsync<EmployeeEvaluationT>($"api/EmpEvaluation/{id}");
//            if (result != null)
//                return result;
//            throw new Exception("eval not found");
//        }

//        public async Task<string> CreateForEval(EmployeeEvaluationT eval)
//        {
//            Console.WriteLine("Saving Services sa create employee evaluation");


//            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", eval);
//            if (!response.IsSuccessStatusCode)
//            {
//                var errorMessage = await response.Content.ReadAsStringAsync();
//                Console.WriteLine("Error: " + errorMessage);
//            }
//            return eval.Verify_Id;
//        }

//        public async Task UpdateForEval(EmployeeEvaluationT eval)
//        {
//            var result = await _httpClient.PutAsJsonAsync($"api/EmpEvaluation/{eval.Id}", eval);
//            await SetEval(result);
//        }

//        public async Task SetEval(HttpResponseMessage result)
//        {
//            var response = await result.Content.ReadFromJsonAsync<List<EmployeeEvaluationT>>();
//            EmployeeEvaluationTs = response;
//        }
//    }
//}
