namespace HrisApp.Client.Services.ApplicantDetails.ApplicantService
{
    public class ApplicantService : IApplicantService
    {
#nullable disable
        private readonly HttpClient _http;

        public ApplicantService(HttpClient http)
        {
            _http = http;
        }

        public List<ApplicantT> ApplicantTs { get; set; } = new();
        public async Task<List<ApplicantT>> GetApplicantList()
        {
            return await _http.GetFromJsonAsync<List<ApplicantT>>("api/Applicant");
        }

        public async Task GetApplicant()
        {
            var result = await _http.GetFromJsonAsync<List<ApplicantT>>("api/Applicant");
            if (result != null)
            {
                ApplicantTs = result;
            }
        }

        public async Task<ApplicantT> GetSingleApplicant(int id)
        {
            var result = await _http.GetFromJsonAsync<ApplicantT>($"api/Applicant/{id}");
            if (result != null)
                return result;
            throw new Exception("Applicant not found");
        }
        public async Task<string> CreateApplicant(ApplicantT applicant)
        {
            Console.WriteLine("Saving Services sa create Applicant");


            HttpResponseMessage response = await _http.PostAsJsonAsync("api/Applicant/CreateApplicant", applicant);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
            return applicant.App_VerifyId;
        }
        public async Task UpdateApplicant(ApplicantT applicant)
        {
            var result = await _http.PutAsJsonAsync($"api/Applicant/{applicant.Id}", applicant);
            await SetApplicant(result);
        }

        public async Task SetApplicant(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<ApplicantT>>();
            ApplicantTs = response;
        }
    }
}
